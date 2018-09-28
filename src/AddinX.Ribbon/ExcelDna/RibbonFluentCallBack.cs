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
            if (FindCallback(control.Id) is IDropDownField field) {
                field.onItemAction?.Invoke(selectedIndex);
            }
        }

        public bool GetEnabled(IRibbonControl control) {
            if (FindCallback(control.Id) is IEnabledField field) {
                  return field.getEnabled?.Invoke()??false;
            }

            return false;
        }

        public bool GetVisible(IRibbonControl control) {
            if (FindCallback(control.Id) is IVisibleField field) {
                 return field.getVisible?.Invoke()??false;
            }

            return false;
        }

        public bool GetPressed(IRibbonControl control) {
            if (FindCallback(control.Id) is IPressedField field) {
                return field.getPressed?.Invoke()??false;
            }

            return false;
        }

        public object GetImage(IRibbonControl control) {
            if (FindCallback(control.Id) is IImageField field) {
                return field.getImage?.Invoke();
            }

            return null;
        }

        public string GetText(IRibbonControl control) {
            if (FindCallback(control.Id) is ITextField field) {
                    return field.getText?.Invoke()??string.Empty;
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
                    return field.getItemCount?.Invoke()??0;
            }

            return 0;
        }

        public object GetItemId(IRibbonControl control, int index) {
            if (FindCallback(control.Id) is IDynamicItemsField field) {
                    return field.getItemID?.Invoke(index);
            }

            return null;
        }

        public object GetItemImage(IRibbonControl control, int index) {
            if (FindCallback(control.Id) is IDynamicItemsField field) {
                    return field.getItemImage?.Invoke(index);
            }

            return null;
        }

        public string GetItemLabel(IRibbonControl control, int index) {
            if (FindCallback(control.Id) is IDynamicItemsField field) {
                return field.getItemLabel?.Invoke(index)??string.Empty;
            }

            return string.Empty;
        }

        public string GetItemScreentip(IRibbonControl control, int index) {
            if (FindCallback(control.Id) is IDynamicItemsField field) {
                return field.getItemScreentip?.Invoke(index)??string.Empty;
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
                return field.getLabel?.Invoke();
            }

            return string.Empty;
        }

        public int GetSelectedItemIndex(IRibbonControl control) {
            if (FindCallback(control.Id) is IDropDownField field) {
                return field.getSelectedItemIndex?.Invoke()?? 0;
            }

            return 0;
        }
    }
}