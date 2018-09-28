using System;

namespace AddinX.Ribbon.Contract.Command {
    public interface IMenuCommand : ICommand {
        IMenuCommand GetVisible(Func<bool> condition);

        IMenuCommand GetEnabled(Func<bool> condition);
    }
}