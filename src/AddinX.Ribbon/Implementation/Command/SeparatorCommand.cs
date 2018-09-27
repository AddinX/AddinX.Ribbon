using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Implementation.Command {
    public class SeparatorCommand : AbstractCommand, ISeparatorCommand, IVisibleField {
        public void IsVisible(Func<bool> condition) {
            getVisible = condition;
        }

        #region Implementation of ICommand

        /// <summary>
        ///     写入回调Xml属性
        /// </summary>
        /// <param name="element"></param>
        public override void WriteCallbackXml(XElement element) {
            element.AddCallbackAttribute("getVisible", getVisible);
        }

        #endregion

        public Func<bool> getVisible { get;  set; }
    }
}