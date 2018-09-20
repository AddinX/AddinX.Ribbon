using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Implementation.Command {
    class EditBoxCommand : IEditBoxCommand, IVisibleField, IEnabledField, ITextField {
        public EditBoxCommand() {
            //IsVisibleField = () => true;
            //IsEnabledField = () => true;
            //TextField = () => string.Empty;
        }

        public IEditBoxCommand IsVisible(Func<bool> condition) {
            IsVisibleField = condition;
            return this;
        }

        public IEditBoxCommand IsEnabled(Func<bool> condition) {
            IsEnabledField = condition;
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

        public Func<bool> IsVisibleField { get; private set; }
        public Func<bool> IsEnabledField { get; private set; }
        public Func<string> TextField { get; private set; }
        public Action<string> OnChangeFieldAction { get; private set; }

        #region Implementation of ICommand

        /// <summary>
        /// 写入回调Xml属性
        /// </summary>
        /// <param name="element"></param>
        public void WriteCallbackXml(XElement element) {
            element.AddCallbackAttribute("getText",TextField);
            element.AddCallbackAttribute("onChange",OnChangeFieldAction);
            element.AddCallbackAttribute("getEnabled", IsEnabledField);
            element.AddCallbackAttribute("getVisible", IsVisibleField);

        }

        #endregion
    }
}