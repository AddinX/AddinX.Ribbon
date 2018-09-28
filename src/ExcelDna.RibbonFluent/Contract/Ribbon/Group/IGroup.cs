using System;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Control;

namespace AddinX.Ribbon.Contract.Ribbon.Group {
    public interface IGroup : IRibbonId<IGroup>, IRibbonExtra<IGroup>, IRibbonItems<IGroup, IGroupControls>,
            IRibbonCallback<IGroupCommand>
        //IGroupId , IGroupItems, IGroupExtra,
    {
        IGroup DialogBoxLauncher(Action<IGroupDialogBox> dialogBox);
    }
}