using System.Runtime.InteropServices;
using System.Windows.Forms;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.ExcelDna;
using AddinX.Ribbon.Implementation;
using AddinX.Ribbon.IntegrationTest.ComboBoxAndDropDown.Data;
using AddinX.Ribbon.IntegrationTest.ComboBoxAndDropDown.Utils;

namespace AddinX.Ribbon.IntegrationTest.ComboBoxAndDropDown {
    [ComVisible(true)]
    public class Ribbon : RibbonFluent {
        private const string BookmarksComboId = "bookmarksCombo";
        private const string BookmarksDropDownId = "BookmarksDropDownId";
        private const string MyTabId = "MyTabId";
        private const string DataGroupId = "DataGroupId";
        private const string ButtonMore = "buttonMore";
        private const string ToggleButtonId = "ToggleButtonId";
        private ListItems _content;
        private readonly RibbonCommands _commands = new RibbonCommands();

        public Ribbon() {
        }

        protected override void CreateFluentRibbon(IRibbonBuilder builder) {
            builder.CustomUi.AddNamespace("acme", "acme.addin.sync").Ribbon.Tabs(c => {
                c.AddTab("My Tab").IdQ("acme", MyTabId)
                    .Groups(g => {
                        g.AddGroup("Data").IdQ("acme", DataGroupId)
                            .Items(d => {
                                d.AddButton("My Save").IdMso("FileSave").NormalSize().ImageMso("FileSave")
                                    .Callback((IButtonCommand) _commands.Find("FileSave"));
                                d.AddButton("Button").Id("buttonOne");
                                d.AddComboBox("numbers")
                                    .Id(BookmarksComboId)
                                    .ShowLabel().NoImage()
                                    .DynamicItems()
                                    .Callback((IComboBoxCommand) _commands.Find("numbers"));

                                d.AddDropDown("With Image")
                                    .Id(BookmarksDropDownId)
                                    .ShowLabel().NoImage()
                                    .ShowItemLabel().ShowItemImage().DynamicItems()
                                    .Buttons(b => b.AddButton("Button...").Id(ButtonMore))
                                    .Callback((IDropDownCommand) _commands.Find(BookmarksDropDownId));

                                d.AddToggleButton("Toggle Button")
                                    .Id(ToggleButtonId)
                                    .Callback((IToggleButtonCommand) _commands.Find(ToggleButtonId));
                            });
                    });
            });
        }


        protected void CreateRibbonCommand(IRibbonCommands cmds) {
            cmds.AddButtonCommand(ButtonMore).OnAction(() => MessageBox.Show(@"More..."));

            cmds.AddToggleButtonCommand(ToggleButtonId).OnPressed(isPressed => {
                MessageBox.Show(isPressed
                    ? @"Toggle button pressed"
                    : @"Toggle button NOT pressed");
            });

            cmds.AddDropDownCommand(BookmarksDropDownId)
                .GetItemCount(_content.Count)
                .GetItemId(i => _content.Ids(i))
                .GetItemLabel(i => _content.Labels(i))
                .GetItemImage(i => _content.Images(i))
                .GetItemSupertip(_content.SuperTips)
                .OnItemAction(index => { MessageBox.Show(@"Your selection:" + (index + 1)); });

            cmds.AddComboBoxCommand(BookmarksComboId)
                .GetItemCount(_content.Count)
                .GetItemId(i => _content.Ids(i))
                .GetItemLabel(i => _content.Labels(i))
                .GetItemSupertip(_content.SuperTips)
                .GetText(() => "Text")
                .OnChange((value) => MessageBox.Show(@"Your selection:" + value));
        }

        public override void OnClosing() {
            AddinContext.ExcelApp.DisposeChildInstances(true);
            AddinContext.ExcelApp = null;
        }

        public override void OnOpening() {
            _content = new ListItems();
            _content.Add(new SingleItem {
                Label = "First Item",
                SuperTip = "The First Item",
                Image = ResizeImage.Resize(Properties.Resources.one, 16, 16)
            });
            _content.Add(new SingleItem {
                Label = "Second Item",
                SuperTip = "The Second Item",
                Image = ResizeImage.Resize(Properties.Resources.two, 16, 16)
            });
            _content.Add(new SingleItem {
                Label = "Third Item",
                SuperTip = "The Third Item",
                Image = ResizeImage.Resize(Properties.Resources.three, 16, 16)
            });

            this.CreateRibbonCommand(_commands);
        }
    }
}