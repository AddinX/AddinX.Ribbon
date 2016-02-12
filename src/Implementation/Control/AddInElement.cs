using System.Xml.Linq;

namespace AddinX.Core.Implementation.Control
{
    public abstract class AddInElement
    {
        protected internal string ElementName;

        protected internal abstract XElement ToXml(XNamespace ns);
    }
}