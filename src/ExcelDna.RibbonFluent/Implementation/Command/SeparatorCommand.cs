using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Implementation.Command {
    public class SeparatorCommand : AbstractCommand, ISeparatorCommand, IVisibleField {
        public void GetVisible(Func<bool> condition) {
            getVisible = condition;
        }

        #region Implementation of ICommand

        /// <summary>
        ///     写入回调Xml属性
        /// </summary>
        /// <param name="element"></param>
        protected internal override void WriteXml(XElement element) {
            AddGetVisible(element,getVisible);
        }

        #endregion

        public Func<bool> getVisible { get; set; }
    }
}