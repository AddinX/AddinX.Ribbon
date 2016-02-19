using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Control.Box;
using AddinX.Ribbon.Contract.Enums;
using AddinX.Ribbon.Implementation.Ribbon;

namespace AddinX.Ribbon.Implementation.Control
{
    public class Box : Control, IBox
    {
        private readonly IBoxControls items;
        private BoxStyle style;

        public Box()
        {
            items = new Controls();
            ElementName = "box";
            Id = new ElementId();
        }

        public IBoxStyle SetId(string name)
        {
            Id.SetId(name);
            return this;
        }

        public IBoxStyle SetIdQ(string ns, string name)
        {
            Id.SetNamespaceId(ns, name);
            return this;
        }

        public IBoxItems HorizontalDisplay()
        {
            style = BoxStyle.horizontal;
            return this;
        }

        public IBoxItems VerticalDisplay()
        {
            style = BoxStyle.vertical;
            return this;
        }

        public void AddItems(Action<IBoxControls> items)
        {
            items.Invoke(this.items);
        }

        protected internal override XElement ToXml(XNamespace ns)
        {
            var tmpId = (ElementId) Id;
            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                , new XAttribute("getVisible", "GetVisible")
                , new XAttribute("boxStyle", style.ToString())
                );

            if (((AddInList) items)?.ToXml(ns) != null)
            {
                element.Add(((AddInList) items).ToXml(ns));
            }
            return element;
        }
    }
}