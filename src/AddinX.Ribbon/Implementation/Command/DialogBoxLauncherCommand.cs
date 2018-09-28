using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Implementation.Command {
    public class DialogBoxLauncherCommand : AbstractCommand, IDialogBoxLauncherCommand, IVisibleField, IEnabledField,
        IActionField {
        public Action onAction { get; set; }
        public Func<bool> getEnabled { get; set; }
        public Func<bool> getVisible { get; set; }

        public IDialogBoxLauncherCommand OnAction(Action act) {
            onAction = act;
            return this;
        }

        public IDialogBoxLauncherCommand GetVisible(Func<bool> condition) {
            getVisible = condition;
            return this;
        }

        public IDialogBoxLauncherCommand GetEnabled(Func<bool> condition) {
            getEnabled = condition;
            return this;
        }

        #region Implementation of ICommand

        /// <summary>
        ///     写入回调Xml属性
        /// </summary>
        /// <param name="element"></param>
        public override void WriteCallbackXml(XElement element) {
            element.AddCallbackAttribute("onAction", onAction);
            element.AddCallbackAttribute("getEnabled", getEnabled);
            element.AddCallbackAttribute("getVisible", getVisible);
        }

        #endregion
    }
}