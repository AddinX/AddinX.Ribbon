using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Ribbon.Tab;
using AddinX.Ribbon.Implementation.Control;

namespace AddinX.Ribbon.Implementation.Ribbon {
    public class Tabs : AddInElement, ITabs {
        private readonly IList<Tab> _items;

        public Tabs() : base("tabs") {
            _items = new List<Tab>();
        }

        protected internal override void SetRegister(ICallbackRigister register) {
            base.SetRegister(register);
            foreach (var item in _items) {
                item.SetRegister(register);
            }
        }

        public ITab AddTab(string label) {
            var tab = new Tab();
            tab.SetLabel(label);
            _items.Add(tab);
            return tab;
        }

        protected internal override XElement ToXml(XNamespace ns) {
            if (_items == null || !_items.Any()) {
                return null;
            }

            return new XElement(ns + ElementName
                , _items.Select(tab => tab.ToXml(ns))
            );
        }
    }
}