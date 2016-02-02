using AddinX.Core.Contract.Control.ButtonItem;
using AddinX.Core.Contract.Control.CheckBox;
using AddinX.Core.Contract.Control.Gallery;
using AddinX.Core.Contract.Control.MenuSeparator;
using AddinX.Core.Contract.Control.ToggleButtonItem;

namespace AddinX.Core.Contract.Control.Menu
{
    public interface IMenuControlsUi
    {
        IButtonItemIdUi AddBouton(string label);

        ICheckboxIdUi AddCheckbox(string label);
        
        IToggleButtonItemIdUi AddToggleButton(string label);

        IGalleryIdUi AddGallery(string label);

        IMenuIdUi AddMenu(string label);

        IMenuSeparatorIdUi AddSeparator(string title);
    }
}