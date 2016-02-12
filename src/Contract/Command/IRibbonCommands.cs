using System.Collections.Generic;

namespace AddinX.Core.Contract.Command
{
    public interface IRibbonCommands
    {
        IButtonCommand AddButtonCommand(string id);

        ICheckBoxCommand AddCheckBoxCommand(string id);

        IComboBoxCommand AddComboBoxCommand(string id);

        IDropDownCommand AddDropDownCommand(string id);

        IEditBoxCommand AddEditBoxCommand(string id);

        IGalleryCommand AddGalleryCommand(string id);

        ILabelCommand AddLabelCommand(string id);

        ISeparatorCommand AddSeparatorCommand(string id);

        IToggleButtonCommand AddToggleButtonCommand(string id);

        IMenuCommand AddMenuCommand(string id);

        IBoxCommand AddBoxCommand(string id);

        IButtonGroupCommand AddButtonGroupCommand(string id);

        IDialogBoxLauncherCommand AddDialogBoxLauncherCommand(string id);

        IEnumerable<string> GetListCommandNames();

        ICommand Find(string id);
    }
}