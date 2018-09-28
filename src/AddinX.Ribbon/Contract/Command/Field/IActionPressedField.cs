using System;

namespace AddinX.Ribbon.Contract.Command.Field {
    public interface IActionPressedField {
        /// <summary>
        /// onAction
        /// �ص�
        /// VBA��Sub OnActionPressed(control As IRibbonControl, isPressed As Boolean)
        /// C#��void OnActionPressed(IRibbonControl control, bool isPressed)
        /// </summary>
        Action<bool> onActionPressed { get; set; }
    }
}