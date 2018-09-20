using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Ribbon.Tab;
using AddinX.Ribbon.Implementation.Control;

namespace AddinX.Ribbon.Implementation.Ribbon {
    public class Tabs : AddInElement, ITabs {
        private readonly IList<ITab> _items;
        private readonly ICallbackRigister _register;

        public Tabs(ICallbackRigister register) :base("tabs") {
            _register = register;
            _items = new List<ITab>();
        }

        public ITab AddTab(string label) {
            var tab = new Tab(_register).SetLabel(label);
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