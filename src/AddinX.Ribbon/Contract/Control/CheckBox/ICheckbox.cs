using AddinX.Ribbon.Contract.Command;

namespace AddinX.Ribbon.Contract.Control.CheckBox {
    public interface ICheckbox : IRibbonId<ICheckbox>, IRibbonExtra<ICheckbox>,
        IRibbonCallback<ICheckBoxCommand> {
    }
}