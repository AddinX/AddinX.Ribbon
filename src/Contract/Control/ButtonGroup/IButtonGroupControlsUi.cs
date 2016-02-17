using AddinX.Core.Contract.Control.ButtonUnsize;
using AddinX.Core.Contract.Control.GalleryUnsize;
using AddinX.Core.Contract.Control.Menu;
using AddinX.Core.Contract.Control.MenuUnsize;
using AddinX.Core.Contract.Control.ToggleButtonUnsize;

namespace AddinX.Core.Contract.Control.ButtonGroup
{
    public interface IButtonGroupControlsUi
    {
        IButtonUnsizeIdUi AddButton(string label);
        
        IToggleButtonUnsizeIdUi AddToggleButton(string label);

        IGalleryUnsizeIdUi AddGallery(string label);

        IMenuUnsizeIdUi AddMenu(string label);
    }
}