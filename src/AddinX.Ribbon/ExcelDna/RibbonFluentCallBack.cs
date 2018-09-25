using AddinX.Ribbon.Contract.Command.Field;
using ExcelDna.Integration.CustomUI;

namespace AddinX.Ribbon.ExcelDna {
    public abstract partial class RibbonFluent {
        public void OnAction(IRibbonControl control) {
            if (!(FindCallback(control.Id) is IActionField field)) { return; }
            field.OnAction.Invoke();
        }

        public void OnActionPressed(IRibbonControl control, bool pressed) {
            var field = FindCallback(control.Id) as IActionPressedField;
            field?.onActionPressed(pressed);
        }

        public void OnActionDropDown(IRibbonControl control, string selectedId, int selectedIndex) {
            var field = FindCallback(control.Id) as IDropDownField;
            field?.OnActionField(selectedIndex);
        }

        public bool GetEnabled(IRibbonControl control) {
            return !(FindCallback(control.Id) is IEnabledField field)
                || field.getEnabled.Invoke();
        }

        public bool GetVisible(IRibbonControl control) {
            return !(FindCallback(control.Id) is IVisibleField field)
                || field.IsVisibleField.Invoke();
        }

        public bool GetPressed(IRibbonControl control) {
            return !(FindCallback(control.Id) is IPressedField field)
                || field.getPressed.Invoke();
        }

        public string GetSize(IRibbonControl control) {
            if (FindCallback(control.Id) is ISizeField field) {
                return field.getSize.Invoke().ToString();
            } else {
                return null;
            }
        }

        public object GetImage(IRibbonControl control) {
            if (FindCallback(control.Id) is IImageField field) {
                return field.getImage();
            }

            return null;
        }

        public string GetText(IRibbonControl control) {
            return !(FindCallback(control.Id) is ITextField field) ? string.Empty : field.TextField.Invoke();
        }

        public void OnChange(IRibbonControl control, string newValue) {
            var field = FindCallback(control.Id) as ITextField;
            field?.OnChangeFieldAction(newValue);
        }

        public int GetItemCount(IRibbonControl control) {
            var field = FindCallback(control.Id) as IDynamicItemsField;
            return field?.ItemCount() ?? 0;
        }

        public object GetItemId(IRibbonControl control, int index) {
            var field = FindCallback(control.Id) as IDynamicItemsField;
            var list = field?.ItemId();
            if (list == null || list.Count <= index)
                return null;
            return list[index];

        }

        public object GetItemImage(IRibbonControl control, int index) {
            var field = FindCallback(control.Id) as IDynamicItemsField;
            return field?.ItemImage()?[index];
        }

        public string GetItemLabel(IRibbonControl control, int index) {
            var field = FindCallback(control.Id) as IDynamicItemsField;
            return field?.ItemLabel()?[index];
        }

        public string GetItemScreentip(IRibbonControl control, int index) {
            var field = FindCallback(control.Id) as IDynamicItemsField;
            return field?.ItemScreentip()?[index];
        }

        public string GetItemSupertip(IRibbonControl control, int index) {
            var field = FindCallback(control.Id) as IDynamicItemsField;
            return field?.ItemSupertip()?[index];
        }

        public string GetLabel(IRibbonControl control) {
            var field = FindCallback(control.Id) as ILabelField;
            return field?.LabelField.Invoke() ?? string.Empty;
        }

        public int GetSelectedItemIndex(IRibbonControl control) {
            var field = FindCallback(control.Id) as IDropDownField;
            return field?.SelectedItemIndex?.Invoke() ?? 0;
        }

    }
}