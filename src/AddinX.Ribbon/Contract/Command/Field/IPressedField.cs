using System;

namespace AddinX.Ribbon.Contract.Command.Field
{
    public interface IPressedField
    {
        Func<bool> getPressed { get; set; }
    }
}