using System;

namespace AddinX.Ribbon.Contract.Command
{
    public interface IButtonCommand : ICommand
    {
        IButtonCommand Action(Action act);

        IButtonCommand Action(Action act, Func<bool> canExecute);

        IButtonCommand IsVisible(Func<bool> condition);

        IButtonCommand IsEnabled(Func<bool> condition);
    }
}