using AddinX.Ribbon.Contract.Command;

namespace AddinX.Ribbon.Contract.Control.Separator
{
    public interface ISeparator : ISeparatorId, IRibbonCallback<ISeparator,ISeparatorCommand> { }
}