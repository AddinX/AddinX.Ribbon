using AddinX.Ribbon.Contract.Command;

namespace AddinX.Ribbon.Contract.Control.EditBox {
    public interface IEditBox : IRibbonId<IEditBox>, IRibbonListExtra<IEditBox>, IRibbonImage<IEditBox>,
            IRibbonCallback<IEditBoxCommand>
    {
    }
}