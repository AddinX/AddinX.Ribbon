using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Implementation.Command {
    public class LabelCommand : ControlCommand<ILabelCommand>, ILabelCommand
        //IVisibleField, IEnabledField, ILabelField 
        {
        #region Implementation of ICommand

        protected override ILabelCommand Interface => this;

        /// <summary>
        ///     写入回调Xml属性
        /// </summary>
        /// <param name="element"></param>
        public override void WriteCallbackXml(XElement element) {
           base.WriteCallbackXml(element);
        }

        #endregion
    }
}