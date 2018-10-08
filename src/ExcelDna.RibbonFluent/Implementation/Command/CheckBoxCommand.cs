using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Implementation.Command {
    public class CheckBoxCommand : ButtonRegularCommand<ICheckBoxCommand>, ICheckBoxCommand,
        IPressedField,IActionPressedField {

        public Action<bool> onActionPressed { get; set; }

        /// <inheritdoc />
        public Func<bool> getPressed { get; set; }


        public ICheckBoxCommand GetChecked(Func<bool> checkdFunc) {
            getPressed = checkdFunc;
            return this;
        }

        public ICheckBoxCommand OnChecked(Action<bool> action) {
            onActionPressed = action;
            return this;
        }

        protected override ICheckBoxCommand Interface => this;

        protected internal override void WriteXml(XElement element) {
            base.WriteXml(element);
            AddOnActionPressed(element,onActionPressed);
            AddGetPressed(element,getPressed);
        }
    }
}