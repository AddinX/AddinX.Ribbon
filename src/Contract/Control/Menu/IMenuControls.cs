using AddinX.Ribbon.Contract.Control.ButtonUnsize;
using AddinX.Ribbon.Contract.Control.CheckBox;
using AddinX.Ribbon.Contract.Control.GalleryUnsize;
using AddinX.Ribbon.Contract.Control.MenuSeparator;
using AddinX.Ribbon.Contract.Control.MenuUnsize;
using AddinX.Ribbon.Contract.Control.ToggleButtonUnsize;

namespace AddinX.Ribbon.Contract.Control.Menu
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