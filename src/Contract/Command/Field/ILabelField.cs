using System;

namespace AddinX.Ribbon.Contract.Command.Field
{
    public interface ILabelField
    {
        Func<string> LabelField { get; }
    }
}