using AddinX.Ribbon.Contract.Command;

namespace AddinX.Ribbon.Contract.Control.ButtonGroup {
    public interface IButtonGroup : IRibbonId<IButtonGroup>, IRibbonItems<IButtonGroup, IButtonGroupControls>,
        IRibbonCallback<IButtonGroupCommand> {
    }
}