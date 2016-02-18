using System.Xml.Linq;
using AddinX.Core.Contract.Control.MenuSeparator;

namespace AddinX.Core.Implementation.Control
{
    public class MenuSeparator : Control, IMenuSeparator
    {
        public MenuSeparator()
        {
            ElementName = "menuSeparator";
            Id = new ElementId();
        }

        protected internal IMenuSeparatorId SetLabel(string value)
        {
            Label = value;
            return this;
        }

        protected internal override XElement ToXml(XNamespace ns)
        {
            var tmpId = (ElementId) Id;
            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                );

            if (!string.IsNullOrEmpty(Label))
            {
                element.Add(new XAttribute("title", Label));
            }

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