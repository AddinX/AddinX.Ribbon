using AddinX.Core.Contract.Control.Box;
using AddinX.Core.Contract.Control.Button;
using AddinX.Core.Contract.Control.ButtonGroup;
using AddinX.Core.Contract.Control.CheckBox;
using AddinX.Core.Contract.Control.ComboBox;
using AddinX.Core.Contract.Control.DropDown;
using AddinX.Core.Contract.Control.EditBox;
using AddinX.Core.Contract.Control.Gallery;
using AddinX.Core.Contract.Control.Label;
using AddinX.Core.Contract.Control.Menu;
using AddinX.Core.Contract.Control.Separator;
using AddinX.Core.Contract.Control.ToggleButton;

namespace AddinX.Core.Contract.Ribbon.Group
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