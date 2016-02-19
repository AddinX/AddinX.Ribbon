using AddinX.Ribbon.Contract.Control.Box;
using AddinX.Ribbon.Contract.Control.Button;
using AddinX.Ribbon.Contract.Control.ButtonGroup;
using AddinX.Ribbon.Contract.Control.CheckBox;
using AddinX.Ribbon.Contract.Control.ComboBox;
using AddinX.Ribbon.Contract.Control.DropDown;
using AddinX.Ribbon.Contract.Control.EditBox;
using AddinX.Ribbon.Contract.Control.Gallery;
using AddinX.Ribbon.Contract.Control.Label;
using AddinX.Ribbon.Contract.Control.Menu;
using AddinX.Ribbon.Contract.Control.Separator;
using AddinX.Ribbon.Contract.Control.ToggleButton;

namespace AddinX.Ribbon.Contract.Ribbon.Group
{
    public interface IGroupControls
    {
        IBoxId AddBox();

        IButtonId AddButton(string label);

        ICheckboxId AddCheckbox(string label);

        IEditBoxId AddEditbox(string label);

        ILabelControlId AddLabelControl();

        ISeparatorId AddSeparator();

        IToggleButtonId AddToggleButton(string label);

        IComboBoxId AddComboBox(string label);

        IDropDownId AddDropDown(string label);

        IGalleryId AddGallery(string label);

        IMenuId AddMenu(string label);

        IButtonGroupId AddButtonGroup();
    }
}