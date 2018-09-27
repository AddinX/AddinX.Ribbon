using System;
using System.Collections.Generic;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Implementation.Command {
    public class DropDownCommand : AbstractCommand, IDropDownCommand, IEnabledField, IVisibleField, IDynamicItemsField, IDropDownField {
        public IDropDownCommand IsVisible(Func<bool> condition) {
            getVisible = condition;
            return this;
        }

        public IDropDownCommand IsEnabled(Func<bool> condition) {
            getEnabled = condition;
            return this;
        }

        public IDropDownCommand Action(Action<int> act) {
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

        public IDropDownCommand ItemsScreentip(Func<int,string> itemsScreentip) {
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

        public Action<int> onItemAction { get;  set; }
        public Func<int> getSelectedItemIndex { get;  set; }
        public Func<int> getItemCount { get;  set; }
        public Func<int, string> getItemID { get;  set; }
        public Func<int,object> getItemImage { get;  set; }
        public Func<int, string> getItemLabel { get;  set; }
        public Func<int ,string> getItemScreentip { get;  set; }
        public Func<int,string> getItemSupertip { get;  set; }
        public Func<bool> getEnabled { get;  set; }
        public Func<bool> getVisible { get;  set; }
    }
}