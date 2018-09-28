using System;

namespace AddinX.Ribbon.Contract.Command {
    public interface ILabelCommand : ICommand {
        void GetVisible(Func<bool> condition);

        void GetEnabled(Func<bool> condition);

        void GetLabel(Func<string> text);
    }
}