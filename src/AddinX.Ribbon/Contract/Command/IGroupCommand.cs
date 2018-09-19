using System;

namespace AddinX.Ribbon.Contract.Command
{
    public interface IGroupCommand : ICommand
    {
        void IsVisible(Func<bool> condition);
    }
}