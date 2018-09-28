using System;

namespace AddinX.Ribbon.Contract.Command.Field {
    public interface IDescriptionField {
        /// <summary>
        /// getDescription
        /// »Øµ÷
        /// VBA£ºSub GetDescription(control As IRibbonControl, ByRef returnedVal)
        /// C#£ºstring GetDescription(IRibbonControl control)
        /// </summary>
        Func<string> getDescription { get; set; }
    }
}