using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AddinX.Core.Contract;
using AddinX.Core.Contract.Command;
using AddinX.Core.ExcelDna;

namespace AddinX.Core.IntegrationTest.DialogBoxAndEditBox
{
    [ComVisible(true)]
    public class Ribbon : RibbonFluent
    {
        private const string HappyButtonId = "HappyButton";
        private const string BoxLauncherId = "BoxLauncher";
        private const string InputText = "TextInputId";
        private const string OutputText = "TextOutputId";
        private const string MyTabId = "MyTabId";
        private const string DataGroupId = "DataGroupId";

        private string resultText = "Test";

        public override Bitmap OnLoadImage(string imageName)
        {
            if (imageName == "option")
            {
                return Properties.Resources.option;
            }

            return Properties.Resources.one;

        }

        protected override void CreateFluentRibbon(IRibbonBuilder builder)
        {
            builder.CustomUi.Ribbon.Tabs(c =>
            {
                c.AddTab("My Tab").SetId(MyTabId)
                    .Groups(g =>
                    {
                        g.AddGroup("Data").SetId(DataGroupId)
                            .Items(d =>
                            {
                                d.AddEditbox("input Text").SetId(InputText)
                                    .ImagePath("option").MaxLength(7)
                                    .SizeString(7);
                                d.AddLabelControl().SetId(OutputText);
                                d.AddBouton("Happy")
                                    .SetId(HappyButtonId)
                                    .LargeSize()
                                    .ImageMso("HappyFace");
                            })
                        .DialogBoxLauncher(i => i.AddDialogBoxLauncher().SetId(BoxLauncherId).Supertip("Box launcher"));
                    });
            });
        }

        protected override void CreateRibbonCommand(IRibbonCommands cmds)
        {
            cmds.AddButtonCommand(HappyButtonId).Action(() => MessageBox.Show("Be Happy !!!"));
            

            cmds.AddLabelCommand(OutputText).GetLabel(()=> resultText);
            cmds.AddEditBoxCommand(InputText).OnChange((a) =>
            {
                resultText = a;
                Ribbon.InvalidateControl(OutputText);
            })
            .GetText(() => "Hello");
            cmds.AddDialogBoxLauncherCommand(BoxLauncherId)
                .Action(() => MessageBox.Show("Dialog Box clicked"));
        }

        public override void OnClosing()
        {
            AddinContext.ExcelApp.DisposeChildInstances(true);
            AddinContext.ExcelApp = null;
        }

        public override void OnOpening() { }
        
    }
}