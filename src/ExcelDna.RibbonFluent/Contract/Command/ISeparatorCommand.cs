using System;

namespace AddinX.Ribbon.Contract.Command {
    public interface ISeparatorCommand : ICommand {
        void GetVisible(Func<bool> condition);
    }
}