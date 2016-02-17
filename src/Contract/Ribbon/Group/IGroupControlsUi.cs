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
    public interface IGroupControlsUi
    {
        IBoxUi AddBox();

        IButtonIdUi AddButton(string label);

        ICheckboxIdUi AddCheckbox(string label);

        IEditBoxIdUi AddEditbox(string label);

        ILabelControlIdUi AddLabelControl();

        ISeparatorIdUi AddSeparator();

        IToggleButtonIdUi AddToggleButton(string label);

        IComboBoxIdUi AddComboBox(string label);

        IDropDownIdUi AddDropDown(string label);

        IGalleryIdUi AddGallery(string label);

        IMenuIdUi AddMenu(string label);

        IButtonGroupUi AddButtonGroup();
    }
}