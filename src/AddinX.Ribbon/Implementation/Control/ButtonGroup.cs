using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Control.ButtonGroup;
using AddinX.Ribbon.Implementation.Ribbon;

namespace AddinX.Ribbon.Implementation.Control {
    public class ButtonGroup : Control, IButtonGroup {
        private readonly Controls _items;

        public ButtonGroup() {
            _items = new Controls();
            ElementName = "buttonGroup";
            Id = new ElementId();
        }

        protected internal override XElement ToXml(XNamespace ns) {
            var tmpId = (ElementId) Id;
            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                , new XAttribute("getVisible", "GetVisible")
            );

            if (_items.HasItems) {
                foreach (var item in _items.ToXml(ns)) {
                    element.Add(item);
                }
            }

            return element;
        }

        public IButtonGroup SetId(string name) {
            Id = new ElementId().SetId(name);
            return this;
        }

        public IButtonGroup SetIdMso(string name) {
            throw new NotImplementedException();
        }

        public IButtonGroup SetIdQ(string ns, string name) {
            Id = new ElementId().SetNamespaceId(ns, name);
            return this;
        }

        public IButtonGroup AddItems(Action<IButtonGroupControls> items) {
            items.Invoke(this._items);
            return this;
        }
    }
}