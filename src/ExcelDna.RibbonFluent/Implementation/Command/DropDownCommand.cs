using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Implementation.Command {
    public class DropDownCommand : AbstractCommand, IDropDownCommand, IEnabledField, IVisibleField, IDynamicItemsField,
        IDropDownField {
        public IDropDownCommand GetVisible(Func<bool> condition) {
            getVisible = condition;
            return this;
        }

        public IDropDownCommand GetEnabled(Func<bool> condition) {
            getEnabled = condition;
            return this;
        }

        public IDropDownCommand OnAction(Action<int> act) {
            onItemAction = act;
            return this;
        }

        public IDropDownCommand ItemSelectionIndex(Func<int> selectedItemIndex) {
            getSelectedItemIndex = selectedItemIndex;
            return this;
        }

        public IDropDownCommand ItemCounts(Func<int> numberItems) {
            getItemCount = numberItems;
            return this;
        }

        public IDropDownCommand ItemsId(Func<int, string> itemsId) {
            getItemID = itemsId;
            return this;
        }

        public IDropDownCommand ItemsLabel(Func<int, string> itemsLabel) {
            getItemLabel = itemsLabel;
            return this;
        }

        public IDropDownCommand ItemsScreentip(Func<int, string> itemsScreentip) {
            getItemScreentip = itemsScreentip;
            return this;
        }

        public IDropDownCommand ItemsSupertip(Func<int, string> itemsSupertip) {
            getItemSupertip = itemsSupertip;
            return this;
        }

        public IDropDownCommand ItemsImage(Func<int, object> itemsImage) {
            getItemImage = itemsImage;
            return this;
        }

        #region Implementation of ICommand

        /// <summary>
        ///     写入回调Xml属性
        /// </summary>
        /// <param name="element"></param>
        public override void WriteCallbackXml(XElement element) {
            element.AddCallbackAttribute("onAction", "OnItemAction", onItemAction);
            element.AddCallbackAttribute("getEnabled", getEnabled);
            element.AddCallbackAttribute("getVisible", getVisible);

            element.AddCallbackAttribute("getItemCount", getItemCount);
            element.AddCallbackAttribute("getItemID", "GetItemId", getItemID);
            element.AddCallbackAttribute("getItemImage", getItemImage);
            element.AddCallbackAttribute("getItemLabel", getItemLabel);
            element.AddCallbackAttribute("getItemScreentip", getItemScreentip);
            element.AddCallbackAttribute("getItemSupertip", getItemSupertip);
            element.AddCallbackAttribute("getSelectedItemIndex", getSelectedItemIndex);
        }

        #endregion

        public Action<int> onItemAction { get; set; }
        public Func<int> getSelectedItemIndex { get; set; }
        public Func<int> getItemCount { get; set; }
        public Func<int, string> getItemID { get; set; }
        public Func<int, object> getItemImage { get; set; }
        public Func<int, string> getItemLabel { get; set; }
        public Func<int, string> getItemScreentip { get; set; }
        public Func<int, string> getItemSupertip { get; set; }
        public Func<bool> getEnabled { get; set; }
        public Func<bool> getVisible { get; set; }
    }

    public abstract class DropDownRegularCommand<T> : ControlCommand<T>, IDynamicItemsCommand<T>, IDynamicItemsField where T:ICommand {
       

        #region Implementation of IDynamicItemsField

        /// <summary>
        /// getItemCount
        /// 回调
        /// VBA：Sub GetItemCount(control As IRibbonControl, ByRef returnedVal)
        /// C#：int GetItemCount(IRibbonControl control)
        /// </summary>
        public Func<int> getItemCount { get; set; }

        /// <summary>
        /// getItemID
        /// 回调
        /// VBA：Sub GetItemID(control As IRibbonControl, itemIndex As Integer, ByRef returnedVal)
        /// C#：string GetItemID(IRibbonControl control, int itemIndex)
        /// </summary>
        public Func<int, string> getItemID { get; set; }

        /// <summary>
        /// getItemImage
        /// Callback for an item's image.
        /// </summary>
        public Func<int, object> getItemImage { get; set; }

        /// <summary>
        /// getItemLabel
        /// 回调
        /// VBA：Sub GetItemLabel(control As IRibbonControl, itemIndex as Integer, ByRef returnedVal)
        /// C#：string GetItemLabel(IRibbonControl control, int itemIndex)
        /// </summary>
        public Func<int, string> getItemLabel { get; set; }

        /// <summary>
        /// getItemScreentip
        /// Callback for an item's screentip.
        /// </summary>
        public Func<int, string> getItemScreentip { get; set; }

        /// <summary>
        /// getItemSupertip
        /// Callback for an item's supertip.
        /// </summary>
        public Func<int, string> getItemSupertip { get; set; }

        #endregion

        #region Implementation of IDynamicItemsCommand<out T>

        
        public T ItemCount(Func<int> numberItems) {
            getItemCount = numberItems;
            return Interface;
        }

        public T ItemsId(Func<int, string> itemsId) {
            getItemID = itemsId;
            return Interface;
        }

        public T ItemsLabel(Func<int, string> itemLabelFunc) {
            getItemLabel = itemLabelFunc;
            return Interface;
        }

        public T ItemsScreentip(Func<int, string> itemsScreentip) {
            getItemScreentip = itemsScreentip;
            return Interface;
        }

        public T ItemsSupertip(Func<int, string> itemsSupertip) {
            getItemSupertip = itemsSupertip;
            return Interface;
        }

        public T ItemsImage(Func<int, object> itemImageFunc) {
            getItemImage = itemImageFunc;
            return Interface;
        }

        #endregion
    }
}