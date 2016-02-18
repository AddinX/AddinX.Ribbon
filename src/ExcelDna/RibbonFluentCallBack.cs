using AddinX.Core.Contract.Command.Field;
using ExcelDna.Integration.CustomUI;

namespace AddinX.Core.ExcelDna
{
    public abstract partial class RibbonFluent
    {
        public void OnAction(IRibbonControl control)
        {
            var field = FindRibbonCmd(control.Id) as IActionField;
            if (field == null) { return; }

            if (field.OnActionField.CanExecute.Invoke())
            {
                field.OnActionField.Execute.Invoke();
            };
        }

        public void OnActionPressed(IRibbonControl control, bool pressed)
        {
            var field = FindRibbonCmd(control.Id) as IActionPressedField;
            field?.OnActionField(pressed);
        }

        public void OnActionDropDown(IRibbonControl control, string selectedId, int selectedIndex)
        {
            var field = FindRibbonCmd(control.Id) as IDropDownField;
            field?.OnActionField(selectedIndex);
        }

        public bool GetEnabled(IRibbonControl control)
        {
            var field = FindRibbonCmd(control.Id) as IEnabledField;
            return field == null
                || field.IsEnabledField.Invoke();
        }

        public bool GetVisible(IRibbonControl control)
        {
            var field = FindRibbonCmd(control.Id) as IVisibleField;
            return field == null
                || field.IsVisibleField.Invoke();
        }

        public bool GetPressed(IRibbonControl control)
        {
            var field = FindRibbonCmd(control.Id) as IPressedField;
            return field == null
                || field.PressedField.Invoke();
        }

        public string GetText(IRibbonControl control)
        {
            var field = FindRibbonCmd(control.Id) as ITextField;
            return field == null ? string.Empty : field.TextField.Invoke();
        }

        public void OnChange(IRibbonControl control, string newValue)
        {
            var field = FindRibbonCmd(control.Id) as ITextField;
            field?.OnChangeFieldAction(newValue);
        }

        public int GetItemCount(IRibbonControl control)
        {
            var field = FindRibbonCmd(control.Id) as IDynamicItemsField;
            return field?.ItemCount() ?? 0;
        }

        public object GetItemId(IRibbonControl control, int index)
        {
            var field = FindRibbonCmd(control.Id) as IDynamicItemsField;
            var list = field?.ItemId();
            if (list == null || list.Count <= index)
                return null;
            return list[index];

        }

        public object GetItemImage(IRibbonControl control, int index)
        {
            var field = FindRibbonCmd(control.Id) as IDynamicItemsField;
            return field?.ItemImage()?[index];
        }

        public string GetItemLabel(IRibbonControl control, int index)
        {
            var field = FindRibbonCmd(control.Id) as IDynamicItemsField;
            return field?.ItemLabel()?[index];
        }

        public string GetItemScreentip(IRibbonControl control, int index)
        {
            var field = FindRibbonCmd(control.Id) as IDynamicItemsField;
            return field?.ItemScreentip()?[index];
        }

        public string GetItemSupertip(IRibbonControl control, int index)
        {
            var field = FindRibbonCmd(control.Id) as IDynamicItemsField;
            return field?.ItemSupertip()?[index];
        }

        public string GetLabel(IRibbonControl control)
        {
            var field = FindRibbonCmd(control.Id) as ILabelField;
            return field?.LabelField.Invoke() ?? string.Empty;
        }

        public int GetSelectedItemIndex(IRibbonControl control)
        {
            var field = FindRibbonCmd(control.Id) as IDropDownField;
            return field?.SelectedItemIndex?.Invoke() ?? 0;
        }

    }
}