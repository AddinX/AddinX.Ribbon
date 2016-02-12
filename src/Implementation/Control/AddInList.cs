using System.Xml.Linq;

namespace AddinX.Core.Implementation.Control
{
    public abstract class AddInList
    {
        protected internal abstract XElement[] ToXml(XNamespace ns);
    }
}