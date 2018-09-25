using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Implementation.Command {
    public class EditBoxCommand : IEditBoxCommand, IVisibleField, IEnabledField, ITextField {
        public IEditBoxCommand IsVisible(Func<bool> condition) {
            IsVisibleField = condition;
            return this;
        }

        public IEditBoxCommand IsEnabled(Func<bool> condition) {
            getEnabled = condition;
            return this;
        }

        public IEditBoxCommand GetText(Func<string> defaultValue) {
            TextField = defaultValue;
            return this;
        }

        public IEditBoxCommand OnChange(Action<string> newText) {
            OnChangeFieldAction = newText;
            return this;
        }

        #region Implementation of ICommand

        /// <summary>
        ///     写入回调Xml属性
        /// </summary>
        /// <param name="element"></param>
        public void WriteCallbackXml(XElement element) {
            element.AddCallbackAttribute("getText", TextField);
            element.AddCallbackAttribute("onChange", OnChangeFieldAction);
            element.AddCallbackAttribute("getEnabled", getEnabled);
            element.AddCallbackAttribute("getVisible", IsVisibleField);
        }

        #endregion

        public Func<bool> getEnabled { get;  set; }
        public Func<string> TextField { get;  set; }
        public Action<string> OnChangeFieldAction { get;  set; }

        public Func<bool> IsVisibleField { get;  set; }
    }
}