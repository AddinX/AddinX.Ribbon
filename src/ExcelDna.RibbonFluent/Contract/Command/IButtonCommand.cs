using System;

namespace AddinX.Ribbon.Contract.Command {
    public interface IButtonCommand : IButtonRegularCommand<IButtonCommand> {
        IButtonCommand OnAction(Action action);
    }
}