using AddinX.Ribbon.Contract.Command.Field;
using ExcelDna.Integration.CustomUI;

namespace AddinX.Ribbon.ExcelDna {
    public abstract partial class RibbonFluent {
        public void OnAction(IRibbonControl control) {
            if (FindCallback(control.Id) is IActionField field) {
                field.onAction?.Invoke();
            }
        }

        public void OnActionPressed(IRibbonControl control, bool pressed) {
            if (FindCallback(control.Id) is IActionPressedField field) {
                field.onActionPressed?.Invoke(pressed);
            }
        }

        public void OnItemAction(IRibbonControl control, string selectedId, int selectedIndex) {
            if(FindCallback(control.Id) is IDropDownField field){
                field.onItemAction?.Invoke(selectedIndex);
            }
        }

        public bool GetEnabled(IRibbonControl control) {
            if (FindCallback(control.Id) is IEnabledField field){
                if (field.getEnabled != null) {
                    return field.getEnabled();
                }
            }

            return false;
        }

        public bool GetVisible(IRibbonControl control) {
            if(FindCallback(control.Id) is IVisibleField field){
                if (field.getVisible != null) {
                    return field.getVisible();
                }
            }

            return false;
        }

        public bool GetPressed(IRibbonControl control) {
            return !(FindCallback(control.Id) is IPressedField field)
                || field.getPressed.Invoke();
        }

        public object GetImage(IRibbonControl control) {
            if (FindCallback(control.Id) is IImageField field) {
                return field.getImage();
            }

            return null;
        }

        public string GetText(IRibbonControl control) {
            if (FindCallback(control.Id) is ITextField field){
                if (field.getText != null) {
                    return field.getText();
                }
            }
            return string.Empty;
        }

        public void OnChange(IRibbonControl control, string newValue) {
            if (FindCallback(control.Id) is ITextField field) {
                field.onChange?.Invoke(newValue);
            }
        }

        public int GetItemCount(IRibbonControl control) {
            if (FindCallback(control.Id) is IDynamicItemsField field) {
                if (field.getItemCount != null) {
                    return field.getItemCount();
                }
            }

            return 0;
        }

        public object GetItemId(IRibbonControl control, int index) {
            if (FindCallback(control.Id) is IDynamicItemsField field) {
                if (field.getItemID != null) {
                    return field.getItemID(index);
                }
            }

            return null;

        }

        public object GetItemImage(IRibbonControl control, int index) {
            if (FindCallback(control.Id) is IDynamicItemsField field) {
                if (field.getItemImage != null) {
                    return field.getItemImage(index);
                }
            }

            return null;
        }

        public string GetItemLabel(IRibbonControl control, int index) {
            if (FindCallback(control.Id) is IDynamicItemsField field) {
                if (field.getItemLabel != null) {
                    return field.getItemLabel(index);
                }
            }

            return string.Empty;
        }

        public string GetItemScreentip(IRibbonControl control, int index) {
            if (FindCallback(control.Id) is IDynamicItemsField field) {
                return field.getItemScreentip?.Invoke(index);
            }

            return string.Empty;
        }

        public string GetItemSupertip(IRibbonControl control, int index) {
            if (FindCallback(control.Id) is IDynamicItemsField field) {
                return field.getItemSupertip?.Invoke(index);
            }
            return string.Empty;
        }

        public string GetLabel(IRibbonControl control) {
            if (FindCallback(control.Id) is ILabelField field) {
                return field?.getLabel.Invoke() ?? string.Empty;
            }
            return string.Empty;
        }

        public int GetSelectedItemIndex(IRibbonControl control) {
            if (FindCallback(control.Id) is IDropDownField field) {
                return field?.getSelectedItemIndex?.Invoke() ?? 0;
            }
            return 0;
        }

    }
}