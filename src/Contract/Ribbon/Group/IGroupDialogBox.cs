using AddinX.Core.Contract.Control.DialogBoxLauncher;

namespace AddinX.Core.Contract.Ribbon.Group
{
    public interface IGroupDialogBox
    {
        IDialogBoxLauncherId AddDialogBoxLauncher();
    }
}