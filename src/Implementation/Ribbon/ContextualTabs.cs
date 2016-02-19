using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Ribbon;
using AddinX.Ribbon.Contract.Ribbon.TabSet;
using AddinX.Ribbon.Implementation.Control;

namespace AddinX.Ribbon.Implementation.Ribbon
{
    public class ContextualTabs : AddInElement, IContextualTabs
    {
        private readonly IList<ITabSet> items;

        public ContextualTabs()
        {
            ElementName = "contextualTabs";
            items = new List<ITabSet>();
        }

        public IContextualTabs AddTabSet(Action<ITabSetId> value)
        {
            var item = new TabSet();
            value.Invoke(item);
            items.Add(item);
            return this;
        }

        protected internal override XElement ToXml(XNamespace ns)
        {
            if (items == null || !items.Any())
            {
                return null;
            }
            return new XElement(ns + ElementName
                , items.Select(o => ((AddInElement) o).ToXml(ns))
                );
        }
    }
}