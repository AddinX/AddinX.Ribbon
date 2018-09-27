using System;
using System.Collections.Generic;

namespace AddinX.Ribbon.Contract.Command.Field
{
    public interface IDynamicItemsField
    {
        /// <summary>
        /// getItemCount
        /// 回调
        /// VBA：Sub GetItemCount(control As IRibbonControl, ByRef returnedVal)
        /// C#：int GetItemCount(IRibbonControl control)
        /// </summary>
        Func<int> getItemCount { get; set; }

        /// <summary>
        /// getItemID
        /// 回调
        /// VBA：Sub GetItemID(control As IRibbonControl, itemIndex As Integer, ByRef returnedVal)
        /// C#：string GetItemID(IRibbonControl control, int itemIndex)
        /// </summary>
        Func<int,string> getItemID { get; set; }

        Func<IList<object>> ItemImage { get; set; }

        /// <summary>
        /// getItemLabel
        /// 回调
        /// VBA：Sub GetItemLabel(control As IRibbonControl, itemIndex as Integer, ByRef returnedVal)
        /// C#：string GetItemLabel(IRibbonControl control, int itemIndex)
        /// </summary>
        Func<int, string> getItemLabel { get; set; } 

        Func<IList<string>> ItemScreentip { get; set; }

        Func<IList<string>> ItemSupertip { get; set; }
    }
}