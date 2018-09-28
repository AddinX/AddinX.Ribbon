using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Control;
using AddinX.Ribbon.Contract.Enums;
using AddinX.Ribbon.Contract.Ribbon.Tab;
using AddinX.Ribbon.Contract.Ribbon.TabSet;
using AddinX.Ribbon.Implementation.Control;

namespace AddinX.Ribbon.Implementation.Ribbon {
    public class TabSet : AddInElement, ITabSet {
        private readonly TabSetTabs _tabs;
        private readonly IElementId _id;

        public TabSet() : base("tabSet") {
            _id = new ElementId();
            _tabs = new TabSetTabs();
        }

        protected internal override void SetRegister(ICallbackRigister register) {
            base.SetRegister(register);
            _tabs.SetRegister(register);
        }

        protected internal override XElement ToXml(XNamespace ns) {
            var tmpId = (ElementId) _id;

            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
            );

            element.AddControls((AddInList) _tabs, ns);
            return element;
        }

        public void Tabs(Action<ITabs> value) {
            value.Invoke(_tabs);
        }

        public ITabSetItem IdMso(TabSetId name) {
            _id.SetMicrosoftId(name.ToString());
            return this;
        }
    }
}