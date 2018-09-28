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

namespace AddinX.Ribbon.Contract.Control.Box {
    public interface IBoxControls {
        IBox AddBox();

        IButton AddButton(string label);

        IButtonGroup AddButtonGroup();

        ICheckbox AddCheckbox(string label);

        IComboBox AddComboBox(string label);

        IDropDown AddDropDown(string label);

        IEditBox AddEditbox(string label);

        IGallery AddGallery(string label);

        ILabelControl AddLabelControl();

        IMenu AddMenu(string label);

        IToggleButton AddToggleButton(string label);
    }
}