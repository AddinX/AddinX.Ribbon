using System;
using System.Collections.Generic;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Implementation.Command {
    public class ComboBoxCommand : IComboBoxCommand, ITextField, IEnabledField, IVisibleField, IDynamicItemsField {
        public IComboBoxCommand IsVisible(Func<bool> condition) {
            IsVisibleField = condition;
            return this;
        }

        public IComboBoxCommand IsEnabled(Func<bool> condition) {
            getEnabled = condition;
            return this;
        }

        public IComboBoxCommand GetText(Func<string> defaultValue) {
            TextField = defaultValue;
            return this;
        }

        public IComboBoxCommand OnChange(Action<string> newText) {
            OnChangeFieldAction = newText;
            return this;
        }

        public IComboBoxCommand ItemCounts(Func<int> numberItems) {
            ItemCount = numberItems;
            return this;
        }

        public IComboBoxCommand ItemsId(Func<IList<object>> itemsId) {
            ItemId = itemsId;
            return this;
        }

        public IComboBoxCommand ItemsLabel(Func<IList<string>> itemsLabel) {
            ItemLabel = itemsLabel;
            return this;
        }

        public IComboBoxCommand ItemsScreentip(Func<IList<string>> itemsScreentip) {
            ItemScreentip = itemsScreentip;
            return this;
        }

        public IComboBoxCommand ItemsSupertip(Func<IList<string>> itemsSupertip) {
            ItemSupertip = itemsSupertip;
            return this;
        }

        #region Implementation of ICommand

        /// <summary>
        ///     写入回调Xml属性
        /// </summary>
        /// <param name="element"></param>
        public void WriteCallbackXml(XElement element) {
            element.AddCallbackAttribute("onChange", OnChangeFieldAction);
            element.AddCallbackAttribute("getText", TextField);
            element.AddCallbackAttribute("getEnabled", getEnabled);
            element.AddCallbackAttribute("getVisible", IsVisibleField);

            element.AddCallbackAttribute("getItemCount", ItemCount);
            element.AddCallbackAttribute("getItemID", ItemId);
            element.AddCallbackAttribute("getItemImage", ItemImage);
            element.AddCallbackAttribute("getItemLabel", ItemLabel);
            element.AddCallbackAttribute("getItemScreentip", ItemScreentip);
            element.AddCallbackAttribute("getItemSupertip", ItemSupertip);
        }

        #endregion

        public Func<int> ItemCount { get;  set; }
        public Func<IList<object>> ItemId { get;  set; }
        public Func<IList<object>> ItemImage { get;  set; }
        public Func<IList<string>> ItemLabel { get;  set; }
        public Func<IList<string>> ItemScreentip { get;  set; }
        public Func<IList<string>> ItemSupertip { get;  set; }
        public Func<bool> getEnabled { get;  set; }
        public Func<string> TextField { get;  set; }
        public Action<string> OnChangeFieldAction { get;  set; }
        public Func<bool> IsVisibleField { get;  set; }

        public IComboBoxCommand ItemsImage(Func<IList<object>> itemsImage) {
            ItemImage = itemsImage;
            return this;
        }
    }
}