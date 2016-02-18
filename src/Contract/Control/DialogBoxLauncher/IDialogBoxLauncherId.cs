namespace AddinX.Core.Contract.Control.DialogBoxLauncher
{
    public interface IDialogBoxLauncherId
    {
        IDialogBoxLauncherExtra SetId(string name);

        IDialogBoxLauncherExtra SetIdQ(string ns, string name);
    }
}