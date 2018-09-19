using System.Xml.Linq;

namespace AddinX.Ribbon.Implementation.Control {
    public abstract class AddInElement {
        protected internal string ElementName;

        protected internal virtual XElement ToXml(XNamespace ns) {

            return new XElement(ns + ElementName);
        }
    }
}