using System;
using AddinX.Core.Contract.Command;
using AddinX.Core.Contract.Command.Field;

namespace AddinX.Core.Implementation.Command
{
    public class ButtonGroupCommand:IButtonGroupCommand, IVisibleField
    {
        public Func<bool> IsVisibleField { get; private set; }

        public ButtonGroupCommand()
        {
            IsVisibleField = () => true;
        }

        public void IsVisible(Func<bool> condition)
        {
            IsVisibleField = condition;
        }
    }
}