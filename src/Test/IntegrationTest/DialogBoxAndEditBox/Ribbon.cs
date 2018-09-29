using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.ExcelDna;
using AddinX.Ribbon.Implementation;

namespace AddinX.Ribbon.IntegrationTest.DialogBoxAndEditBox
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

        private RibbonCommands commands = new RibbonCommands();

        public override Image OnLoadImage(string imageName)
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
                c.AddTab("My Tab").Id(MyTabId)
                    .Groups(g =>
                    {
                        g.AddGroup("Data").Id(DataGroupId)
                            .Items(d =>
                            {
                                d.AddEditbox("input Text").Id(InputText)
                                    .ImagePath("option").MaxLength(7)
                                    .SizeString(7)
                                    .Callback((IEditBoxCommand)commands.Find(InputText));

                                d.AddLabelControl().Id(OutputText)
                                    .Callback((ILabelCommand)commands.Find(OutputText));

                                d.AddButton("Happy")
                                    .Id(HappyButtonId)
                                    .LargeSize()
                                    .ImageMso("HappyFace")
                                    .Callback((IButtonCommand)commands.Find(HappyButtonId));
                            })
                        .DialogBoxLauncher(i => i.AddDialogBoxLauncher().Id(BoxLauncherId).Supertip("Box launcher"));
                    });
            });
        }

        protected void CreateRibbonCommand(IRibbonCommands cmds)
        {
            cmds.AddButtonCommand(HappyButtonId).OnAction(() => MessageBox.Show("Be Happy !!!"));
            

            cmds.AddLabelCommand(OutputText).GetLabel(()=> resultText);
            cmds.AddEditBoxCommand(InputText).OnChange((a) =>
            {
                resultText = a;
                Ribbon.InvalidateControl(OutputText);
            })
            .GetText(() => "Hello");
            cmds.AddDialogBoxLauncherCommand(BoxLauncherId)
                .OnAction(() => MessageBox.Show("Dialog Box clicked"));
        }

        public override void OnClosing()
        {
            AddinContext.ExcelApp.DisposeChildInstances(true);
            AddinContext.ExcelApp = null;
        }

        public override void OnOpening() {
            CreateRibbonCommand(commands);
        }
        
    }
}