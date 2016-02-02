using System.Xml.Linq;
using AddinX.Core.Contract.Control.CheckBox;

namespace AddinX.Core.Implementation.Control
{
    public class CheckboxUi : ControlUi, ICheckboxUi
    {
        private string description;
        private string supertip;
        private string screentip;
        private string keytip;

        public CheckboxUi()
        {
            ElementName = "checkBox";
            Id = new ElementId();
        }

        protected internal ICheckboxIdUi SetLabel(string value)
        {
            Label = value;
            return this;
        }

        public ICheckboxExtra SetId(string name)
        {
            Id = new ElementId().SetId(name);
            return this;
        }

        public ICheckboxExtra SetIdMso(string name)
        {
            Id = new ElementId().SetMicrosoftId(name);
            return this;
        }

        public ICheckboxExtra SetIdQ(string ns, string name)
        {
            Id = new ElementId().SetNamespaceId(ns, name);
            return this;
        }

        public ICheckboxExtra Description(string description)
        {
            this.description = description;
            return this;
        }

        public ICheckboxExtra Supertip(string supertip)
        {
            this.supertip = supertip;
            return this;
        }

        public ICheckboxExtra Keytip(string keytip)
        {
            this.keytip = keytip;
            return this;
        }

        public ICheckboxExtra Screentip(string screentip)
        {
            this.screentip = screentip;
            return this;
        }

        protected internal override XElement ToXml(XNamespace ns)
        {
            var tmpId = (ElementId) Id;

            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                , new XAttribute("label", Label)
                , new XAttribute("getEnabled", "GetEnabled")
                , new XAttribute("getVisible", "GetVisible")
                , new XAttribute("onAction", "OnActionPressed")
                , new XAttribute("getPressed", "GetPressed")
                , new XAttribute("tag", tmpId.Value)
                );

            if (!string.IsNullOrEmpty(screentip))
            {
                element.Add(new XAttribute("screentip", screentip));
            }

            if (!string.IsNullOrEmpty(supertip))
            {
                element.Add(new XAttribute("supertip", supertip));
            }

            if (!string.IsNullOrEmpty(keytip))
            {
                element.Add(new XAttribute("keytip", keytip));
            }

            if (!string.IsNullOrEmpty(description))
            {
                element.Add(new XAttribute("description", description));
            }

            return element;
        }
    }
}