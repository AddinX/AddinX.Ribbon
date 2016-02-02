using System;
using AddinX.Core.Contract.Command;
using AddinX.Core.Contract.Command.Field;

namespace AddinX.Core.Implementation.Command
{
    public class BoxCommand : IBoxCommand, IVisibleField
    {
        public Func<bool> IsVisibleField { get; private set; }

        public BoxCommand()
        {
            IsVisibleField = () => true;
        }
        public void IsVisible(Func<bool> condition)
        {
            IsVisibleField = condition;
        }
    }
}