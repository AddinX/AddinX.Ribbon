using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;
using AddinX.Ribbon.Contract.Enums;

namespace AddinX.Ribbon.Implementation.Command {
    public class ButtonCommand : ButtonRegularCommand,IButtonCommand{

        public Func<bool> IsVisibleField { get; set; }

       

        #region Implementation of ICommand

        /// <summary>
        ///     写入回调Xml属性
        /// </summary>
        /// <param name="element"></param>
        public override void WriteCallbackXml(XElement element) {
            base.WriteCallbackXml(element);
            element.AddCallbackAttribute("getSize", getSize);
        }

        #endregion

        #region Implementation of ISizeField

        public Func<ControlSize> getSize { get; set; }

        #endregion
    }
}