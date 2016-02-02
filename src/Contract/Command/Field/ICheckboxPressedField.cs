using System;

namespace AddinX.Core.Contract.Command.Field
{
    public interface ICheckboxPressedField
    {
        Action<bool> OnActionField { get; }
    }
}