using System;

namespace AddinX.Ribbon.Contract.Command
{
    public interface IMenuCommand : ICommand
    {
        IMenuCommand IsVisible(Func<bool> condition);

        IMenuCommand IsEnabled(Func<bool> condition);
    }
}