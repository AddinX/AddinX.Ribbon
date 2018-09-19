using System;

namespace AddinX.Ribbon.Contract.Command
{
    public interface IDialogBoxLauncherCommand : ICommand
    {
        IDialogBoxLauncherCommand Action(Action act);

        IDialogBoxLauncherCommand IsVisible(Func<bool> condition);

        IDialogBoxLauncherCommand IsEnabled(Func<bool> condition);
    }
}