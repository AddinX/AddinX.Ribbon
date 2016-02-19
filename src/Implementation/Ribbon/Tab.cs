using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Control;
using AddinX.Ribbon.Contract.Ribbon.Group;
using AddinX.Ribbon.Contract.Ribbon.Tab;
using AddinX.Ribbon.Implementation.Control;

namespace AddinX.Ribbon.Implementation.Ribbon
{
    public class Tab : AddInElement, ITab
    {
        private readonly IGroups items;
        private string label = "";
        private IElementId id;
        private string keytip;

        public Tab()
        {
            ElementName = "tab";
            items = new Groups();
            id = new ElementId();
        }

        protected internal ITab SetLabel(string label)
        {
            this.label = label;
            return this;
        }

        public ITabItems SetId(string name)
        {
            id = new ElementId().SetId(name);
            return this;
        }

        public ITabItems SetIdMso(string name)
        {
            id = new ElementId().SetMicrosoftId(name);
            return this;
        }

        public ITabItems SetIdQ(string ns, string name)
        {
            id = new ElementId().SetNamespaceId(ns, name);
            return this;
        }


        public ITabExtra Groups(Action<IGroups> value)
        {
            value.Invoke(items);
            return this;
        }

        protected internal override XElement ToXml(XNamespace ns)
        {
            var tmpId = (ElementId)id;

            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                , new XAttribute("label", label)
                );
            if (!string.IsNullOrEmpty(keytip))
            {
                element.Add(new XAttribute("keytip", keytip));
            }

            if (((AddInList)items)?.ToXml(ns) != null)
            {
                element.Add(((AddInList)items).ToXml(ns));
            }
            return element;
        }

        public void Keytip(string keytip)
        {
            this.keytip = keytip;
        }
    }
}