using System;

namespace AddinX.Ribbon.Contract.Command
{
    public interface ILabelCommand : ICommand
    {
        void IsVisible(Func<bool> condition);

        void IsEnabled(Func<bool> condition);

        void GetLabel(Func<string> text);
    }
}