using System;

namespace AddinX.Ribbon.Contract.Command
{
    public interface IButtonCommand : ICommand
    {
        IButtonCommand OnAction(Action act);

        IButtonCommand GetVisible(Func<bool> condition);

        IButtonCommand GetEnabled(Func<bool> condition);
    }
}