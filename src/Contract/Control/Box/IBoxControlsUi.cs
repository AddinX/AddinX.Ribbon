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
    public interface IBoxControlsUi
    {
        IBoxUi AddBox();

        IButtonIdUi AddButton(string label);

        IButtonGroupUi AddButtonGroup();

        ICheckboxIdUi AddCheckbox(string label);

        IComboBoxIdUi AddComboBox(string label);

        IDropDownIdUi AddDropDown(string label);

        IEditBoxIdUi AddEditbox(string label);

        IGalleryIdUi AddGallery(string label);

        ILabelControlIdUi AddLabelControl();

        IMenuIdUi AddMenu(string label);

        IToggleButtonIdUi AddToggleButton(string label);
    }
}