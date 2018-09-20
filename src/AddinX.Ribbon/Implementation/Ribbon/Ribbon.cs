using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Ribbon;
using AddinX.Ribbon.Contract.Ribbon.Tab;
using AddinX.Ribbon.Implementation.Control;

namespace AddinX.Ribbon.Implementation.Ribbon {
    public class Ribbon : AddInElement, IRibbon {
        private ITabs _tabs;
        private bool _startFromStrach;
        private IContextualTabs _contextTabs;
        private readonly ICallbackRigister _register;

        public Ribbon(ICallbackRigister register) :base("ribbon") {
            _register = register;
            _startFromStrach = false;
        }

        public IRibbon StartFromStrach(bool value) {
            _startFromStrach = value;
            return this;
        }

        public IRibbon Tabs(Action<ITabs> value) {
            if (_tabs == null) {
                _tabs = new Tabs(_register);
            }
            value.Invoke(_tabs);
            return this;
        }

        public IRibbon ContextualTabs(Action<IContextualTabs> value) {
            if (_contextTabs == null) {
                _contextTabs = new ContextualTabs(_register);
            }
            value.Invoke(_contextTabs);
            return this;
        }

        protected internal override XElement ToXml(XNamespace ns) {
            var element = new XElement(ns + ElementName);
            element.AddAttribute("startFromScratch", _startFromStrach);

            if (_tabs is AddInElement addins) {
                element.Add(addins.ToXml(ns));
            }

            if (_contextTabs is AddInElement context) {
                element.Add(context.ToXml(ns));
            }

            return element;
        }
    }
}