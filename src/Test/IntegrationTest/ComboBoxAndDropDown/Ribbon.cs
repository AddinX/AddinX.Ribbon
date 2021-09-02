using System.Runtime.InteropServices;
using System.Windows.Forms;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.ExcelDna;
using AddinX.Ribbon.IntegrationTest.ComboBoxAndDropDown.Data;
using AddinX.Ribbon.IntegrationTest.ComboBoxAndDropDown.Utils;

namespace AddinX.Ribbon.IntegrationTest.ComboBoxAndDropDown
{
    [ComVisible(true)]
    public class Ribbon : RibbonFluent
    {

        private const string BookmarksComboId = "bookmarksCombo";
        private const string BookmarksDropDownId = "BookmarksDropDownId";
        private const string MyTabId = "MyTabId";
        private const string DataGroupId = "DataGroupId";
        private const string ButtonMore = "buttonMore";
        private const string ToggleButtonId = "ToggleButtonId";
        private ListItems content;
        
        protected override void CreateFluentRibbon(IRibbonBuilder builder)
        {
            builder.CustomUi.AddNamespace("acme","acme.addin.sync").Ribbon.Tabs(c =>
            {
                c.AddTab("My Tab").SetIdQ("acme",MyTabId)
                    .Groups(g =>
                    {
                        g.AddGroup("Data").SetIdQ("acme", DataGroupId)
                        .Items(d =>
                        {
                            d.AddButton("My Save").SetIdMso("FileSave")
                                .NormalSize().ImageMso("FileSave");
                            d.AddButton("Button").SetId("buttonOne");
                            d.AddComboBox("numbers")
                                .SetId(BookmarksComboId)
                                .ShowLabel().NoImage()
                                .DynamicItems();

                            d.AddDropDown("With Image")
                                .SetId(BookmarksDropDownId)
                                .ShowLabel().NoImage()
                                .ShowItemLabel().ShowItemImage().DynamicItems()
                                .AddButtons(b => b.AddButton("Button...").SetId(ButtonMore));



                            d.AddToggleButton("Toggle Button")
                                .SetId(ToggleButtonId);
                        });

                    });
            });
        }

        

        protected override void CreateRibbonCommand(IRibbonCommands cmds)
        {
            cmds.AddButtonCommand(ButtonMore).Action(() => MessageBox.Show(@"More..."));

            cmds.AddToggleButtonCommand(ToggleButtonId)
                .Action(isPressed =>
                {
                    MessageBox.Show(isPressed 
                        ? @"Toggle button pressed" 
                        : @"Toggle button NOT pressed");
                }).Pressed(() => true);

            cmds.AddDropDownCommand(BookmarksDropDownId)
                .ItemCounts(content.Count)
                .ItemsId(content.Ids)
                .ItemsLabel(content.Labels)
                .ItemsImage(() => content.Images())
                .ItemsSupertip(content.SuperTips)
                .Action(index =>
                { 
                    MessageBox.Show(@"Your selection:" + (index+1));
                });

            cmds.AddComboBoxCommand(BookmarksComboId)
                .ItemCounts(content.Count)
                .ItemsId(content.Ids)
                .ItemsLabel(content.Labels)
                .ItemsSupertip(content.SuperTips)
                .GetText(() => "Text")
                .OnChange((value) => MessageBox.Show(@"Your selection:" + value));
        }

        public override void OnClosing()
        {
            //AddinContext.ExcelApp.DisposeChildInstances(true);
            AddinContext.ExcelApp = null;
        }

        public override void OnOpening()
        {
            content = new ListItems();
            content.Add(new SingleItem
            {
                Label = "First Item"
                ,
                SuperTip = "The First Item"
                ,
                Image = ResizeImage.Resize(Properties.Resources.one, 16, 16)
            });
            content.Add(new SingleItem
            {
                Label = "Second Item"
                ,
                SuperTip = "The Second Item"
                ,
                Image = ResizeImage.Resize(Properties.Resources.two, 16, 16)
            });
            content.Add(new SingleItem
            {
                Label = "Third Item"
                ,
                SuperTip = "The Third Item"
                ,
                Image = ResizeImage.Resize(Properties.Resources.three, 16, 16)
            });
        }

    }
}