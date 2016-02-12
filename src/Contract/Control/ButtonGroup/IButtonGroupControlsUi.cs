using AddinX.Core.Contract.Control.Button;
using AddinX.Core.Contract.Control.Gallery;
using AddinX.Core.Contract.Control.Menu;
using AddinX.Core.Contract.Control.ToggleButton;

namespace AddinX.Core.Contract.Control.ButtonGroup
{
    public interface IButtonGroupControlsUi
    {
        IButtonIdUi AddBouton(string label);
        
        IToggleButtonIdUi AddToggleButton(string label);

        IGalleryIdUi AddGallery(string label);

        IMenuIdUi AddMenu(string label);
    }
}