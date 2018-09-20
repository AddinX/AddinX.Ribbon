using System;
using System.Collections.Generic;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Implementation.Command {
    public class GalleryCommand : IGalleryCommand, IEnabledField, IVisibleField, IDynamicItemsField, IDropDownField {
        public Action<int> OnActionField { get; private set; }
        public Func<bool> IsEnabledField { get; private set; }
        public Func<bool> IsVisibleField { get; private set; }
        public Func<int> ItemCount { get; private set; }
        public Func<IList<object>> ItemId { get; private set; }
        public Func<IList<object>> ItemImage { get; private set; }
        public Func<IList<string>> ItemLabel { get; private set; }
        public Func<IList<string>> ItemScreentip { get; private set; }
        public Func<IList<string>> ItemSupertip { get; private set; }
        public Func<int> SelectedItemIndex { get; private set; }

        public GalleryCommand() {
            //IsVisibleField = () => true;
            //IsEnabledField = () => true;
            //ItemCount = () => 0;
            //ItemScreentip = () => null;
            //ItemSupertip = () => null;
            //ItemLabel = () => null;
            //ItemImage = () => null;
            //ItemId = () => null;
        }

        public IGalleryCommand IsVisible(Func<bool> condition) {
            IsVisibleField = condition;
            return this;
        }

        public IGalleryCommand IsEnabled(Func<bool> condition) {
            IsEnabledField = condition;
            return this;
        }

        public IGalleryCommand Action(Action<int> act) {
            OnActionField = act;
            return this;
        }

        public IGalleryCommand ItemSelectionIndex(Func<int> selectedItemIndex) {
            SelectedItemIndex = selectedItemIndex;
            return this;
        }

        public IGalleryCommand ItemCounts(Func<int> numberItems) {
            ItemCount = numberItems;
            return this;
        }

        public IGalleryCommand ItemsId(Func<IList<object>> itemsId) {
            ItemId = itemsId;
            return this;
        }

        public IGalleryCommand ItemsLabel(Func<IList<string>> itemsLabel) {
            ItemLabel = itemsLabel;
            return this;
        }

        public IGalleryCommand ItemsScreentip(Func<IList<string>> itemsScreentip) {
            ItemScreentip = itemsScreentip;
            return this;
        }

        public IGalleryCommand ItemsSupertip(Func<IList<string>> itemsSupertip) {
            ItemSupertip = itemsSupertip;
            return this;
        }

        public IGalleryCommand ItemsImage(Func<IList<object>> itemsImage) {
            ItemImage = itemsImage;
            return this;
        }

        #region Implementation of ICommand

        /// <summary>
        /// 写入回调Xml属性
        /// </summary>
        /// <param name="element"></param>
        public void WriteCallbackXml(XElement element) {
            element.AddCallbackAttribute("onAction", OnActionField);
            element.AddCallbackAttribute("getEnabled", IsEnabledField);
            element.AddCallbackAttribute("getVisible", IsVisibleField);

            element.AddCallbackAttribute("getItemCount", ItemCount);
            element.AddCallbackAttribute("getItemID", "GetItemId", ItemId);
            element.AddCallbackAttribute("getItemImage", ItemImage);
            element.AddCallbackAttribute("getItemLabel", ItemLabel);
            element.AddCallbackAttribute("getItemScreentip", ItemScreentip);
            element.AddCallbackAttribute("getItemSupertip", ItemSupertip);
            element.AddCallbackAttribute("getSelectedItemIndex", SelectedItemIndex);
        }

        #endregion
    }
}