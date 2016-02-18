using System;

namespace AddinX.Core.Contract.Command.Field
{
    public interface IActionPressedField
    {
        Action<bool> OnActionField { get; }
    }
}