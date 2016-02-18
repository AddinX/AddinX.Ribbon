using AddinX.Core.Contract.Control.Button;
using AddinX.Core.Contract.Control.ButtonGroup;
using AddinX.Core.Contract.Control.CheckBox;
using AddinX.Core.Contract.Control.ComboBox;
using AddinX.Core.Contract.Control.DropDown;
using AddinX.Core.Contract.Control.EditBox;
using AddinX.Core.Contract.Control.Gallery;
using AddinX.Core.Contract.Control.Label;
using AddinX.Core.Contract.Control.Menu;
using AddinX.Core.Contract.Control.ToggleButton;

namespace AddinX.Core.Contract.Control.Box
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