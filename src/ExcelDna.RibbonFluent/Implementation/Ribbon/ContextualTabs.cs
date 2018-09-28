using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Ribbon;
using AddinX.Ribbon.Contract.Ribbon.TabSet;
using AddinX.Ribbon.Implementation.Control;

namespace AddinX.Ribbon.Implementation.Ribbon {
    public class ContextualTabs : AddInElement, IContextualTabs {
        private readonly IList<TabSet> _items;

        public ContextualTabs() : base("contextualTabs") {
            _items = new List<TabSet>();
        }

        public IContextualTabs AddTabSet(Action<ITabSetId> value) {
            var item = new TabSet();
            value.Invoke(item);
            _items.Add(item);
            return this;
        }

        protected internal override void SetRegister(ICallbackRigister register) {
            base.SetRegister(register);
            foreach (var item in _items) {
                item.SetRegister(register);
            }
        }

        protected internal override XElement ToXml(XNamespace ns) {
            if (_items == null || !_items.Any()) {
                return null;
            }

            return new XElement(ns + ElementName
                , _items.Select(o => ((AddInElement) o).ToXml(ns))
            );
        }
    }
}