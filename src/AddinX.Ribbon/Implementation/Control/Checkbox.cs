using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;
using AddinX.Ribbon.Contract.Control.CheckBox;

namespace AddinX.Ribbon.Implementation.Control {
    public class Checkbox : Control, ICheckbox {
        private string _description;
        private string _supertip;
        private string _screentip;
        private string _keytip;

        public Checkbox() {
            ElementName = "checkBox";
            Id = new ElementId();
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
            this._description = description;
            return this;
        }

        public ICheckbox Supertip(string supertip) {
            this._supertip = supertip;
            return this;
        }

        public ICheckbox Keytip(string keytip) {
            this._keytip = keytip;
            return this;
        }

        public ICheckbox Screentip(string screentip) {
            this._screentip = screentip;
            return this;
        }

        protected internal override XElement ToXml(XNamespace ns) {
            var tmpId = (ElementId) Id;

            var element = base.ToXml(ns); //new XElement(ns + ElementName
                //, new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                //, new XAttribute("label", Label)
                //, new XAttribute("getEnabled", "GetEnabled")
                //, new XAttribute("getVisible", "GetVisible")
                //, new XAttribute("onAction", "OnActionPressed")
                //, new XAttribute("getPressed", "GetPressed")
                //, new XAttribute("tag", tmpId.Value)
            //);

            if (!string.IsNullOrEmpty(_screentip)) {
                element.Add(new XAttribute("screentip", _screentip));
            }

            if (!string.IsNullOrEmpty(_supertip)) {
                element.Add(new XAttribute("supertip", _supertip));
            }

            if (!string.IsNullOrEmpty(_keytip)) {
                element.Add(new XAttribute("keytip", _keytip));
            }

            if (!string.IsNullOrEmpty(_description)) {
                element.Add(new XAttribute("description", _description));
            }

            return element;
        }

        #region Implementation of ICheckBoxCommand

        public ICheckBoxCommand OnAction(Action<bool> act) {
            base.RegisteCallback("OnActionPressed", new CallbackActionField<Action<bool>>(act));
            return this;
        }

        public ICheckBoxCommand IsVisible(Func<bool> condition) {
            base.RegisteCallback("getVisible", new CallbackFuncField<Func<bool>>(condition));
            return this;
        }

        public ICheckBoxCommand IsEnabled(Func<bool> condition) {
            base.RegisteCallback("getEnabled", new CallbackFuncField<Func<bool>>(condition));
            return this;
        }

        /// <summary>
        /// determined whether the check-box is checked or not when the application is launched.
        /// </summary>
        /// <param name="defaultValue">a boolean value</param>
        /// <returns>Fluent Builder</returns>
        public ICheckBoxCommand Pressed(Func<bool> defaultValue) {
            base.RegisteCallback("getPressed", new CallbackFuncField<Func<bool>>(defaultValue));
            return this;
        }

        #endregion
    }
}