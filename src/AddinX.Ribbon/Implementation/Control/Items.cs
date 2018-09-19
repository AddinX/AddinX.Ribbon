using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Control.Item;

namespace AddinX.Ribbon.Implementation.Control {
    public class Items : AddInList, IItems {
        private readonly IList<IItem> _items;

        public Items() {
            _items = new List<IItem>();
        }

        public IItem AddItem(string label) {
            var item = new Item();
             item.SetLabel(label);
            _items.Add(item);
            return item;
        }

        protected internal override XElement[] ToXml(XNamespace ns) {
            return _items == null || !_items.Any()
                ? null
                : _items.Select(o => ((Control) o).ToXml(ns)).ToArray();
        }
    }
}