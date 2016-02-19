namespace AddinX.Ribbon.Contract.Control.DialogBoxLauncher
{
    public interface IDialogBoxLauncherExtra
    {
        IDialogBoxLauncherExtra Description(string description);

        IDialogBoxLauncherExtra Supertip(string supertip);

        IDialogBoxLauncherExtra Keytip(string keytip);

        IDialogBoxLauncherExtra Screentip(string screentip);
    }
}