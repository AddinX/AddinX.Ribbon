using System;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Implementation.Command {
    class ButtonCommand : IButtonCommand, IVisibleField, IEnabledField, IActionField {
        public Action OnActionField { get; private set; }

        public Func<bool> IsVisibleField { get; private set; }

        public Func<bool> IsEnabledField { get; private set; }

        public ButtonCommand() {
            IsVisibleField = () => true;
            IsEnabledField = () => true;
        }

        public IButtonCommand OnAction(Action act) {
            this.OnActionField = act;
            return this;
        }

        public IButtonCommand GetVisible(Func<bool> condition) {
            IsVisibleField = condition;
            return this;
        }

        public IButtonCommand GetEnabled(Func<bool> condition) {
            IsEnabledField = condition;
            return this;
        }
    }
}