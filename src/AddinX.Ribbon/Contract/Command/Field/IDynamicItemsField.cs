using System;

namespace AddinX.Ribbon.Contract.Command.Field {
    public interface IDynamicItemsField {
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
        Func<int, string> getItemID { get; set; }

        /// <summary>
        /// getItemImage
        /// Callback for an item's image.
        /// </summary>
        Func<int, object> getItemImage { get; set; }

        /// <summary>
        /// getItemLabel
        /// 回调
        /// VBA：Sub GetItemLabel(control As IRibbonControl, itemIndex as Integer, ByRef returnedVal)
        /// C#：string GetItemLabel(IRibbonControl control, int itemIndex)
        /// </summary>
        Func<int, string> getItemLabel { get; set; }

        /// <summary>
        /// getItemScreentip
        /// Callback for an item's screentip.
        /// </summary>
        Func<int, string> getItemScreentip { get; set; }

        /// <summary>
        /// getItemSupertip
        /// Callback for an item's supertip.
        /// </summary>
        Func<int, string> getItemSupertip { get; set; }
    }
}