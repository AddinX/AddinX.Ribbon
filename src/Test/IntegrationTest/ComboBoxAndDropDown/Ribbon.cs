using System.Runtime.InteropServices;
using System.Windows.Forms;
using AddinX.Core.Contract;
using AddinX.Core.Contract.Command;
using AddinX.Core.ExcelDna;
using AddinX.Core.IntegrationTest.ComboBoxAndDropDown.Data;
using AddinX.Core.IntegrationTest.ComboBoxAndDropDown.Utils;

namespace AddinX.Core.IntegrationTest.ComboBoxAndDropDown
{
    [ComVisible(true)]
    public class Ribbon : RibbonFluent
    {

        private const string BookmarksComboId = "bookmarksCombo";
        private const string BookmarksDropDownId = "BookmarksDropDownId";
        private const string MyTabId = "MyTabId";
        private const string DataGroupId = "DataGroupId";
        private const string ButtonMore = "buttonMore";


        private ListItems content;
        private int dropDownSelectedIndex = 1;

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
                                d.AddComboBox("numbers")
                                    .SetId(BookmarksComboId)
                                    .ShowLabel().NoImage()
                                    .DynamicItems();

                                d.AddDropDown("With Image")
                                    .SetId(BookmarksDropDownId)
                                    .ShowLabel().NoImage()
                                    .ShowItemLabel().ShowItemImage().DynamicItems()
                                    .AddButtons(b=> b.AddButton("Button...").SetId(ButtonMore));
                            });

                    });
            });
        }

        protected override void CreateRibbonCommand(IRibbonCommands cmds)
        {
            cmds.AddButtonCommand(ButtonMore).Action(() => MessageBox.Show(@"More..."));

            cmds.AddDropDownCommand(BookmarksDropDownId)
                .ItemCounts(content.Count)
                .ItemsId(content.Ids)
                .ItemsLabel(content.Labels)
                .ItemsImage(() => content.Images())
                .ItemsSupertip(content.SuperTips)
                .ItemSelectionIndex(() => dropDownSelectedIndex)
                .Action(i =>
                {
                    dropDownSelectedIndex = i;
                    MessageBox.Show(@"Your selection:" + dropDownSelectedIndex);
                });

            cmds.AddComboBoxCommand(BookmarksComboId)
                .ItemCounts(content.Count)
                .ItemsId(content.Ids)
                .ItemsLabel(content.Labels)
                .ItemsSupertip(content.SuperTips)
                .GetText(() => "Select a value")
                .OnChange((value) => MessageBox.Show(@"Your selection:" + value));
        }

        public override void OnClosing()
        {
            AddinContext.ExcelApp.DisposeChildInstances(true);
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