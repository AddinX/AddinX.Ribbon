using System;

namespace AddinX.Core.Contract.Command.Field
{
    public interface ILabelField
    {
        Func<string> LabelField { get; }
    }
}