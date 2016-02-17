using AddinX.Core.Contract.Control.ButtonUnsize;
using AddinX.Core.Contract.Control.CheckBox;
using AddinX.Core.Contract.Control.GalleryUnsize;
using AddinX.Core.Contract.Control.MenuSeparator;
using AddinX.Core.Contract.Control.ToggleButtonUnsize;

namespace AddinX.Core.Contract.Control.MenuUnsize
{
    public interface IMenuUnsizeControlsUi
    {
        IButtonUnsizeIdUi AddButton(string label);

        ICheckboxIdUi AddCheckbox(string label);
        
        IToggleButtonUnsizeIdUi AddToggleButton(string label);

        IGalleryUnsizeIdUi AddGallery(string label);

        IMenuUnsizeIdUi AddMenu(string label);

        IMenuSeparatorIdUi AddSeparator(string title);
    }
}