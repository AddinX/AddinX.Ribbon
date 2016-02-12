using System;

namespace AddinX.Core.Contract.Command
{
    public interface IButtonGroupCommand : ICommand
    {
        void IsVisible(Func<bool> condition);
    }
}