using System;

namespace AddinX.Ribbon.Contract.Command {
    internal interface IRelayCommand {
        Action Execute { get; }

        Func<bool> CanExecute { get; }
    }
}