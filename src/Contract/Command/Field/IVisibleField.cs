using System;

namespace AddinX.Core.Contract.Command.Field
{
    public interface IVisibleField
    {
        Func<bool> IsVisibleField { get; }
    }
}