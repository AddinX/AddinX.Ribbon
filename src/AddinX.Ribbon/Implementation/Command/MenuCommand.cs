using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Implementation.Command {
    public class MenuCommand : IMenuCommand, IVisibleField, IEnabledField {
        public Func<bool> getEnabled { get; set; }

        public IMenuCommand IsVisible(Func<bool> condition) {
            IsVisibleField = condition;
            return this;
        }

        public IMenuCommand IsEnabled(Func<bool> condition) {
            getEnabled = condition;
            return this;
        }

        #region Implementation of ICommand

        /// <summary>
        ///     写入回调Xml属性
        /// </summary>
        /// <param name="element"></param>
        public void WriteCallbackXml(XElement element) {
            element.AddCallbackAttribute("getEnabled", getEnabled);
            element.AddCallbackAttribute("getVisible", IsVisibleField);
        }

        #endregion

        public Func<bool> IsVisibleField { get; private set; }
    }
}