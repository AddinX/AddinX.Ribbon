using System;

namespace AddinX.Core.Contract.Command
{
    public interface IGroupCommand : ICommand
    {
        void IsVisible(Func<bool> condition);
    }
}