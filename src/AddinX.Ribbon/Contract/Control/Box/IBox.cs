using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Implementation.Command;

namespace AddinX.Ribbon.Contract.Control.Box
{
    public interface IBox: IRibbonIdQ<IBox>, IRibbonStyle<IBox>, IRibbonItems<IBox,IBoxControls>,
        IRibbonCallback<IBoxCommand>
    {
         
    }
}