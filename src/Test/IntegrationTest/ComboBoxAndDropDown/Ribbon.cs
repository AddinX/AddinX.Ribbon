using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AddinX.Core.Contract;
using AddinX.Core.Contract.Command;
using AddinX.Core.ExcelDna;
using AddIn.Core.IntegrationTest.ComboBoxAndDropDown.Utils;

namespace AddIn.Core.IntegrationTest.ComboBoxAndDropDown
{
    [ComVisible(true)]
    public class Ribbon : RibbonFluent
    {

        private const string BookmarksComboId = "bookmarksCombo";
        private const string BookmarksDropDownId = "BookmarksDropDownId";
        private const string MyTabId = "MyTabId";
        private const string DataGroupId = "DataGroupId";


        private ListItems content;
        private int dropDownSelectedIndex;

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
                                    .ShowItemLabel().ShowItemImage().DynamicItems();
                            });

                    });
            });
        }

        protected override void CreateRibbonCommand(IRibbonCommands cmds)
        {
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
                , SuperTip = "The First Item"
                , Image = ResizeImage.Resize(Properties.Resources.one, 16, 16)
            });
            content.Add(new SingleItem
            {
                Label = "Second Item"
                , SuperTip = "The Second Item"
                , Image = ResizeImage.Resize(Properties.Resources.two, 16, 16)
            });
            content.Add(new SingleItem
            {
                Label = "Third Item"
                , SuperTip = "The Third Item"
                , Image = ResizeImage.Resize(Properties.Resources.three, 16, 16)
            });

            dropDownSelectedIndex = 1;
        }

    }

    class ListItems
    {
        private readonly IDictionary<int, SingleItem> items;

        public ListItems()
        {
            items = new Dictionary<int, SingleItem>();
        }

        public void Add(SingleItem item)
        {
            items.Add(items.Count + 1, item);
        }

        public int Count()
        {
            return items.Count;
        }

        public IList<object> Ids()
        {
            return new object[] { items.Keys };
        }

        public IList<string> Labels()
        {
            return items.Values.Select(o => o.Label).ToList();
        }

        public IList<object> Images()
        {
            return items.Values.Select(o => o.Image).Cast<object>().ToList();
        }

        public IList<string> SuperTips()
        {
            return items.Values.Select(o => o.SuperTip).ToList();
        }
    }

    internal class SingleItem
    {
        public string Label { get; set; }

        public Bitmap Image { get; set; }

        public string SuperTip { get; set; }
    }
}