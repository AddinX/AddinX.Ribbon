using System;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Implementation.Field
{

    public class ActionField: IActionField
    {
        public ActionField(Action action) {
            this.OnActionField = action;
        }

        public Action OnActionField { get; }

    }
}