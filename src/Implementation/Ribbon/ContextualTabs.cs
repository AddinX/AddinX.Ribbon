using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AddinX.Core.Contract.Ribbon;
using AddinX.Core.Contract.Ribbon.TabSet;
using AddinX.Core.Implementation.Control;

namespace AddinX.Core.Implementation.Ribbon
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