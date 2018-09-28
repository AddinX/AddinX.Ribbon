using System;

namespace AddinX.Ribbon.Contract.Command.Field {
    public interface IDropDownField {
        /// <summary>
        /// getSelectedItemIndex
        /// 回调
        /// VBA：Sub GetSelectedItemIndex(control As IRibbonControl, ByRef returnedVal)
        /// C#：int GetSelectedItemIndex(IRibbonControl control)
        /// </summary>
        Func<int> getSelectedItemIndex { get; set; }

        /// <summary>
        /// onAction
        /// 回调
        /// VBA：Sub OnItemAction(control As IRibbonControl, itemID As String, itemIndex As Integer)
        /// C#：void OnItemAction(IRibbonControl control, string itemID, int itemIndex)
        /// </summary>
        Action<int> onItemAction { get; set; }
    }
}