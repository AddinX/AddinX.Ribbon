using System;

namespace AddinX.Ribbon.Contract.Command.Field {
    public interface IActionPressedField {
        /// <summary>
        /// onAction
        /// »Øµ÷
        /// VBA£ºSub OnActionPressed(control As IRibbonControl, isPressed As Boolean)
        /// C#£ºvoid OnActionPressed(IRibbonControl control, bool isPressed)
        /// </summary>
        Action<bool> onActionPressed { get; set; }
    }
}