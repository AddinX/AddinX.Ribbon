using System;

namespace AddinX.Ribbon.Contract.Command.Field {
    public interface IVisibleField {
        /// <summary>
        /// getVisible
        /// »Øµ÷
        /// VBA£ºSub GetVisible(control As IRibbonControl, ByRef returnedVal)
        /// C#£ºbool GetVisible(IRibbonControl control)
        /// </summary>
        Func<bool> getVisible { get; set; }
    }
}