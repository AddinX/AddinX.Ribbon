using System;

namespace AddinX.Ribbon.Contract.Command.Field
{
    public interface IActionPressedField
    {
        Action<bool> OnActionField { get; }
    }
}