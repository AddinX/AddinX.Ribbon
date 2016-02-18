using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AddinX.Core.Contract.Ribbon.Tab;
using AddinX.Core.Implementation.Control;

namespace AddinX.Core.Implementation.Ribbon
{
    public class TabSetTabs : AddInList, ITabs
    {
        private readonly IList<ITab> items;

        public TabSetTabs()
        {
            items = new List<ITab>();
        }

        public ITabId AddTab(string label)
        {
            var tab = new Tab().SetLabel(label);
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