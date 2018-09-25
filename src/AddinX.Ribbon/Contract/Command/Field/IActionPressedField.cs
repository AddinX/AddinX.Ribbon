using System;

namespace AddinX.Ribbon.Contract.Command.Field
{
    public interface IActionPressedField
    {
        Action<bool> onActionPressed { get; set; }
    }
}