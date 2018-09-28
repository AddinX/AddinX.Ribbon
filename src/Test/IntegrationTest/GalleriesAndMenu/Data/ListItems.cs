using System.Collections.Generic;
using System.Linq;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Implementation.Command;

namespace AddinX.Ribbon.IntegrationTest.GalleriesAndMenu.Data
{
    class ListItems
    {
        private readonly IDictionary<int, SingleItem> items;

        public ListItems()
        {
            items = new Dictionary<int, SingleItem>();
        }

        public void Add(SingleItem item)
        {
            items.Add(items.Count, item);
        }

        public int Count()
        {
            return items.Count;
        }

        public string Ids(int index) {
            return index.ToString();
        }

        public string Labels(int index)
        {
            return items[index].Label;
        }

        public object Images(int index)
        {
            return items[index].Image;
        }

        public string SuperTips(int index)
        {
            return items[index].SuperTip;
        }
    }

    public class ItemsCommandWarper {
        private List<SingleItem> _items;


        public ItemsCommandWarper(IEnumerable<SingleItem> items) {
            this._items = items.ToList();

        }

        public void Add(SingleItem item) {
            _items.Add(item);
        }

        public virtual void OnItemAction(int index) {

        }

        public int SelectedIndex { get; set; }

        public IDropDownCommand ToCommand() {
            return new DropDownCommand() {
                getItemCount = ()=>_items.Count,
                getItemID = i=>i.ToString(),
                getItemImage = i=>_items[i].Image,
                getItemSupertip =  i=>_items[i].SuperTip,
                getSelectedItemIndex = ()=>SelectedIndex,
                onItemAction = i=> {
                    SelectedIndex = i;
                    this.OnItemAction(i);
                }
            };
        }
    }
}