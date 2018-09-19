using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Ribbon.Tab;
using AddinX.Ribbon.Implementation.Control;

namespace AddinX.Ribbon.Implementation.Ribbon {
    public class TabSetTabs : AddInList, ITabs {
        private readonly IList<ITab> _items;

        public TabSetTabs() {
            _items = new List<ITab>();
        }

        public ITabId AddTab(string label) {
            var tab = new Tab().SetLabel(label);
            _items.Add(tab);
            return tab;
        }

        protected internal override XElement[] ToXml(XNamespace ns) {
            if (_items == null || !_items.Any()) {
                return null;
            }

            return _items.Select(tab => ((AddInElement) tab).ToXml(ns)).ToArray();
        }
    }
}