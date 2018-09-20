using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Control;
using AddinX.Ribbon.Contract.Ribbon.Group;
using AddinX.Ribbon.Contract.Ribbon.Tab;
using AddinX.Ribbon.Implementation.Control;

namespace AddinX.Ribbon.Implementation.Ribbon {
    public class Tab : AddInElement, ITab {
        private readonly IGroups _items;
        private string _label = "";
        private IElementId _id;
        private string _keytip;

        public Tab(ICallbackRigister register) : base("tab"){
            _id = new ElementId();
            _items = new Groups(register);
            
        }

        protected internal ITab SetLabel(string label) {
            _label = label;
            return this;
        }

        public ITabItems SetId(string name) {
            _id = new ElementId().SetId(name);
            return this;
        }

        public ITabItems SetIdMso(string name) {
            _id = new ElementId().SetMicrosoftId(name);
            return this;
        }

        public ITabItems SetIdQ(string ns, string name) {
            _id = new ElementId().SetNamespaceId(ns, name);
            return this;
        }


        public ITabExtra Groups(Action<IGroups> value) {
            value.Invoke(_items);
            return this;
        }

        protected internal override XElement ToXml(XNamespace ns) {
            var tmpId = (ElementId) _id;

            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                , new XAttribute("label", _label)
            );
            if (!string.IsNullOrEmpty(_keytip)) {
                element.Add(new XAttribute("keytip", _keytip));
            }

            if (_items is AddInList groups) {
                var children = groups.ToXml(ns);
                if (children != null) {
                    foreach (var child in children) {
                        element.Add(child);
                    }
                }
            }

            return element;
        }

        public void Keytip(string keytip) {
            _keytip = keytip;
        }
    }
}