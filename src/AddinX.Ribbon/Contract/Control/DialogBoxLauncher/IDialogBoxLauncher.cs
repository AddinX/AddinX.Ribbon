using AddinX.Ribbon.Contract.Command;

namespace AddinX.Ribbon.Contract.Control.DialogBoxLauncher
{
    public interface IDialogBoxLauncher : IRibbonIdQ<IDialogBoxLauncher>,IRibbonExtra<IDialogBoxLauncher>,
            IRibbonCallback<IDialogBoxLauncher,IDialogBoxLauncherCommand>
        //IDialogBoxLauncherExtra, IDialogBoxLauncherId
    {


    }
}