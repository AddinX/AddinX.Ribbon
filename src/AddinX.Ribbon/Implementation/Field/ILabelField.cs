using System;

namespace AddinX.Ribbon.Implementation.Field
{
    public interface ILabelField
    {
        Func<string> LabelField { get; }
    }
}