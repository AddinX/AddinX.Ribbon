using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Implementation.Command {
    public class DropDownCommand : DynamicItemsCommand<IDropDownCommand>, IDropDownCommand, IEnabledField, IVisibleField, IDynamicItemsField,
        IDropDownField {

        public Action<int> onItemAction { get; set; }
        public Func<int> getSelectedItemIndex { get; set; }


        public IDropDownCommand OnItemAction(Action<int> act) {
            onItemAction = act;
            return this;
        }

        public IDropDownCommand ItemSelectionIndex(Func<int> selectedItemIndex) {
            getSelectedItemIndex = selectedItemIndex;
            return this;
        }


        #region Implementation of ICommand

        protected override IDropDownCommand Interface => this;

        /// <summary>
        ///     写入回调Xml属性
        /// </summary>
        /// <param name="element"></param>
        protected internal override void WriteXml(XElement element) {
            base.WriteXml(element);
            AddOnItemAction(element,onItemAction);
            AddGetSelectedItemIndex(element,getSelectedItemIndex);
        }

        #endregion

        
    }

    public abstract class DynamicItemsCommand<T> : ControlCommand<T>, IDynamicItemsCommand<T>, IDynamicItemsField where T:ICommand {


        /// <summary>
        ///     写入回调Xml属性
        /// </summary>
        /// <param name="element"></param>
        protected internal override void WriteXml(XElement element) {
            base.WriteXml(element);
            AddGetItemCount(element, getItemCount);
            AddGetItemID(element, getItemID);
            AddGetItemImage(element, getItemImage);
            AddGetItemLabel(element, getItemLabel);
            AddGetItemScreentip(element, getItemScreentip);
            AddGetItemSupertip(element, getItemSupertip);
        }

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

        
        public T GetItemCount(Func<int> itemCount) {
            getItemCount = itemCount;
            return Interface;
        }

        public T GetItemId(Func<int, string> itemsId) {
            getItemID = itemsId;
            return Interface;
        }

        public T GetItemLabel(Func<int, string> itemLabel) {
            getItemLabel = itemLabel;
            return Interface;
        }

        public T GetItemScreentip(Func<int, string> itemsScreentip) {
            getItemScreentip = itemsScreentip;
            return Interface;
        }

        public T GetItemSupertip(Func<int, string> itemsSupertip) {
            getItemSupertip = itemsSupertip;
            return Interface;
        }

        public T GetItemImage(Func<int, object> itemImage) {
            getItemImage = itemImage;
            return Interface;
        }

        #endregion
    }
}