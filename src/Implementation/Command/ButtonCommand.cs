using System;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Implementation.Command
{
    class ButtonCommand : IButtonCommand, IVisibleField, IEnabledField, IActionField
    {
        public IRelayCommand OnActionField { get; private set; }

        public Func<bool> IsVisibleField { get; private set; }

        public Func<bool> IsEnabledField { get; private set; }

        public ButtonCommand()
        {
            IsVisibleField = () => true;
            IsEnabledField = () => true;
        }

        public IButtonCommand Action(Action act)
        {
            return Action(act, () => true);
        }

        public IButtonCommand Action(Action act, Func<bool> canExecute)
        {
            OnActionField = new RelayCommand(act, canExecute);
            return this;
        }

        public IButtonCommand IsVisible(Func<bool> condition)
        {
            IsVisibleField = condition;
            return this;
        }

        public IButtonCommand IsEnabled(Func<bool> condition)
        {
            IsEnabledField = condition;
            return this;
        }
    }
}