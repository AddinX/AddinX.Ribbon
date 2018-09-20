using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Control;

namespace AddinX.Ribbon.Contract.Ribbon.Group
{
    public interface IGroup: IGroupId
        , IGroupItems, IGroupExtra,
        IRibbonCallback<IGroup,IGroupCommand>
    {
        
    }
    

}