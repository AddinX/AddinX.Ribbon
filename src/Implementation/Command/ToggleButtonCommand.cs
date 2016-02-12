using System;
using AddinX.Core.Contract.Command;
using AddinX.Core.Contract.Command.Field;

namespace AddinX.Core.Implementation.Command
{
    class ToggleButtonCommand : IToggleButtonCommand, IVisibleField, IEnabledField, IActionField, IPressedField
    {
        public IRelayCommand OnActionField { get; private set; }

        public Func<bool> IsVisibleField { get; private set; }

        public Func<bool> IsEnabledField { get; private set; }

        public Func<bool> PressedField { get; private set; }

        public ToggleButtonCommand()
        {
            IsVisibleField = () => true;
            IsEnabledField = () => true;
            PressedField = () => false;
        }

        public IToggleButtonCommand Action(Action act)
        {
            return Action(act, () => true);
        }

        public IToggleButtonCommand Action(Action act, Func<bool> canExecute)
        {
            OnActionField = new RelayCommand(act, canExecute);
            return this;
        }

        public IToggleButtonCommand IsVisible(Func<bool> condition)
        {
            IsVisibleField = condition;
            return this;
        }

        public IToggleButtonCommand IsEnabled(Func<bool> condition)
        {
            IsEnabledField = condition;
            return this;
        }

        public IToggleButtonCommand GetPressed(Func<bool> defaultValue)
        {
            PressedField = defaultValue;
            return this;
        }
    }
}