using System;

namespace AddinX.Core.Contract.Command.Field
{
    public interface IPressedField
    {
        Func<bool> PressedField { get; }
    }
}