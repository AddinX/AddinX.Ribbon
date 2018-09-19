using System.Xml.Linq;
using AddinX.Ribbon.Contract.Control.MenuSeparator;

namespace AddinX.Ribbon.Implementation.Control {
    public class MenuSeparator : Control, IMenuSeparator {
        public MenuSeparator() {
            ElementName = "menuSeparator";
            Id = new ElementId();
        }

        protected internal override XElement ToXml(XNamespace ns) {
            var tmpId = (ElementId) Id;
            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
            );

            if (!string.IsNullOrEmpty(Label)) {
                element.Add(new XAttribute("title", Label));
            }

            return element;
        }

        public IMenuSeparator SetId(string name) {
            Id = new ElementId().SetId(name);
            return this;
        }

        public IMenuSeparator SetIdQ(string ns, string name) {
            Id = new ElementId().SetNamespaceId(ns, name);
            return this;
        }
    }
}