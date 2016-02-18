using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AddinX.Core.Contract;
using AddinX.Core.Contract.Command;
using AddinX.Core.Contract.Enums;
using AddinX.Core.ExcelDna;

namespace ContextualTab
{
    [ComVisible(true)]
    public class Ribbon : RibbonFluent
    {
        protected override void CreateFluentRibbon(IRibbonBuilder build)
        {
            build.CustomUi.Ribbon.ContextualTabs(tabs =>
                tabs.AddTabSet(set => set.SetIdMso(TabSetId.TabSetDrawingTools)
                    .Tabs(tab => tab.AddTab("Sample").SetId("SampleContextId")
                        .Groups(g => g.AddGroup("Custom group").SetId("CustomGroupContextId")
                            .Items(d =>
                            {
                                d.AddButton("Button 1").SetId("Button1")
                                    .LargeSize().ImageMso("HappyFace");
                                d.AddButton("Button 2").SetId("Button2")
                                    .LargeSize().ImageMso("Bold");
                            })
                        ))));
        }

        protected override void CreateRibbonCommand(IRibbonCommands cmds)
        {
            cmds.AddButtonCommand("Button1").Action(
                    () => MessageBox.Show("Button 1 clicked"));

            cmds.AddButtonCommand("Button2").Action(
                    () => MessageBox.Show("Button 2 clicked"));
        }

        public override void OnClosing()
        {
            
        }

        public override void OnOpening()
        {
            
        }
    }
}