using System;
using System.Xml.Linq;
using AddinX.Core.Contract.Control;
using AddinX.Core.Contract.Enums;
using AddinX.Core.Contract.Ribbon.Tab;
using AddinX.Core.Contract.Ribbon.TabSet;
using AddinX.Core.Implementation.Control;

namespace AddinX.Core.Implementation.Ribbon
{
    public class TabSet : AddInElement, ITabSet
    {
        private readonly ITabs tabs;
        private readonly IElementId id;

        public TabSet()
        {
            ElementName = "tabSet";
            id = new ElementId();
            tabs = new TabSetTabs();
        }

        protected internal override XElement ToXml(XNamespace ns)
        {
            var tmpId = (ElementId) id;

            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                );
            if (((AddInList) tabs)?.ToXml(ns) != null)
            {
                element.Add(((AddInList) tabs).ToXml(ns));
            }
            return element;
        }

        public void Tabs(Action<ITabs> value)
        {
            value.Invoke(tabs);
        }

        public ITabSetItem SetIdMso(TabSetId name)
        {
            id.SetMicrosoftId(name.ToString());
            return this;
        }
    }
}