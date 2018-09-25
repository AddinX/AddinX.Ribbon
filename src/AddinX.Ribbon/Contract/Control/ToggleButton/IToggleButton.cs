using AddinX.Ribbon.Contract.Command;

namespace AddinX.Ribbon.Contract.Control.ToggleButton
{
    public interface IToggleButton : IRibbonId<IToggleButton>,IRibbonLabel<IToggleButton>
        ,IRibbonSize<IToggleButton>,IRibbonImage<IToggleButton>,IRibbonExtra<IToggleButton>,
            IRibbonCallback<IToggleButtonCommand>
    //    IToggleButtonId, IToggleButtonLabel, IToggleButtonSize, IToggleButtonImage,IToggleButtonExtra 
    { }
}