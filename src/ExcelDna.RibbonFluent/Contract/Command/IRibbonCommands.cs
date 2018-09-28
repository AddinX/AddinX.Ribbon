namespace AddinX.Ribbon.Contract.Command {
    public interface IRibbonCommands {
        IButtonCommand AddButtonCommand(string controlId);

        ICheckBoxCommand AddCheckBoxCommand(string controlId);

        IComboBoxCommand AddComboBoxCommand(string controlId);

        IDropDownCommand AddDropDownCommand(string controlId);

        IEditBoxCommand AddEditBoxCommand(string controlId);

        IGalleryCommand AddGalleryCommand(string controlId);

        ILabelCommand AddLabelCommand(string controlId);

        ISeparatorCommand AddSeparatorCommand(string controlId);

        IToggleButtonCommand AddToggleButtonCommand(string controlId);

        IMenuCommand AddMenuCommand(string controlId);

        IBoxCommand AddBoxCommand(string controlId);

        IButtonGroupCommand AddButtonGroupCommand(string controlId);

        IDialogBoxLauncherCommand AddDialogBoxLauncherCommand(string controlId);

        /// <summary>
        /// Find ICommand instance By control id
        /// </summary>
        /// <param name="controlId"></param>
        /// <returns></returns>
        ICommand Find(string controlId);
    }
}