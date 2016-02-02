using System;
using System.Xml.Linq;
using AddinX.Core.Contract.Control;
using AddinX.Core.Contract.Ribbon.Group;
using AddinX.Core.Contract.Ribbon.Tab;
using AddinX.Core.Implementation.Control;

namespace AddinX.Core.Implementation.Ribbon
{
    public class TabUi : AddInElement, ITabUi
    {
        private readonly IGroupsUi items;
        private string label = "";
        private IElementId id;
        private string keytip;

        public TabUi()
        {
            ElementName = "tab";
            items = new GroupsUi();
            id = new ElementId();
        }

        protected internal ITabUi SetLabel(string label)
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


        public ITabExtra Groups(Action<IGroupsUi> value)
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