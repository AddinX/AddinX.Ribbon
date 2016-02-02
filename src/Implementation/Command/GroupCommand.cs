using System;
using AddinX.Core.Contract.Command;
using AddinX.Core.Contract.Command.Field;

namespace AddinX.Core.Implementation.Command
{
    public class GroupCommand : IGroupCommand, IVisibleField
    {
        public Func<bool> IsVisibleField { get; private set; }

        public GroupCommand()
        {
            IsVisibleField = () => true;
        }
        public void IsVisible(Func<bool> condition)
        {
            IsVisibleField = condition;
        }
    }
}