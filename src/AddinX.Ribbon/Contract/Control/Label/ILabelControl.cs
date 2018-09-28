using AddinX.Ribbon.Contract.Command;

namespace AddinX.Ribbon.Contract.Control.Label {
    public interface ILabelControl : IRibbonId<ILabelControl>, IRibbonExtra<ILabelControl>,
            IRibbonCallback<ILabelCommand>
    {
    }
}