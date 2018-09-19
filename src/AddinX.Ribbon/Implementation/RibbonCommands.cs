using System.Collections.Generic;
using System.Linq;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Implementation.Command;

namespace AddinX.Ribbon.Implementation {
    public class RibbonCommands : IRibbonCommands {
        private readonly IDictionary<string, ICommand> _commands;

        public RibbonCommands() {
            _commands = new Dictionary<string, ICommand>();
        }

        public IToggleButtonCommand AddToggleButtonCommand(string id) {
            var cmd = new ToggleButtonCommand();
            _commands.Add(id, cmd);
            return cmd;
        }

        public IMenuCommand AddMenuCommand(string id) {
            var cmd = new MenuCommand();
            _commands.Add(id, cmd);
            return cmd;
        }

        public IBoxCommand AddBoxCommand(string id) {
            var cmd = new BoxCommand();
            _commands.Add(id, cmd);
            return cmd;
        }

        public IButtonGroupCommand AddButtonGroupCommand(string id) {
            var cmd = new ButtonGroupCommand();
            _commands.Add(id, cmd);
            return cmd;
        }

        public IDialogBoxLauncherCommand AddDialogBoxLauncherCommand(string id) {
            var cmd = new DialogBoxLauncherCommand();
            _commands.Add(id, cmd);
            return cmd;
        }

        public IEnumerable<string> GetListCommandNames() {
            return _commands.Keys.ToList();
        }

        public IButtonCommand AddButtonCommand(string id) {
            var cmd = new ButtonCommand();
            _commands.Add(id, cmd);
            return cmd;
        }

        public ICheckBoxCommand AddCheckBoxCommand(string id) {
            var cmd = new CheckBoxCommand();
            _commands.Add(id, cmd);
            return cmd;
        }

        public IComboBoxCommand AddComboBoxCommand(string id) {
            var cmd = new ComboBoxCommand();
            _commands.Add(id, cmd);
            return cmd;
        }

        public IDropDownCommand AddDropDownCommand(string id) {
            var cmd = new DropDownCommand();
            _commands.Add(id, cmd);
            return cmd;
        }

        public IEditBoxCommand AddEditBoxCommand(string id) {
            var cmd = new EditBoxCommand();
            _commands.Add(id, cmd);
            return cmd;
        }

        public IGalleryCommand AddGalleryCommand(string id) {
            var cmd = new GalleryCommand();
            _commands.Add(id, cmd);
            return cmd;
        }

        public ILabelCommand AddLabelCommand(string id) {
            var cmd = new LabelCommand();
            _commands.Add(id, cmd);
            return cmd;
        }

        public ISeparatorCommand AddSeparatorCommand(string id) {
            var cmd = new SeparatorCommand();
            _commands.Add(id, cmd);
            return cmd;
        }

        public ICommand Find(string id) {
            return !_commands.Keys.Contains(id)
                ? null
                : _commands[id];
        }
    }
}