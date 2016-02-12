namespace AddinX.Core.Contract.Control.DialogBoxLauncher
{
    public interface IDialogBoxLauncherIdUi
    {
        IDialogBoxLauncherExtra SetId(string name);

        IDialogBoxLauncherExtra SetIdQ(string ns, string name);
    }
}