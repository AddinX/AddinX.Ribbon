using System;

namespace AddinX.Ribbon.Contract.Command {
    public interface IDialogBoxLauncherCommand : ICommand {
        IDialogBoxLauncherCommand OnAction(Action act);

        IDialogBoxLauncherCommand GetVisible(Func<bool> condition);

        IDialogBoxLauncherCommand GetEnabled(Func<bool> condition);
    }
}