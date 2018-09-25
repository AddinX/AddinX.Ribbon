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
        private readonly IButtonCommand _bt1 = new ButtonCommand() {
            OnAction = ()=>MessageBox.Show("On Button Action")
        };

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

        #region Overrides of RibbonFluent

        /// <summary>
        /// 创建 Ribbon Xml
        /// </summary>
        /// <param name="build"></param>
        protected override void CreateFluentRibbon(IRibbonBuilder build) {

            build.CustomUi.Ribbon.Tabs(ts => ts.AddTab("测量管理工具")
                .Groups(g => g.AddGroup("测量管理工具")
                    .AddItems(items => {
                            items.AddToggleButton("开始测量").LargeSize().Callback(_startMeasureCommand);
                            items.AddButton("Button 1").LargeSize().Callback(_bt1);
                        }
                    )));
        }

        public override void OnClosing() {
            
        }

        public override void OnOpening() {
            
        }

        #endregion
    }
}
