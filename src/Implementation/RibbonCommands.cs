using System.Collections.Generic;
using System.Linq;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Implementation.Command;

namespace AddinX.Ribbon.Implementation
{
    public class RibbonCommands : IRibbonCommands
    {
        private readonly IDictionary<string, ICommand> commands;

        public RibbonCommands()
        {
            commands = new Dictionary<string, ICommand>();
        }

        public IToggleButtonCommand AddToggleButtonCommand(string id)
        {
            var cmd = new ToggleButtonCommand();
            commands.Add(id, cmd);
            return cmd;
        }

        public IMenuCommand AddMenuCommand(string id)
        {
            var cmd = new MenuCommand();
            commands.Add(id, cmd);
            return cmd;
        }

        public IBoxCommand AddBoxCommand(string id)
        {
            var cmd = new BoxCommand();
            commands.Add(id, cmd);
            return cmd;
        }

        public IButtonGroupCommand AddButtonGroupCommand(string id)
        {
            var cmd = new ButtonGroupCommand();
            commands.Add(id, cmd);
            return cmd;
        }

        public IDialogBoxLauncherCommand AddDialogBoxLauncherCommand(string id)
        {
            var cmd = new DialogBoxLauncherCommand();
            commands.Add(id, cmd);
            return cmd;
        }

        public IEnumerable<string> GetListCommandNames()
        {
            return commands.Keys.ToList();
        }

        public IButtonCommand AddButtonCommand(string id)
        {
            var cmd = new ButtonCommand();
            commands.Add(id, cmd);
            return cmd;
        }

        public ICheckBoxCommand AddCheckBoxCommand(string id)
        {
            var cmd = new CheckBoxCommand();
            commands.Add(id, cmd);
            return cmd;
        }

        public IComboBoxCommand AddComboBoxCommand(string id)
        {
            var cmd = new ComboBoxCommand();
            commands.Add(id, cmd);
            return cmd;
        }

        public IDropDownCommand AddDropDownCommand(string id)
        {
            var cmd = new DropDownCommand();
            commands.Add(id, cmd);
            return cmd;
        }

        public IEditBoxCommand AddEditBoxCommand(string id)
        {
            var cmd = new EditBoxCommand();
            commands.Add(id, cmd);
            return cmd;
        }

        public IGalleryCommand AddGalleryCommand(string id)
        {
            var cmd = new GalleryCommand();
            commands.Add(id, cmd);
            return cmd;
        }

        public ILabelCommand AddLabelCommand(string id)
        {
            var cmd = new LabelCommand();
            commands.Add(id, cmd);
            return cmd;
        }

        public ISeparatorCommand AddSeparatorCommand(string id)
        {
            var cmd = new SeparatorCommand();
            commands.Add(id, cmd);
            return cmd;
        }

        public ICommand Find(string id)
        {
            return !commands.Keys.Contains(id)
                ? null
                : commands[id];
        }
    }
}