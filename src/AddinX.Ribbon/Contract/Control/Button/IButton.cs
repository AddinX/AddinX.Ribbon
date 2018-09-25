using System;
using AddinX.Ribbon.Contract.Command;

namespace AddinX.Ribbon.Contract.Control.Button {
    public interface IButton : IRibbonId<IButton>, IRibbonImage<IButton>,
        IRibbonSize<IButton>, IRibbonLabel<IButton>,IRibbonExtra<IButton>,
            IRibbonCallback<IButtonCommand>
        //IButtonCommand<IButton> 
    {

        IButton Description(string description);
    }

}