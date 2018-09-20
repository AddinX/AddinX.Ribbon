using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Implementation.Command {
    class LabelCommand : ILabelCommand, IVisibleField, IEnabledField, ILabelField {
        public LabelCommand() {
            //IsVisibleField = () => true;
            //IsEnabledField = () => true;
        }

        public ILabelCommand IsVisible(Func<bool> condition) {
            IsVisibleField = condition;
            return this;
        }

        public ILabelCommand IsEnabled(Func<bool> condition) {
            IsEnabledField = condition;
            return this;
        }

        public ILabelCommand GetLabel(Func<string> text) {
            LabelField = text;
            return this;
        }

        public Func<bool> IsVisibleField { get; private set; }
        public Func<bool> IsEnabledField { get; private set; }
        public Func<string> LabelField { get; private set; }

        #region Implementation of ICommand

        /// <summary>
        /// 写入回调Xml属性
        /// </summary>
        /// <param name="element"></param>
        public void WriteCallbackXml(XElement element) {
            element.AddCallbackAttribute("getLabel", LabelField);
            element.AddCallbackAttribute("getEnabled", IsEnabledField);
            element.AddCallbackAttribute("getVisible", IsVisibleField);
        }

        #endregion
    }
}