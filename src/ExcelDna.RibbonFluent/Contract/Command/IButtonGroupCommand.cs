using System;

namespace AddinX.Ribbon.Contract.Command {
    public interface IButtonGroupCommand : ICommand {
        void GetVisible(Func<bool> condition);
    }
}