using AddinX.Ribbon.Contract.Control.ButtonUnsize;
using AddinX.Ribbon.Contract.Control.GalleryUnsize;
using AddinX.Ribbon.Contract.Control.MenuUnsize;
using AddinX.Ribbon.Contract.Control.ToggleButtonUnsize;

namespace AddinX.Ribbon.Contract.Control.ButtonGroup {
    public interface IButtonGroupControls {
        IButtonUnsize AddButton(string label);

        IToggleButtonUnsize AddToggleButton(string label);

        IGalleryUnsize AddGallery(string label);

        IMenuUnsize AddMenu(string label);
    }
}