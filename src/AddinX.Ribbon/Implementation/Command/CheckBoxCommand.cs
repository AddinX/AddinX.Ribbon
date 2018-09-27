using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Implementation.Command {
    public class CheckBoxCommand : AbstractCommand, ICheckBoxCommand, IVisibleField, IEnabledField, IPressedField,
        IActionPressedField {
        public Action<bool> onActionPressed { get; set; }

        public ICheckBoxCommand IsVisible(Func<bool> condition) {
            getVisible = condition;
            return this;
        }

        public ICheckBoxCommand IsEnabled(Func<bool> condition) {
            getEnabled = condition;
            return this;
        }

        public ICheckBoxCommand Pressed(Func<bool> defaultValue) {
            getPressed = defaultValue;
            return this;
        }

        public ICheckBoxCommand OnAction(Action<bool> act) {
            onActionPressed = act;
            return this;
        }

        public override void WriteCallbackXml(XElement element) {
            element.AddCallbackAttribute("onAction", "OnActionPressed", onActionPressed);
            element.AddCallbackAttribute("getPressed", getPressed);
            element.AddCallbackAttribute("getVisible", getVisible);
            element.AddCallbackAttribute("getEnabled", getEnabled);
        }

        /// <inheritdoc />
        public Func<bool> getEnabled { get;  set; }

        /// <inheritdoc />
        public Func<bool> getPressed { get;  set; }

        /// <inheritdoc />
        public Func<bool> getVisible { get;  set; }
    }
}