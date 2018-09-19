using System.Xml.Linq;

namespace AddinX.Ribbon.Implementation.Control {
    public abstract class AddInList {
        protected internal abstract XElement[] ToXml(XNamespace ns);
    }
}