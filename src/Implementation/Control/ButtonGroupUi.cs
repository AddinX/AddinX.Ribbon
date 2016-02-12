using System;
using System.Xml.Linq;
using AddinX.Core.Contract.Control.ButtonGroup;
using AddinX.Core.Implementation.Ribbon;

namespace AddinX.Core.Implementation.Control
{
    public class ButtonGroupUi : ControlUi, IButtonGroupUi
    {
        private readonly IButtonGroupControlsUi items;

        public ButtonGroupUi()
        {
            items = new ControlsUi();
            ElementName = "buttonGroup";
            Id = new ElementId();
        }

        protected internal override XElement ToXml(XNamespace ns)
        {
            var tmpId = (ElementId)Id;
            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                , new XAttribute("getVisible", "GetVisible")
                );

            if (((AddInList)items)?.ToXml(ns) != null)
            {
                element.Add(((AddInList)items).ToXml(ns));
            }
            return element;
        }

        public IButtonGroupItems SetId(string name)
        {
            Id = new ElementId().SetId(name);
            return this;
        }

        public IButtonGroupItems SetIdQ(string ns, string name)
        {
            Id = new ElementId().SetNamespaceId(ns, name);
            return this;
        }

        public void AddItems(Action<IButtonGroupControlsUi> items)
        {
            items.Invoke(this.items);
        }
    }
}