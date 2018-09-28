using System;

namespace AddinX.Ribbon.Contract.Command {
    public interface IGroupCommand : ICommand {
        void GetVisible(Func<bool> condition);
    }
}