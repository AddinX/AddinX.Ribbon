using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Implementation.Command {
    public class ComboBoxCommand : DynamicItemsCommand<IComboBoxCommand>, IComboBoxCommand,
        ITextField {

        public Func<string> getText { get; set; }
        public Action<string> onChange { get; set; }

        public IComboBoxCommand GetText(Func<string> defaultValue) {
            getText = defaultValue;
            return this;
        }

        public IComboBoxCommand OnChange(Action<string> newText) {
            onChange = newText;
            return this;
        }

        #region Implementation of ICommand

        protected override IComboBoxCommand Interface => this;

        /// <summary>
        ///     写入回调Xml属性
        /// </summary>
        /// <param name="element"></param>
        protected internal override void WriteXml(XElement element) {
            base.WriteXml(element);
            AddOnChange(element, onChange);
            AddGetText(element,getText);
        }

        #endregion
    }
}