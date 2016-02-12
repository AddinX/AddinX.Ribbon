using System;

namespace AddinX.Core.Contract.Command
{
    public interface IBoxCommand : ICommand
    {
        void IsVisible(Func<bool> condition);
    }
}