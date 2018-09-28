using System;

namespace AddinX.Ribbon.Contract.Command.Field {
    public interface ITextField {
        /// <summary>
        /// getText
        /// �ص�
        /// VBA��Sub GetText(control As IRibbonControl, ByRef returnedVal)
        /// C#��string GetText(IRibbonControl control)
        /// </summary>
        Func<string> getText { get; set; }

        /// <summary>
        /// onChange
        /// �ص�
        /// VBA��Sub OnChange(control As IRibbonControl, text As String)
        /// C#��void OnChange(IRibbonControl control, string text)
        /// </summary>
        Action<string> onChange { get; set; }
    }
}