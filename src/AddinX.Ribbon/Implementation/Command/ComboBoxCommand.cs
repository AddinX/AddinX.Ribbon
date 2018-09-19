using System;
using System.Collections.Generic;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Implementation.Command {
    public class ComboBoxCommand : IComboBoxCommand, ITextField, IEnabledField, IVisibleField, IDynamicItemsField {
        public Func<string> TextField { get; private set; }
        public Action<string> OnChangeFieldAction { get; private set; }
        public Func<bool> IsEnabledField { get; private set; }
        public Func<bool> IsVisibleField { get; private set; }
        public Func<int> ItemCount { get; private set; }
        public Func<IList<object>> ItemId { get; private set; }
        public Func<IList<object>> ItemImage { get; private set; }
        public Func<IList<string>> ItemLabel { get; private set; }
        public Func<IList<string>> ItemScreentip { get; private set; }
        public Func<IList<string>> ItemSupertip { get; private set; }

        public ComboBoxCommand() {
            IsVisibleField = () => true;
            IsEnabledField = () => true;
            TextField = () => string.Empty;
            ItemCount = () => 0;
            ItemScreentip = () => null;
            ItemSupertip = () => null;
            ItemLabel = () => null;
            ItemImage = () => null;
            ItemId = () => null;
        }

        public IComboBoxCommand IsVisible(Func<bool> condition) {
            IsVisibleField = condition;
            return this;
        }

        public IComboBoxCommand IsEnabled(Func<bool> condition) {
            IsEnabledField = condition;
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

        public IComboBoxCommand ItemsImage(Func<IList<object>> itemsImage) {
            ItemImage = itemsImage;
            return this;
        }
    }
}