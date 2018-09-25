using System;

namespace AddinX.Ribbon.Contract.Command.Field
{
    public interface IActionField
    {
        Action OnAction { get; set; }
    }
}