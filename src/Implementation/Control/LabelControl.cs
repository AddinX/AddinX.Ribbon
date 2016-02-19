using System.Xml.Linq;
using AddinX.Ribbon.Contract.Control.Label;

namespace AddinX.Ribbon.Implementation.Control
{
    public class LabelControl : Control, ILabelControl
    {
        private string supertip;
        private string screentip;

        public LabelControl()
        {
            ElementName = "labelControl";
            Id = new ElementId();
        }

        protected internal override XElement ToXml(XNamespace ns)
        {
            var tmpId = (ElementId) Id;

            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                , new XAttribute("getEnabled", "GetEnabled")
                , new XAttribute("getVisible", "GetVisible")
                , new XAttribute("getLabel", "GetLabel")
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

            return element;
        }

        protected internal ILabelControlId SetLabel(string value)
        {
            Label = value;
            return this;
        }

        public ILabelControlExtra SetId(string name)
        {
            Id = new ElementId().SetId(name);
            return this;
        }

        public ILabelControlExtra SetIdMso(string name)
        {
            Id = new ElementId().SetMicrosoftId(name);
            return this;
        }

        public ILabelControlExtra SetIdQ(string ns, string name)
        {
            Id = new ElementId().SetNamespaceId(ns, name);
            return this;
        }

        public ILabelControlExtra Supertip(string supertip)
        {
            this.supertip = supertip;
            return this;
        }

        public ILabelControlExtra Screentip(string screentip)
        {
            this.screentip = screentip;
            return this;
        }
    }
}