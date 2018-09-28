using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Control.Item;

namespace AddinX.Ribbon.Implementation.Control {
    public class Items : AddInList<Item>, IItems {
        public Items() {
        }

        public IItem AddItem(string label) {
            var item = new Item();
            item.SetLabel(label);
            InnerList.Add(item);
            return item;
        }

        protected internal override IEnumerable<XElement> ToXml(XNamespace ns) {
            return InnerList.Select(o => o.ToXml(ns));
        }
    }
}