using System;

namespace AddinX.Ribbon.Contract.Command.Field {
    public interface ITextField {
        /// <summary>
        /// getText
        /// 回调
        /// VBA：Sub GetText(control As IRibbonControl, ByRef returnedVal)
        /// C#：string GetText(IRibbonControl control)
        /// </summary>
        Func<string> getText { get; set; }

        /// <summary>
        /// onChange
        /// 回调
        /// VBA：Sub OnChange(control As IRibbonControl, text As String)
        /// C#：void OnChange(IRibbonControl control, string text)
        /// </summary>
        Action<string> onChange { get; set; }
    }
}