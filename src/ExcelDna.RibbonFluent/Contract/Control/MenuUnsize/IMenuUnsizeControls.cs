using AddinX.Ribbon.Contract.Control.ButtonUnsize;
using AddinX.Ribbon.Contract.Control.CheckBox;
using AddinX.Ribbon.Contract.Control.GalleryUnsize;
using AddinX.Ribbon.Contract.Control.MenuSeparator;
using AddinX.Ribbon.Contract.Control.ToggleButtonUnsize;

namespace AddinX.Ribbon.Contract.Control.MenuUnsize {
    public interface IMenuUnsizeControls {
        IButtonUnsize AddButton(string label);

        ICheckbox AddCheckbox(string label);

        IToggleButtonUnsize AddToggleButton(string label);

        IGalleryUnsize AddGallery(string label);

        IMenuUnsize AddMenu(string label);

        IMenuSeparator AddSeparator();
    }
}