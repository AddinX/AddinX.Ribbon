using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Enums;
using AddinX.Ribbon.ExcelDna;
using AddinX.Ribbon.Implementation.Command;
using RibbonTests.Properties;

namespace RibbonTests
{
    [ComVisible(true)]
    public class MyRibbon:RibbonFluent {

        /// <summary>
        /// 设计模式
        /// </summary>
        public bool DesignMode { get; set; }

        private static bool pressed = false;
        private readonly IToggleButtonCommand _startMeasureCommand = new ToggleButtonCommand() {
            onActionPressed = (b) => {
                MessageBox.Show("Start Measure " + b);
                pressed = b;
                Ribbon.Invalidate();
            },
            getImage = () => {
                if (pressed) {
                    return Resources.greenLighton_24;
                } else {
                    return Resources.redlightoff_24;
                }
            },
            getPressed = () => { return pressed; },
           // getSize = () => { return pressed ? ControlSize.large : ControlSize.normal; }
        };

        private readonly IToggleButtonCommand speakCommand = new ToggleButtonCommand() {
            onActionPressed = b => {
                Settings.Default.SpeechValue = b;
                Settings.Default.Save();
            },
            getPressed = ()=>Settings.Default.SpeechValue,
        };

        private readonly ICheckBoxCommand hotTraceCommand = new CheckBoxCommand() {
            onActionPressed = b=> {
                Settings.Default.IsHotTrace = b;
                Ribbon.Invalidate();
            },
            getPressed = ()=>Settings.Default.IsHotTrace
        };

        private readonly IButtonCommand _setMeasureValuesRange = new ButtonCommand() {
            onAction = () => Console.WriteLine($"SetMeasureValuesRange  Action"),
            getEnabled = () => { return Settings.Default.IsHotTrace; }
        };

        private readonly IToggleButtonCommand _fillRightCommand = new ToggleButtonCommand() {
            onActionPressed = b => {
                Settings.Default.ValueAppendDiection = b;
                Ribbon.Invalidate();
            },
            getPressed = () => Settings.Default.ValueAppendDiection,
        };

        private readonly IToggleButtonCommand _fillDownCommand = new ToggleButtonCommand() {
            onActionPressed = b => {
                Settings.Default.ValueAppendDiection = !b;
                Ribbon.Invalidate();
            },
            getPressed = () => !Settings.Default.ValueAppendDiection,
        };

        private readonly IToggleButtonCommand _designModeCommand;

        private readonly IButtonCommand _configSerialPortCommand = new ButtonCommand() {
            onAction = () => { MessageBox.Show("设置串口参数"); }
        };

        public MyRibbon() {
            _designModeCommand = new ToggleButtonCommand() {
                getEnabled = ()=>true,
                onActionPressed = (b) => {
                    this.DesignMode = b;
                    Ribbon.Invalidate();
                }
            };
        }

        #region Overrides of RibbonFluent

        /// <summary>
        /// 创建 Ribbon Xml
        /// </summary>
        /// <param name="build"></param>
        protected override void CreateFluentRibbon(IRibbonBuilder build) {

            build.CustomUi.Ribbon.Tabs(ts => ts.AddTab("测量管理工具")
                .Groups(gs => {
                    gs.AddGroup("测量管理工具").AddItems(items => {
                            items.AddToggleButton("开始测量").LargeSize().Callback(_startMeasureCommand);
                            items.AddSeparator();
                            items.AddCheckbox("跟踪测量单元格")
                                .Supertip("如果选中此项，在测量时会选中正在进行的 测量数据单元格,用来指示当前测量的位置")
                                .Callback(hotTraceCommand);
                            //<toggleButton id="Id_SpeechValue" imageMso="SpeakCells" label = "语音报读" supertip = "选中此项，会朗读测量读数，需要系统语音支持" onAction = "OnToggleButtonAction"getPressed = "GetPressed" />
                            items.AddToggleButton("语音报读").ImageMso("SpeakCells")
                                .Supertip("选中此项，会朗读测量读数，需要系统语音支持")
                                .Callback(speakCommand);
                            //button id="SetMeasureValuesRange" label="测量数据区域" imageMso="ImportSharePointList" supertip = "设置当前工作表的数据采集区域" onAction = "OnButtonAction" getEnabled = "GetEnabled" />
                            items.AddButton("测量数据区域").ImageMso("ImportSharePointList")
                                .Supertip("设置当前工作表的数据采集区域")
                                .Callback(_setMeasureValuesRange);
                            items.AddSeparator();
                            // <toggleButton id="Id_FillDirection.ColumnFirst"  size="large" label = "向右填充" image = "FillRight_16" supertip = "采集数据时,从当前单元格开始向右方填写数据" getPressed = "GetPressed" onAction = "OnToggleButtonAction" />
                            items.AddToggleButton("向右填充").LargeSize().ImagePath("FillRight_16")
                                .Supertip("采集数据时,从当前单元格开始向右方填写数据")
                                .Callback(_fillRightCommand);
                            //<toggleButton id="Id_FillDirection.RowFirst"  size="large"  label = "向下填充" image = "FillDown_16" supertip = "采集数据时,从当前单元格开始向下方填写数据" getPressed = "GetPressed" onAction = "OnToggleButtonAction" />

                            items.AddToggleButton("向下填充").LargeSize().ImagePath("FillDown_16")
                                .Supertip("采集数据时,从当前单元格开始向下方填写数据")
                                .Callback(_fillDownCommand);

                            items.AddSeparator();
                            // <toggleButton id="Id_DesignMode" label="编辑模式" imageMso="DesignMode" supertip = "选中此项，进入任务编辑模式，开始编辑测量任务" onAction = "OnToggleButtonAction" getPressed = "GetPressed"
                            //    getEnabled = "GetEnabled" />
                            items.AddToggleButton("编辑模式").ImageMso("DesignMode").Supertip("选中此项，进入任务编辑模式")
                                .Callback(_designModeCommand);
                        });
                    gs.AddGroup("编辑工具").AddItems(items => {
                            items.AddButton("设置串口参数").ImagePath("setting_32").Supertip("设置插件默认串口配置信息")
                                .Callback(_configSerialPortCommand);
                            items.AddCheckbox("使用绝对值").Supertip("如果选中此项，忽略测量值符号,强制转换为绝对值")
                                .Callback(c=>c.OnChecked(Console.WriteLine));
                            items.AddButton("日志文件").Supertip("打开当前日志文件").ImageMso("TableOfContentsGallery")
                                .Callback(b=> {
                                    b.onAction = ()=>{MessageBox.Show("打开日志");};
                                });
                        }).Callback(g=>g.IsVisible(()=>DesignMode));
                })
            );
        }

        public override void OnClosing() {
            
        }

        public override void OnOpening() {
            
        }

        #endregion
    }
}
