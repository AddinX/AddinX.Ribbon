using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AddinX.Core.Contract.Ribbon.Tab;
using AddinX.Core.Implementation.Control;

namespace AddinX.Core.Implementation.Ribbon
{
    public class TabSetTabsUi : AddInList, ITabsUi
    {
        private readonly IList<ITabUi> items;

        public TabSetTabsUi()
        {
            items = new List<ITabUi>();
        }

        public ITabIdUi AddTab(string label)
        {
            var tab = new TabUi().SetLabel(label);
            items.Add(tab);
            return tab;
        }

        protected internal override XElement[] ToXml(XNamespace ns)
        {
            if (items == null || !items.Any())
            {
                return null;
            }
            return items.Select(tab => ((AddInElement)tab).ToXml(ns)).ToArray();
        }
    }
}