using AddinX.Core.Contract.Control.ButtonUnsize;
using AddinX.Core.Contract.Control.CheckBox;
using AddinX.Core.Contract.Control.GalleryUnsize;
using AddinX.Core.Contract.Control.MenuSeparator;
using AddinX.Core.Contract.Control.MenuUnsize;
using AddinX.Core.Contract.Control.ToggleButtonUnsize;

namespace AddinX.Core.Contract.Control.Menu
{
    public interface IMenuControls
    {
        IButtonUnsizeId AddButton(string label);

        ICheckboxId AddCheckbox(string label);
        
        IToggleButtonUnsizeId AddToggleButton(string label);

        IGalleryUnsizeId AddGallery(string label);

        IMenuUnsizeId AddMenu(string label);

        IMenuSeparatorId AddSeparator(string title);
    }
}