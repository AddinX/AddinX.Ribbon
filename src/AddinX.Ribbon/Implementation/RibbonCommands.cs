using System.Collections.Generic;
using System.Diagnostics;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Control;
using AddinX.Ribbon.Implementation.Command;

namespace AddinX.Ribbon.Implementation {
    public class RibbonCommands : IRibbonCommands, ICallbackRigister {
        private readonly IDictionary<string, ICommand> _commands = new SortedDictionary<string, ICommand>();

        public IToggleButtonCommand AddToggleButtonCommand(string id) {
            var cmd = new ToggleButtonCommand();
            Add(id, cmd);
            return cmd;
        }

        public IMenuCommand AddMenuCommand(string id) {
            var cmd = new MenuCommand();
            Add(id, cmd);
            return cmd;
        }

        public IBoxCommand AddBoxCommand(string id) {
            var cmd = new BoxCommand();
            Add(id, cmd);
            return cmd;
        }

        public IButtonGroupCommand AddButtonGroupCommand(string id) {
            var cmd = new ButtonGroupCommand();
            Add(id, cmd);
            return cmd;
        }

        public IDialogBoxLauncherCommand AddDialogBoxLauncherCommand(string id) {
            var cmd = new DialogBoxLauncherCommand();
            Add(id, cmd);
            return cmd;
        }

        public IButtonCommand AddButtonCommand(string id) {
            var cmd = new ButtonCommand();
            Add(id, cmd);
            return cmd;
        }

        public ICheckBoxCommand AddCheckBoxCommand(string id) {
            var cmd = new CheckBoxCommand();
            Add(id, cmd);
            return cmd;
        }

        public IComboBoxCommand AddComboBoxCommand(string id) {
            var cmd = new ComboBoxCommand();
            Add(id, cmd);
            return cmd;
        }

        public IDropDownCommand AddDropDownCommand(string id) {
            var cmd = new DropDownCommand();
            Add(id, cmd);
            return cmd;
        }

        public IEditBoxCommand AddEditBoxCommand(string id) {
            var cmd = new EditBoxCommand();
            Add(id, cmd);
            return cmd;
        }

        public IGalleryCommand AddGalleryCommand(string id) {
            var cmd = new GalleryCommand();
            Add(id, cmd);
            return cmd;
        }

        public ILabelCommand AddLabelCommand(string id) {
            var cmd = new LabelCommand();
            Add(id, cmd);
            return cmd;
        }

        public ISeparatorCommand AddSeparatorCommand(string id) {
            var cmd = new SeparatorCommand();
            Add(id, cmd);
            return cmd;
        }

        /// <summary>
        /// 注册命令
        /// </summary>
        /// <param name="elementId"></param>
        /// <param name="command"></param>
        public void Add(IElementId elementId, ICommand command) {
            Add(elementId.Value, command);
        }

        /// <summary>
        /// 注册命令
        /// </summary>
        /// <param name="elementId"></param>
        /// <param name="command"></param>
        private void Add(string elementId, ICommand command) {
            Debug.WriteLine("Add Command {0} {1}", elementId, command.GetType());
            if (_commands.ContainsKey(elementId)) {
                _commands[elementId] = command;
            } else {
                _commands.Add(elementId, command);
            }
        }

        public ICommand Find(string id) {
            return !_commands.Keys.Contains(id)
                ? null
                : _commands[id];
        }
    }
}