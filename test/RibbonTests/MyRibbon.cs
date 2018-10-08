using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
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
        private IToggleButtonCommand _startMeasureCommand = new ToggleButtonCommand();
        private IButtonCommand _setValueRangeCommand;
        private IButtonCommand _activeProdCommand;

        private IButtonCommand _configSerialPortCommand;
        private bool _designMode;
        private XlFillDirection _appendDirection;
        private bool _taskStatus;

        private bool DesignMode {
            get => _designMode;
            set {
                if (_designMode == value) return;
                _designMode = value;
                Ribbon.Invalidate();
            }
        }

        private bool IsForceAbsValue { get; set; }

        private bool IsHotTrack { get; set; }

        private bool UseSpeach { get; set; }

        private bool TaskStatus {
            get => _taskStatus;
            set {
                _taskStatus = value;
                this.Ribbon.Invalidate();
            }
        }

        /// <summary>
        /// 数据追加方向
        /// </summary>
        private XlFillDirection AppendDirection {
            get => _appendDirection;
            set {
                if (Equals(_appendDirection, value)) return;
                _appendDirection = value;
                this.Ribbon.Invalidate();
            }
        }

        private void ShowLogFile() {
            Console.WriteLine("ShowLogFile");
        }

        private void ActiveProduct() {
            Console.WriteLine("ActiveProduct");
        }

        private bool ControlEnabled() {
            return true;
        }
        

        private void InitCommands() {
            _startMeasureCommand = new ToggleButtonCommand() {
                onActionPressed = b => {
                    Console.WriteLine("startMeasureCommand Pressed {0}",b);
                    TaskStatus = b;
                    Ribbon.Invalidate();
                },
                getImage = ()=>TaskStatus?Resources.greenLighton_24:Resources.redlightoff_24,
                getPressed = () => TaskStatus,
                getLabel = () => TaskStatus ? "停止测量" : "开始测量",
                getEnabled = ControlEnabled
            };

            _setValueRangeCommand = new ButtonCommand() {
                onAction = () => {
                    Console.WriteLine("设置数据采集区域");
                    
                }, getEnabled = () => true,
            };

            _activeProdCommand = new ButtonCommand() {
                onAction = ActiveProduct,
                getEnabled = () => true
            };

            _configSerialPortCommand = new ButtonCommand() {
                onAction = () => {
                  Console.WriteLine("设置串口通讯");
                }
            };
        }

        #region Overrides of RibbonFluent

        /// <summary>
        /// 创建 Ribbon Xml
        /// </summary>
        /// <param name="build"></param>
        protected override void CreateFluentRibbon(IRibbonBuilder build) {
            build.CustomUi.Ribbon.Tabs(tabs => tabs.AddTab("测量管理工具")
                          .Groups(groups => {
                              groups.AddGroup("测量管理工具")
                                  .Items(g => {
                                      g.AddToggleButton("测量开关").Id(ControlIds.StartMeasuring)
                                          .LargeSize().Callback(_startMeasureCommand);
                                      g.AddSeparator();

                                      g.AddCheckbox("跟踪测量单元格").Id(ControlIds.IsHotTrace)
                                          .Supertip("如果选中此项，在测量时会选中正在进行的 测量数据单元格,用来指示当前测量的位置")
                                          .Callback(cb => cb.OnChecked(b => IsHotTrack = b).GetChecked(() => IsHotTrack));

                                      g.AddToggleButton("语音报读").Id(ControlIds.SpeechValue).ImageMso("SpeakCells")
                                          .Supertip("选中此项，会朗读测量读数，需要系统语音支持")
                                          .Callback(cb => cb.OnPressed(b => UseSpeach = b).GetPressed(() => UseSpeach));

                                      g.AddButton("测量数据区域").Id(ControlIds.SetMeasureValuesRange)
                                          .ImageMso("ImportSharePointList")
                                          .Callback(_setValueRangeCommand);
                                      g.AddSeparator();

                                      g.AddToggleButton("向右填充").Id(ControlIds.FillDirection_ColumnFirst).LargeSize()
                                          .ImagePath("FillRight_16").Supertip("采集数据时,从当前单元格开始向右方填写数据")
                                          .Callback(cb => cb.GetPressed(() => AppendDirection == XlFillDirection.ColumnFirst)
                                              .OnPressed(b => AppendDirection = XlFillDirection.ColumnFirst));

                                      g.AddToggleButton("向下填充").Id(ControlIds.FillDirection_RowFirst).LargeSize()
                                          .ImagePath("FillDown_16").Supertip("采集数据时,从当前单元格开始向下方填写数据")
                                          .Callback(cb => cb.GetPressed(() => AppendDirection == XlFillDirection.RowFirst)
                                              .OnPressed(b => AppendDirection = XlFillDirection.RowFirst));

                                      g.AddSeparator();

                                      g.AddToggleButton("编辑模式").Id(ControlIds.DesignMode).ImageMso("DesignMode")
                                          .Supertip("选中此项，进入任务编辑模式，开始编辑测量任务")
                                          .Callback(cb => cb.GetPressed(() => DesignMode).OnPressed(b => DesignMode = b));

                                      g.AddSeparator();
                                      g.AddButton("激活产品").ImageMso("AdpPrimaryKey").LargeSize()
                                          .Callback(_activeProdCommand);
                                  });

                              groups.AddGroup("编辑工具").Id(ControlIds.DesignToolGroup)
                                  .Items(items => {
                                      items.AddButton("设置串口参数").Id(ControlIds.ConfigSerialPort)
                                          .ImagePath("setting_32")
                                          .Callback(_configSerialPortCommand);

                                      items.AddCheckbox("使用绝对值").Id(ControlIds.FroceAbsValue)
                                          .Supertip("如果选中此项，忽略测量值符号,强制转换为绝对值")
                                          .Callback(f => f.GetChecked(() => IsForceAbsValue)
                                              .OnChecked(isChecked => IsForceAbsValue = isChecked));

                                      items.AddButton("日志文件").Id(ControlIds.OpenLogFile)
                                          .ImageMso("TableOfContentsGallery")
                                          .Supertip("打开当前日志文件")
                                          .Callback(cb => cb.OnAction(ShowLogFile));

                                  }).Callback(g => g.GetVisible(() => DesignMode));
                          })
                      );
        }

        public override void OnClosing() {
            
        }

        public override void OnOpening() {
            InitCommands();
        }

        #region Overrides of ExcelRibbon

        public override Image OnLoadImage(string imageId) {
            var obj = Resources.ResourceManager.GetObject(imageId);
            if (obj is Image image) {
                return image;
            }
            return base.OnLoadImage(imageId);
        }

        #endregion

        #endregion

        static class ControlIds {
            /// <summary>
            /// 强制使用绝对值
            /// </summary>
            public const string FroceAbsValue = "Id_FroceAbsValue";

            /// <summary>
            /// 重新加载配置数据
            /// </summary>
            public const string ReloadConfig = "Id_ReloadConfig";

            /// <summary>
            ///     重置测量任务计数,但不清除测量数据
            /// </summary>
            public const string ResetState = "Id_ResetState";

            /// <summary>
            ///     编辑测量任务
            /// </summary>
            public const string EditMeasuringConfig = "Id_EditMeasuringConfig";

            /// <summary>
            /// 激活产品
            /// </summary>
            public const string ProductActive = "ProductActive";

            /// <summary>
            /// 开始测量
            /// </summary>
            public const string StartMeasuring = "Id_StartMeasuring";

            public const string InitMeasurementConfig = "Id_InitMeasurementConfig";

            /// <summary>
            /// 切换设计模式
            /// </summary>
            public const string DesignMode = "Id_DesignMode";

            /// <summary>
            ///  数据填充方向
            /// </summary>
            public const string FillDirection = "Id_FillDirection";

            public const string FillDirection_ColumnFirst = "Id_FillDirection.ColumnFirst";
            public const string FillDirection_RowFirst = "Id_FillDirection.RowFirst";

            /// <summary>
            /// 打开日志文件
            /// </summary>
            public const string OpenLogFile = "OpenLogFile";

            /// <summary>
            ///     跟踪活动测量
            /// </summary>
            public const string IsHotTrace = "Id_IsHotTrace";

            /// <summary>
            /// 语音播报
            /// </summary>
            public const string SpeechValue = "Id_SpeechValue";

            /// <summary>
            /// 设置测量数据范围
            /// </summary>
            public const string SetMeasureValuesRange = "SetMeasureValuesRange";

            #region Group Id

            /// <summary>
            /// 设计工具组
            /// </summary>
            public const string DesignToolGroup = "Id_DesignToolsGroup";

            #endregion

            /// <summary>
            /// 配置串口
            /// </summary>
            public const string ConfigSerialPort = nameof(ConfigSerialPort);
        }
    }
}
