using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Ribbon;
using AddinX.Ribbon.Contract.Ribbon.Tab;
using AddinX.Ribbon.Implementation.Control;

namespace AddinX.Ribbon.Implementation.Ribbon
{
    public class Ribbon : AddInElement, IRibbon
    {
        private readonly ITabs tabs;
        private bool startFromStrach;
        private readonly IContextualTabs contextTabs;

        public Ribbon()
        {
            ElementName = "ribbon";
            startFromStrach = false;
            tabs = new Tabs();
            contextTabs = new ContextualTabs();
        }

        public IRibbon StartFromStrach(bool value)
        {
            startFromStrach = value;
            return this;
        }

        public IRibbon Tabs(Action<ITabs> value)
        {
            value.Invoke(tabs);
            return this;
        }

        public IRibbon ContextualTabs(Action<IContextualTabs> value)
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