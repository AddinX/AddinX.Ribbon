using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Implementation.Command {
    public class EditBoxCommand : AbstractCommand, IEditBoxCommand, IVisibleField, IEnabledField, ITextField {
        public IEditBoxCommand IsVisible(Func<bool> condition) {
            getVisible = condition;
            return this;
        }

        public IEditBoxCommand IsEnabled(Func<bool> condition) {
            getEnabled = condition;
            return this;
        }

        public IEditBoxCommand GetText(Func<string> defaultValue) {
            getText = defaultValue;
            return this;
        }

        public IEditBoxCommand OnChange(Action<string> newText) {
            onChange = newText;
            return this;
        }

        #region Implementation of ICommand

        /// <summary>
        ///     写入回调Xml属性
        /// </summary>
        /// <param name="element"></param>
        public override void WriteCallbackXml(XElement element) {
            element.AddCallbackAttribute("getText", getText);
            element.AddCallbackAttribute("onChange", onChange);
            element.AddCallbackAttribute("getEnabled", getEnabled);
            element.AddCallbackAttribute("getVisible", getVisible);
        }

        #endregion

        public Func<bool> getEnabled { get;  set; }
        public Func<string> getText { get;  set; }
        public Action<string> onChange { get;  set; }

        public Func<bool> getVisible { get;  set; }
    }
}