using AddinX.Ribbon.Contract.Control.DialogBoxLauncher;

namespace AddinX.Ribbon.Contract.Ribbon.Group
{
    public interface IGroupDialogBox
    {
        IDialogBoxLauncherId AddDialogBoxLauncher();
    }
}