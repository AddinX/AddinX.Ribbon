using System;

namespace AddinX.Core.Contract.Command
{
    public interface IMenuCommand : ICommand
    {
        IMenuCommand IsVisible(Func<bool> condition);

        IMenuCommand IsEnabled(Func<bool> condition);
    }
}