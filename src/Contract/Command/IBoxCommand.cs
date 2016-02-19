using System;

namespace AddinX.Ribbon.Contract.Command
{
    public interface IBoxCommand : ICommand
    {
        void IsVisible(Func<bool> condition);
    }
}