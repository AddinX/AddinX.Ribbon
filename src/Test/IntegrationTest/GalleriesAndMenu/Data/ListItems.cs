using System.Collections.Generic;
using System.Linq;

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
}