using System;
using AddinX.Core.Contract.Command;
using AddinX.Core.Contract.Command.Field;

namespace AddinX.Core.Implementation.Command
{
    class CheckBoxCommand:ICheckBoxCommand, IVisibleField, IEnabledField, IPressedField, ICheckboxPressedField
    {
        public CheckBoxCommand()
        {
            IsVisibleField = () => true;
            IsEnabledField = () => true;
            PressedField = () => false;
        }
        public ICheckBoxCommand IsVisible(Func<bool> condition)
        {
            IsVisibleField = condition;
            return this;
        }

        public ICheckBoxCommand IsEnabled(Func<bool> condition)
        {
            IsEnabledField = condition;
            return this;
        }

        public ICheckBoxCommand Pressed(Func<bool> defaultValue)
        {
            PressedField = defaultValue;
            return this;
        }
        
        public ICheckBoxCommand Action(Action<bool> act)
        {
            OnActionField = act;
            return this;
        }

        public Func<bool> IsVisibleField { get; private set; }
        public Func<bool> IsEnabledField { get; private set; }
        public Func<bool> PressedField { get; private set; }
        public Action<bool> OnActionField { get; private set; }
        
    }
}