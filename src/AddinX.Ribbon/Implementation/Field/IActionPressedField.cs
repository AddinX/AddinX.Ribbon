using System;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Implementation.Field
{
    public class ActionPressedField: IActionPressedField
    {
        public ActionPressedField(Action<bool> action) {
            OnActionField = action;
        }

        public Action<bool> OnActionField { get; }
    }
}