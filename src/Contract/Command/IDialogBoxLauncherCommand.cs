using System;

namespace AddinX.Ribbon.Contract.Command
{
    public interface IDialogBoxLauncherCommand : ICommand
    {
        IDialogBoxLauncherCommand Action(Action act);

        IDialogBoxLauncherCommand Action(Action act, Func<bool> canExecute);

        IDialogBoxLauncherCommand IsVisible(Func<bool> condition);

        IDialogBoxLauncherCommand IsEnabled(Func<bool> condition);
    }
}