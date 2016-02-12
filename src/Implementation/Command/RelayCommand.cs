using System;
using AddinX.Core.Contract.Command;

namespace AddinX.Core.Implementation.Command
{
    class RelayCommand : IRelayCommand
    {
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            Execute = execute;
            CanExecute = canExecute;
        }

        public Action Execute { get; }
        public Func<bool> CanExecute { get; }
    }
}