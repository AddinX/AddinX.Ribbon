using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Implementation.Command {
    public class ComboBoxCommand : ControlCommand<IComboBoxCommand>, IComboBoxCommand,
        ITextField, IDynamicItemsField {
        public Func<int> getItemCount { get; set; }
        public Func<int, string> getItemID { get; set; }
        public Func<int, string> getItemLabel { get; set; }
        public Func<int, object> getItemImage { get; set; }
        public Func<int, string> getItemScreentip { get; set; }
        public Func<int, string> getItemSupertip { get; set; }
        public Func<string> getText { get; set; }
        public Action<string> onChange { get; set; }

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

        public IComboBoxCommand ItemsScreentip(Func<int, string> itemsScreentip) {
            getItemScreentip = itemsScreentip;
            return this;
        }

        public IComboBoxCommand ItemsSupertip(Func<int, string> itemsSupertip) {
            getItemSupertip = itemsSupertip;
            return this;
        }

        public IComboBoxCommand ItemsImage(Func<int, object> itemsImage) {
            getItemImage = itemsImage;
            return this;
        }

        #region Implementation of ICommand

        protected override IComboBoxCommand Interface => this;

        /// <summary>
        ///     写入回调Xml属性
        /// </summary>
        /// <param name="element"></param>
        public override void WriteCallbackXml(XElement element) {
            base.WriteCallbackXml(element);
            element.AddCallbackAttribute("onChange", onChange);
            element.AddCallbackAttribute("getText", getText);

            element.AddCallbackAttribute("getItemCount", getItemCount);
            element.AddCallbackAttribute("getItemID",nameof(IRibbonFluentCallback.GetItemId),getItemID);
            element.AddCallbackAttribute("getItemImage", getItemImage);
            element.AddCallbackAttribute("getItemLabel", getItemLabel);
            element.AddCallbackAttribute("getItemScreentip", getItemScreentip);
            element.AddCallbackAttribute("getItemSupertip", getItemSupertip);
        }

        #endregion
    }
}