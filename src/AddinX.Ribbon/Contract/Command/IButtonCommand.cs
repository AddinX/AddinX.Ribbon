using System;

namespace AddinX.Ribbon.Contract.Command {
    public interface IButtonCommand : IButtonRegularCommand {
        IButtonCommand OnAction(Action action);

        IButtonCommand GetVisible(Func<bool> condition);

        IButtonCommand GetEnabled(Func<bool> condition);
    }
}