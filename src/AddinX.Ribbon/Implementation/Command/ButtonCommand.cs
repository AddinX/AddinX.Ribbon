using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;
using AddinX.Ribbon.Contract.Enums;

namespace AddinX.Ribbon.Implementation.Command {
    public class ButtonCommand : ButtonRegularCommand,IButtonCommand{

        #region Implementation of ICommand

        /// <summary>
        ///     写入回调Xml属性
        /// </summary>
        /// <param name="element"></param>
        public override void WriteCallbackXml(XElement element) {
            base.WriteCallbackXml(element);
        }

        #endregion

        #region Implementation of IButtonCommand

        public IButtonCommand OnAction(Action act) {
            base.onAction = act;
            return this;
        }

        public IButtonCommand GetVisible(Func<bool> condition) {
            base.getVisible = condition;
            return this;
        }

        public IButtonCommand GetEnabled(Func<bool> condition) {
            base.getEnabled = condition;
            return this;
        }

        #endregion
    }
}