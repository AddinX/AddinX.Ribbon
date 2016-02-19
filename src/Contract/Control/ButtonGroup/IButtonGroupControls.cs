using AddinX.Ribbon.Contract.Control.ButtonUnsize;
using AddinX.Ribbon.Contract.Control.GalleryUnsize;
using AddinX.Ribbon.Contract.Control.MenuUnsize;
using AddinX.Ribbon.Contract.Control.ToggleButtonUnsize;

namespace AddinX.Ribbon.Contract.Control.ButtonGroup
{
    public interface IButtonGroupControls
    {
        IButtonUnsizeId AddButton(string label);
        
        IToggleButtonUnsizeId AddToggleButton(string label);

        IGalleryUnsizeId AddGallery(string label);

        IMenuUnsizeId AddMenu(string label);
    }
}