using System;
using System.Xml.Linq;
using AddinX.Core.Contract.Ribbon;
using AddinX.Core.Contract.Ribbon.Tab;
using AddinX.Core.Implementation.Control;

namespace AddinX.Core.Implementation.Ribbon
{
    public class RibbonUi : AddInElement, IRibbonUi
    {
        private readonly ITabsUi tabs;
        private bool startFromStrach;
        private readonly IContextualTabsUi contextTabs;

        public RibbonUi()
        {
            ElementName = "ribbon";
            startFromStrach = false;
            tabs = new TabsUi();
            contextTabs = new ContextualTabsUi();
        }

        public IRibbonUi StartFromStrach(bool value)
        {
            startFromStrach = value;
            return this;
        }

        public IRibbonUi Tabs(Action<ITabsUi> value)
        {
            value.Invoke(tabs);
            return this;
        }

        public IRibbonUi ContextualTabs(Action<IContextualTabsUi> value)
        {
            value.Invoke(contextTabs);
            return this;
        }

        protected internal override XElement ToXml(XNamespace ns)
        {
            var element = new XElement(ns + ElementName
                , new XAttribute("startFromScratch", startFromStrach.ToString().ToLower())
                );

            if (((AddInElement) tabs)?.ToXml(ns) != null)
            {
                element.Add(((AddInElement) tabs).ToXml(ns));
            }
            if (((AddInElement) contextTabs)?.ToXml(ns) != null)
            {
                element.Add(((AddInElement) contextTabs).ToXml(ns));
            }

            return element;
        }
    }
}