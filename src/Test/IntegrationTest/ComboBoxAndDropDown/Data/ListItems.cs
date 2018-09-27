using System.Collections.Generic;
using System.Linq;

namespace AddinX.Ribbon.IntegrationTest.ComboBoxAndDropDown.Data
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
            items.Add(items.Count + 1, item);
        }

        public int Count()
        {
            return items.Count;
        }

        public string Ids(int index){
            //return new object[] { items.Keys };
            return items.Keys.ElementAt(index).ToString();
        }

        public string Labels(int index)
        {
            return items.Values.ElementAt(index).Label;
        }

        public object Images(int index)
        {
            return items.Values.ElementAt(index).Image;
        }

        public string SuperTips(int index){
            return items.Values.ElementAt(index).SuperTip;
        }
    }
}