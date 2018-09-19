using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Ribbon;
using AddinX.Ribbon.Contract.Ribbon.Tab;
using AddinX.Ribbon.Implementation.Control;

namespace AddinX.Ribbon.Implementation.Ribbon {
    public class Ribbon : AddInElement, IRibbon {
        private readonly ITabs _tabs;
        private bool _startFromStrach;
        private readonly IContextualTabs _contextTabs;

        public Ribbon() {
            ElementName = "ribbon";
            _startFromStrach = false;
            _tabs = new Tabs();
            _contextTabs = new ContextualTabs();
        }

        public IRibbon StartFromStrach(bool value) {
            _startFromStrach = value;
            return this;
        }

        public IRibbon Tabs(Action<ITabs> value) {
            value.Invoke(_tabs);
            return this;
        }

        public IRibbon ContextualTabs(Action<IContextualTabs> value) {
            value.Invoke(_contextTabs);
            return this;
        }

        protected internal override XElement ToXml(XNamespace ns) {
            var element = new XElement(ns + ElementName
                , new XAttribute("startFromScratch", _startFromStrach)
            );

            if (((AddInElement) _tabs)?.ToXml(ns) != null) {
                element.Add(((AddInElement) _tabs).ToXml(ns));
            }

            if (((AddInElement) _contextTabs)?.ToXml(ns) != null) {
                element.Add(((AddInElement) _contextTabs).ToXml(ns));
            }

            return element;
        }
    }
}