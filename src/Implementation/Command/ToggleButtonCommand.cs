using System;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Implementation.Command
{
    class ToggleButtonCommand : IToggleButtonCommand, IVisibleField, IEnabledField, IPressedField, IActionPressedField
    {
        public Action<bool> OnActionField { get; private set; }

        public Func<bool> IsVisibleField { get; private set; }

        public Func<bool> IsEnabledField { get; private set; }

        public Func<bool> PressedField { get; private set; }

        public ToggleButtonCommand()
        {
            IsVisibleField = () => true;
            IsEnabledField = () => true;
            PressedField = () => false;
        }

        public IToggleButtonCommand Action(Action<bool> act)
        {
            OnActionField = act;
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

        public IToggleButtonCommand Pressed(Func<bool> defaultValue)
        {
            PressedField = defaultValue;
            return this;
        }
    }
}