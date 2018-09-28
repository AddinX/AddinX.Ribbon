using AddinX.Ribbon.Contract.Command;

namespace AddinX.Ribbon.Contract.Control.Separator {
    public interface ISeparator : IRibbonIdQ<ISeparator>, IRibbonCallback<ISeparatorCommand> {
    }
}