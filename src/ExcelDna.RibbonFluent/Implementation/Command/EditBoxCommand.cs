using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Implementation.Command {
    public class EditBoxCommand : ControlCommand<IEditBoxCommand>, IEditBoxCommand, ITextField {
    
        public IEditBoxCommand GetText(Func<string> defaultValue) {
            getText = defaultValue;
            return this;
        }

        public IEditBoxCommand OnChange(Action<string> newText) {
            onChange = newText;
            return this;
        }

        #region Implementation of ICommand

        protected override IEditBoxCommand Interface => this;

        /// <summary>
        ///     写入回调Xml属性
        /// </summary>
        /// <param name="element"></param>
        protected internal override void WriteXml(XElement element) {
            base.WriteXml(element);
            element.AddCallbackAttribute("getText", getText);
            element.AddCallbackAttribute("onChange", onChange);
        }

        #endregion

        public Func<string> getText { get; set; }
        public Action<string> onChange { get; set; }
    }
}