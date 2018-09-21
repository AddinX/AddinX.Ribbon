using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Control.MenuSeparator;

namespace AddinX.Ribbon.Implementation.Control {
    public class MenuSeparator : Control, IMenuSeparator {
        public MenuSeparator(): base( "menuSeparator") {
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
            Id.SetId(name);
            return this;
        }

        public IMenuSeparator SetIdQ(string ns, string name) {
            Id.SetNamespaceId(ns, name);
            return this;
        }
    }
}