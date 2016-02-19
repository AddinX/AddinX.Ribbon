using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Ribbon.Tab;
using AddinX.Ribbon.Implementation.Control;

namespace AddinX.Ribbon.Implementation.Ribbon
{
    public class Tabs : AddInElement, ITabs
    {
        private readonly IList<ITab> items;

        public Tabs()
        {
            ElementName = "tabs";
            items = new List<ITab>();
        }

        public ITabId AddTab(string label)
        {
            var tab = new Tab().SetLabel(label);
            items.Add(tab);
            return tab;
        }

        protected internal override XElement ToXml(XNamespace ns)
        {
            if (items==null || !items.Any())
            {
                return null;
            }
            return new XElement(ns + ElementName
                , items.Select(tab => ((AddInElement) tab).ToXml(ns))
                );
        }
    }
}