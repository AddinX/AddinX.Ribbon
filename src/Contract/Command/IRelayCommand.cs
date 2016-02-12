using System;

namespace AddinX.Core.Contract.Command
{
    public interface IRelayCommand
    {
        Action Execute { get; }

        Func<bool> CanExecute { get; }
    }
}
