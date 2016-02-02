using System;

namespace AddinX.Core.Contract.Command
{
    public interface ISeparatorCommand : ICommand
    {
        void IsVisible(Func<bool> condition);
    }
}