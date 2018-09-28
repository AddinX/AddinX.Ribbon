using System;

namespace AddinX.Ribbon.Contract.Command.Field {
    public interface IEnabledField {
        /// <summary>
        /// getEnabled
        /// 回调
        /// VBA：Sub GetEnabled(control As IRibbonControl, ByRef returnedVal)
        /// C#：bool GetEnabled(IRibbonControl control)
        /// </summary>
        Func<bool> getEnabled { get; set; }
    }
}