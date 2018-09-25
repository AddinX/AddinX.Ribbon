using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Implementation.Command {
    public class LabelCommand : ILabelCommand, IVisibleField, IEnabledField, ILabelField {
        public Func<bool> getEnabled { get;  set; }

        public Func<string> LabelField { get; set; }

        public Func<bool> IsVisibleField { get; set; }

        public void IsVisible(Func<bool> condition) {
            IsVisibleField = condition;
        }

        public void IsEnabled(Func<bool> condition) {
            getEnabled = condition;
        }

        public void GetLabel(Func<string> text) {
            LabelField = text;
        }

        #region Implementation of ICommand

        /// <summary>
        ///     写入回调Xml属性
        /// </summary>
        /// <param name="element"></param>
        public virtual void WriteCallbackXml(XElement element) {
            element.AddCallbackAttribute("getLabel", LabelField);
            element.AddCallbackAttribute("getEnabled", getEnabled);
            element.AddCallbackAttribute("getVisible", IsVisibleField);
        }

        #endregion

        
    }
}