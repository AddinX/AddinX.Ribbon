using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AddinX.Core.Contract.Ribbon;
using AddinX.Core.Contract.Ribbon.TabSet;
using AddinX.Core.Implementation.Control;

namespace AddinX.Core.Implementation.Ribbon
{
    public class ContextualTabsUi : AddInElement, IContextualTabsUi
    {
        private readonly IList<ITabSetUi> items;

        public ContextualTabsUi()
        {
            ElementName = "contextualTabs";
            items = new List<ITabSetUi>();
        }

        public IContextualTabsUi AddTabSet(Action<ITabSetUi> value)
        {
            var item = new TabSetUi();
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