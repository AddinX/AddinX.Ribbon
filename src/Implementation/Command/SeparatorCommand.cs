using System;
using AddinX.Core.Contract.Command;
using AddinX.Core.Contract.Command.Field;

namespace AddinX.Core.Implementation.Command
{
    class SeparatorCommand : ISeparatorCommand, IVisibleField
    {
        public Func<bool> IsVisibleField { get; private set; }

        public SeparatorCommand()
        {
            IsVisibleField = () => true;
        }

        public void IsVisible(Func<bool> condition)
        {
            IsVisibleField = condition;
        }
    }
}