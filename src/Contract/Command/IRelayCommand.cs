using System;

namespace AddinX.Ribbon.Contract.Command
{
    public interface IRelayCommand
    {
        Action Execute { get; }

        Func<bool> CanExecute { get; }
    }
}
