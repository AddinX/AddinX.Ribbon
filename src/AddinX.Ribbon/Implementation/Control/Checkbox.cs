using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Control.CheckBox;
using AddinX.Ribbon.Implementation.Command;

namespace AddinX.Ribbon.Implementation.Control {
    public class Checkbox : Control, ICheckbox {
        private string _description;
        private string _supertip;
        private string _screentip;
        private string _keytip;

        public Checkbox(ICallbackRigister register) : base(register, "checkBox") {
        }

        public ICheckbox SetId(string name) {
            Id = new ElementId().SetId(name);
            return this;
        }

        public ICheckbox SetIdMso(string name) {
            Id = new ElementId().SetMicrosoftId(name);
            return this;
        }

        public ICheckbox SetIdQ(string ns, string name) {
            Id = new ElementId().SetNamespaceId(ns, name);
            return this;
        }

        public ICheckbox Description(string description) {
            _description = description;
            return this;
        }

        public ICheckbox Supertip(string supertip) {
            _supertip = supertip;
            return this;
        }

        public ICheckbox Keytip(string keytip) {
            _keytip = keytip;
            return this;
        }

        public ICheckbox Screentip(string screentip) {
            _screentip = screentip;
            return this;
        }

        protected internal override XElement ToXml(XNamespace ns) {
            var element = base.ToXml(ns); //new XElement(ns + ElementName
                                          //, new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                                          //, new XAttribute("label", Label)
                                          //, new XAttribute("getEnabled", "GetEnabled")
                                          //, new XAttribute("getVisible", "GetVisible")
                                          //, new XAttribute("onAction", "OnActionPressed")
                                          //, new XAttribute("getPressed", "GetPressed")
                                          //, new XAttribute("tag", tmpId.Value)
                                          //);

            element.AddAttribute("screentip", _screentip);
            element.AddAttribute("supertip", _supertip);
            element.AddAttribute("keytip", _keytip);
            element.AddAttribute("description", _description);

            return element;
        }

        #region Implementation of IRibbonCallback<out ICheckBoxCommand>

        public ICheckbox Callback(Action<ICheckBoxCommand> builder) {
            builder(GetCommand<CheckBoxCommand>());
            return this;
        }

        #endregion
    }
}