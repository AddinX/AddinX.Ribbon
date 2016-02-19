using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Control.Item;

namespace AddinX.Ribbon.Implementation.Control
{
    public class Items : AddInList, IItems
    {
        private readonly IList<IItem> items;

        public Items()
        {
            items = new List<IItem>();
        }

        public IItem AddItem(string label)
        {
            var item = new Item().SetLabel(label) as IItem;
            items.Add(item);
            return item;
        }

        protected internal override XElement[] ToXml(XNamespace ns)
        {
            return items == null || !items.Any()
                ? null
                : items.Select(o => ((Control)o).ToXml(ns)).ToArray();
        }
    }
}