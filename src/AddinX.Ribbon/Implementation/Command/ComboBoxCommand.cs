using System;
using System.Collections.Generic;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Implementation.Command {
    public class ComboBoxCommand : AbstractCommand, IComboBoxCommand, ITextField, IEnabledField, IVisibleField, IDynamicItemsField {
        public IComboBoxCommand IsVisible(Func<bool> condition) {
            getVisible = condition;
            return this;
        }

        public IComboBoxCommand IsEnabled(Func<bool> condition) {
            getEnabled = condition;
            return this;
        }

        public IComboBoxCommand GetText(Func<string> defaultValue) {
            getText = defaultValue;
            return this;
        }

        public IComboBoxCommand OnChange(Action<string> newText) {
            onChange = newText;
            return this;
        }

        public IComboBoxCommand ItemCounts(Func<int> numberItems) {
            getItemCount = numberItems;
            return this;
        }

        public IComboBoxCommand ItemsId(Func<int, string> itemsId) {
            getItemID = itemsId;
            return this;
        }

        public IComboBoxCommand ItemsLabel(Func<int, string> itemsLabel) {
            getItemLabel = itemsLabel;
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
        public override void WriteCallbackXml(XElement element) {
            element.AddCallbackAttribute("onChange", onChange);
            element.AddCallbackAttribute("getText", getText);
            element.AddCallbackAttribute("getEnabled", getEnabled);
            element.AddCallbackAttribute("getVisible", getVisible);

            element.AddCallbackAttribute("getItemCount", getItemCount);
            element.AddCallbackAttribute("getItemID", getItemID);
            element.AddCallbackAttribute("getItemImage", ItemImage);
            element.AddCallbackAttribute("getItemLabel", getItemLabel);
            element.AddCallbackAttribute("getItemScreentip", ItemScreentip);
            element.AddCallbackAttribute("getItemSupertip", ItemSupertip);
        }

        #endregion

        public Func<int> getItemCount { get;  set; }
        public Func<int, string> getItemID { get;  set; }
        public Func<IList<object>> ItemImage { get;  set; }
        public Func<int, string> getItemLabel { get;  set; }
        public Func<IList<string>> ItemScreentip { get;  set; }
        public Func<IList<string>> ItemSupertip { get;  set; }
        public Func<bool> getEnabled { get;  set; }
        public Func<string> getText { get;  set; }
        public Action<string> onChange { get;  set; }
        public Func<bool> getVisible { get;  set; }

        public IComboBoxCommand ItemsImage(Func<IList<object>> itemsImage) {
            ItemImage = itemsImage;
            return this;
        }
    }
}