using System;

namespace AddinX.Ribbon.Implementation.Field
{
    public interface IVisibleField
    {
        Func<bool> IsVisibleField { get; }
    }
}