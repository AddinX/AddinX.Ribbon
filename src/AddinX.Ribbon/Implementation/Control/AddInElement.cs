using System.Xml.Linq;

namespace AddinX.Ribbon.Implementation.Control {
    public abstract class AddInElement {

        protected AddInElement(string elementName) {
            ElementName = elementName;
        }

        protected internal string ElementName { get; }

        protected internal virtual XElement ToXml(XNamespace ns) {
            return new XElement(ns + ElementName);
        }
    }
}