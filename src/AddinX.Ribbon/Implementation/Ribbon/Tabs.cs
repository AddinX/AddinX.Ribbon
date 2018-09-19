using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Ribbon.Tab;
using AddinX.Ribbon.Implementation.Control;

namespace AddinX.Ribbon.Implementation.Ribbon {
    public class Tabs : AddInElement, ITabs {
        private readonly IList<ITab> _items;

        public Tabs() {
            ElementName = "tabs";
            _items = new List<ITab>();
        }

        public ITabId AddTab(string label) {
            var tab = new Tab().SetLabel(label);
            _items.Add(tab);
            return tab;
        }

        protected internal override XElement ToXml(XNamespace ns) {
            if (_items == null || !_items.Any()) {
                return null;
            }

            return new XElement(ns + ElementName
                , _items.Select(tab => ((AddInElement) tab).ToXml(ns))
            );
        }
    }
}