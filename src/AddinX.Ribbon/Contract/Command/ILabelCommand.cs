using System;

namespace AddinX.Ribbon.Contract.Command
{
    public interface ILabelCommand : ICommand
    {
        ILabelCommand IsVisible(Func<bool> condition);

        ILabelCommand IsEnabled(Func<bool> condition);

        ILabelCommand GetLabel(Func<string> text);
    }
}