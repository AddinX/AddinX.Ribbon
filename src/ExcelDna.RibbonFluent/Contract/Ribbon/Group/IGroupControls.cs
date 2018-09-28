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

namespace AddinX.Ribbon.Contract.Ribbon.Group {
    public interface IGroupControls {
        IBox AddBox();

        IButton AddButton(string label);

        ICheckbox AddCheckbox(string label);

        IEditBox AddEditbox(string label);

        ILabelControl AddLabelControl();

        ISeparator AddSeparator();

        IToggleButton AddToggleButton(string label);

        IComboBox AddComboBox(string label);

        IDropDown AddDropDown(string label);

        IGallery AddGallery(string label);

        IMenu AddMenu(string label);

        IButtonGroup AddButtonGroup();
    }
}