using System;

namespace AddinX.Ribbon.Contract.Command
{
    public interface ISeparatorCommand : ICommand
    {
        void IsVisible(Func<bool> condition);
    }
}