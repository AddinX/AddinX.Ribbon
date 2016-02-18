using System.Xml.Linq;
using AddinX.Core.Contract.Control.Separator;

namespace AddinX.Core.Implementation.Control
{
    public class Separator : Control, ISeparator
    {
        public Separator()
        {
            ElementName = "separator";
            Id = new ElementId();
        }

        protected internal override XElement ToXml(XNamespace ns)
        {
            var tmpId = (ElementId) Id;
            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                , new XAttribute("getVisible", "GetVisible")
                );

            return element;
        }

        public void SetId(string name)
        {
            Id = new ElementId().SetId(name);
        }

        public void SetIdQ(string ns, string name)
        {
            Id = new ElementId().SetNamespaceId(ns, name);
        }
    }
}