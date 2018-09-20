using System;

namespace AddinX.Ribbon.Implementation.Field
{
    public interface IEnabledField
    {
        Func<bool> IsEnabledField { get; }
    }
}