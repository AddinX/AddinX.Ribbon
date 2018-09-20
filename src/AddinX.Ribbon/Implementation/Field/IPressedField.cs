using System;

namespace AddinX.Ribbon.Implementation.Field
{
    public interface IPressedField
    {
        Func<bool> PressedField { get; }
    }
}