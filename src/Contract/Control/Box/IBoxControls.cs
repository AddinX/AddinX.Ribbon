using AddinX.Ribbon.Contract.Control.Button;
using AddinX.Ribbon.Contract.Control.ButtonGroup;
using AddinX.Ribbon.Contract.Control.CheckBox;
using AddinX.Ribbon.Contract.Control.ComboBox;
using AddinX.Ribbon.Contract.Control.DropDown;
using AddinX.Ribbon.Contract.Control.EditBox;
using AddinX.Ribbon.Contract.Control.Gallery;
using AddinX.Ribbon.Contract.Control.Label;
using AddinX.Ribbon.Contract.Control.Menu;
using AddinX.Ribbon.Contract.Control.ToggleButton;

namespace AddinX.Ribbon.Contract.Control.Box
{
    public interface IBoxControls
    {
        IBoxId AddBox();

        IButtonId AddButton(string label);

        IButtonGroupId AddButtonGroup();

        ICheckboxId AddCheckbox(string label);

        IComboBoxId AddComboBox(string label);

        IDropDownId AddDropDown(string label);

        IEditBoxId AddEditbox(string label);

        IGalleryId AddGallery(string label);

        ILabelControlId AddLabelControl();

        IMenuId AddMenu(string label);

        IToggleButtonId AddToggleButton(string label);
    }
}