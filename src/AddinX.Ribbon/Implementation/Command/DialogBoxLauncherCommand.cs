using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Implementation.Command {
    public class DialogBoxLauncherCommand : IDialogBoxLauncherCommand, IVisibleField, IEnabledField, IActionField {

        public Action OnAction { get;  set; }
        public Func<bool> getEnabled { get; set; }
        public Func<bool> IsVisibleField { get; set; }

        public IDialogBoxLauncherCommand Action(Action act) {
            OnAction = act;
            return this;
        }

        public IDialogBoxLauncherCommand IsVisible(Func<bool> condition) {
            IsVisibleField = condition;
            return this;
        }

        public IDialogBoxLauncherCommand IsEnabled(Func<bool> condition) {
            getEnabled = condition;
            return this;
        }

        #region Implementation of ICommand

        /// <summary>
        ///     写入回调Xml属性
        /// </summary>
        /// <param name="element"></param>
        public void WriteCallbackXml(XElement element) {
            element.AddCallbackAttribute("onAction", OnAction);
            element.AddCallbackAttribute("getEnabled", getEnabled);
            element.AddCallbackAttribute("getVisible", IsVisibleField);
        }

        #endregion

        
    }
}