using AddinX.Core.Contract.Control.ButtonUnsize;
using AddinX.Core.Contract.Control.GalleryUnsize;
using AddinX.Core.Contract.Control.MenuUnsize;
using AddinX.Core.Contract.Control.ToggleButtonUnsize;

namespace AddinX.Core.Contract.Control.ButtonGroup
{
    public interface IButtonGroupControls
    {
        IButtonUnsizeId AddButton(string label);
        
        IToggleButtonUnsizeId AddToggleButton(string label);

        IGalleryUnsizeId AddGallery(string label);

        IMenuUnsizeId AddMenu(string label);
    }
}