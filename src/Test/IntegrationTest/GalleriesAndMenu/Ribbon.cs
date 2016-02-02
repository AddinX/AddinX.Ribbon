using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AddinX.Core.Contract;
using AddinX.Core.Contract.Command;
using AddinX.Core.ExcelDna;
using AddIn.Core.IntegrationTest.GalleriesAndMenu.Utils;

namespace AddIn.Core.IntegrationTest.GalleriesAndMenu
{
    [ComVisible(true)]
    public class Ribbon : RibbonFluent
    {
        private const string HappyButtonId = "HappyButton1";
        private const string ShowNumberId = "ShowNumberId1";
        private const string HappyButtonId2 = "HappyButton2";
        private const string ShowNumberId2 = "ShowNumberId2";
        private const string MyTabId = "MyTabId";
        private const string DataGroupId = "DataGroupId";
        private const string OptionId = "OptionId";
        private const string GalleryId = "GalleryId";
        private const string DynamicGalleryId = "DynamicGalleryId";

        private ListItems content;
        private int GallerySelectedIndex;
        private bool checkboxPressed;

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
                                d.AddMenu("Option").SetId(OptionId).ShowLabel()
                                    .ImageMso("FileNew").LargeSize()
                                    .ItemLargeSize().AddItems(
                                        v =>
                                        {
                                            v.AddCheckbox("Show numbers").SetId(ShowNumberId);
                                            v.AddSeparator("Mood");
                                            v.AddBouton("Happy")
                                                .SetId(HappyButtonId)
                                                .ImageMso("HappyFace");
                                            v.AddGallery("Dynamic Option").SetId(DynamicGalleryId)
                                                .ShowLabel().NoImage().ShowItemLabel().ShowItemImage()
                                                .DynamicItems().NumberRows(6).NumberColumns(1);
                                        });
                                d.AddGallery("Multi Option").SetId(GalleryId)
                                    .ShowLabel().NoImage().ShowItemLabel().ShowItemImage()
                                    .AddItems(v =>
                                    {
                                        v.AddItem("Show numbers").SetId(ShowNumberId2);
                                        v.AddItem("Happy").SetId(HappyButtonId2).ImageMso("HappyFace");
                                    });

                               
                            });

                    });
            });
        }

        protected override void CreateRibbonCommand(IRibbonCommands cmds)
        {
            cmds.AddButtonCommand(HappyButtonId).Action(() => MessageBox.Show("Be Happy !!!"));
            cmds.AddCheckBoxCommand(ShowNumberId).Action(isPressed =>
            {
                checkboxPressed = isPressed;
                Ribbon.InvalidateControl(DynamicGalleryId);
                MessageBox.Show(isPressed ? "Show number pressed" : "Show number NOT pressed");
            });

            cmds.AddGalleryCommand(GalleryId).Action(position =>
            {
                switch (position)
                {
                    case 0:
                        MessageBox.Show("Option: Show number Clicked");
                        return;
                    case 1:
                        MessageBox.Show("Option: Be Happy !!!");
                        return;
                }
            });

            cmds.AddGalleryCommand(DynamicGalleryId)
                .IsEnabled(()=>checkboxPressed)
                .ItemCounts(content.Count)
                .ItemsId(content.Ids)
                .ItemsLabel(content.Labels)
                .ItemsImage(() => content.Images())
                .ItemsSupertip(content.SuperTips)
                .ItemSelectionIndex(() => GallerySelectedIndex)
                .Action(i =>
                {
                    GallerySelectedIndex = i;
                    MessageBox.Show(@"Your selection: " + (GallerySelectedIndex+1));
                });
        }

        public override void OnClosing()
        {
            AddinContext.ExcelApp.SheetChangeEvent -= (a, e) => Ribbon.Invalidate();
            AddinContext.ExcelApp.DisposeChildInstances(true);
            AddinContext.ExcelApp = null;
        }

        public override void OnOpening()
        {
            AddinContext.ExcelApp.SheetChangeEvent +=(a,e)=> Ribbon.Invalidate();

            content = new ListItems();
            content.Add(new SingleItem
            {
                Label = "First Item"
                ,
                SuperTip = "The first Item"
                ,
                Image = ResizeImage.Resize(Properties.Resources.one, 16, 16)
            });
            content.Add(new SingleItem
            {
                Label = "Second Item"
                ,
                SuperTip = "The second Item"
                ,
                Image = ResizeImage.Resize(Properties.Resources.two, 16, 16)
            });
            content.Add(new SingleItem
            {
                Label = "Third Item"
                ,
                SuperTip = "The third Item"
                ,
                Image = ResizeImage.Resize(Properties.Resources.three, 16, 16)
            });
            content.Add(new SingleItem
            {
                Label = "Fourth Item"
                ,
                SuperTip = "The fourth Item"
                ,
                Image = ResizeImage.Resize(Properties.Resources.four, 16, 16)
            });
            content.Add(new SingleItem
            {
                Label = "Fifth Item"
                ,
                SuperTip = "The fifth Item"
                ,
                Image = ResizeImage.Resize(Properties.Resources.five, 16, 16)
            });

            GallerySelectedIndex = 0;
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