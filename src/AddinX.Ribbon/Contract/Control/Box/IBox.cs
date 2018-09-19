using AddinX.Ribbon.Contract.Command;

namespace AddinX.Ribbon.Contract.Control.Box
{
    public interface IBox: IRibbonId<IBox>, IRibbonStyle<IBox>, IRibbonItems<IBox,IBoxControls>,IBoxCommand
    {
         
    }
}