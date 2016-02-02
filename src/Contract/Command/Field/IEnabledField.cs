using System;

namespace AddinX.Core.Contract.Command.Field
{
    public interface IEnabledField
    {
        Func<bool> IsEnabledField { get; }
    }
}