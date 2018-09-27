using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Implementation.Command {
    public class MenuCommand : AbstractCommand,IMenuCommand, IVisibleField, IEnabledField {
        public Func<bool> getEnabled { get; set; }

        public IMenuCommand IsVisible(Func<bool> condition) {
            getVisible = condition;
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
        public override void WriteCallbackXml(XElement element) {
            element.AddCallbackAttribute("getEnabled", getEnabled);
            element.AddCallbackAttribute("getVisible", getVisible);
        }

        #endregion

        public Func<bool> getVisible { get; set; }
    }
}