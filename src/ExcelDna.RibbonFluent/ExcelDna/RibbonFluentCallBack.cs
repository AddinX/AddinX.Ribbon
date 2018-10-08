using AddinX.Ribbon.Contract.Command.Field;
using AddinX.Ribbon.Contract.Enums;
using ExcelDna.Integration.CustomUI;

namespace AddinX.Ribbon.ExcelDna {
    public abstract partial class RibbonFluent {
        private const string DefaultLabel = "";

        /// <inheritdoc />
        public void OnAction(IRibbonControl control) {
            if (FindCallback(control.Id) is IActionField field) field.onAction?.Invoke();
        }

        /// <inheritdoc />
        public void OnActionPressed(IRibbonControl control, bool pressed) {
            if (FindCallback(control.Id) is IActionPressedField field) field.onActionPressed?.Invoke(pressed);
        }

        /// <inheritdoc />
        public void OnItemAction(IRibbonControl control, string selectedId, int selectedIndex) {
            if (FindCallback(control.Id) is IDropDownField field) field.onItemAction?.Invoke(selectedIndex);
        }

        /// <inheritdoc />
        public void OnChange(IRibbonControl control, string newValue) {
            if (FindCallback(control.Id) is ITextField field) field.onChange?.Invoke(newValue);
        }

        /// <inheritdoc />
        public bool GetPressed(IRibbonControl control) {
            if (FindCallback(control.Id) is IPressedField field) return field.getPressed?.Invoke() ?? false;

            return false;
        }

        /// <inheritdoc />
        public object GetImage(IRibbonControl control) {
            if (FindCallback(control.Id) is IImageField field) return field.getImage?.Invoke();

            return null;
        }

        /// <inheritdoc />
        public string GetText(IRibbonControl control) {
            if (FindCallback(control.Id) is ITextField field) return field.getText?.Invoke() ?? DefaultLabel;

            return DefaultLabel;
        }


        public bool GetVisible(IRibbonControl control) {
            if (FindCallback(control.Id) is IVisibleField field) return field.getVisible?.Invoke() ?? false;

            return false;
        }

        /// <inheritdoc />
        public bool GetEnabled(IRibbonControl control) {
            if (FindCallback(control.Id) is IEnabledField field) return field.getEnabled?.Invoke() ?? true;

            return true;
        }

        public int GetItemCount(IRibbonControl control) {
            if (FindCallback(control.Id) is IDynamicItemsField field) return field.getItemCount?.Invoke() ?? 0;

            return 0;
        }

        /// <inheritdoc />
        public object GetItemId(IRibbonControl control, int index) {
            if (FindCallback(control.Id) is IDynamicItemsField field) return field.getItemID?.Invoke(index);

            return null;
        }

        /// <inheritdoc />
        public object GetItemImage(IRibbonControl control, int index) {
            if (FindCallback(control.Id) is IDynamicItemsField field) return field.getItemImage?.Invoke(index);

            return null;
        }

        /// <inheritdoc />
        public string GetItemLabel(IRibbonControl control, int index) {
            if (FindCallback(control.Id) is IDynamicItemsField field)
                return field.getItemLabel?.Invoke(index) ?? DefaultLabel;

            return DefaultLabel;
        }

        /// <inheritdoc />
        public string GetItemScreentip(IRibbonControl control, int index) {
            if (FindCallback(control.Id) is IDynamicItemsField field)
                return field.getItemScreentip?.Invoke(index) ?? DefaultLabel;

            return DefaultLabel;
        }

        /// <inheritdoc />
        public string GetItemSupertip(IRibbonControl control, int index) {
            if (FindCallback(control.Id) is IDynamicItemsField field)
                return field.getItemSupertip?.Invoke(index) ?? DefaultLabel;

            return DefaultLabel;
        }

        /// <inheritdoc />
        public string GetLabel(IRibbonControl control) {
            if (FindCallback(control.Id) is ILabelField field) return field.getLabel?.Invoke() ?? DefaultLabel;

            return DefaultLabel;
        }

        /// <inheritdoc />
        public int GetSelectedItemIndex(IRibbonControl control) {
            const int defaultValue = 0;
            if (FindCallback(control.Id) is IDropDownField field)
                return field.getSelectedItemIndex?.Invoke() ?? defaultValue;

            return defaultValue;
        }

        /// <inheritdoc />
        /// <summary>
        ///     getSize Callback
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public string GetSize(IRibbonControl control) {
            const string defaultValue = nameof(ControlSize.normal);
            if (FindCallback(control.Id) is ISizeField field) return field.getSize?.Invoke().ToString() ?? defaultValue;

            return defaultValue;
        }

        /// <inheritdoc />
        public string GetDescription(IRibbonControl control) {
            if (FindCallback(control.Id) is IDescriptionField field) return field.getDescription?.Invoke() ?? DefaultLabel;

            return DefaultLabel;
        }
    }
}