using System;

namespace AddinX.Ribbon.Contract.Command {
    public interface IBoxCommand : ICommand {
        void GetVisible(Func<bool> condition);
    }
}