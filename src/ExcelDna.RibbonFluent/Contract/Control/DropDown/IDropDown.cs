using System;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Control.Item;

namespace AddinX.Ribbon.Contract.Control.DropDown {
    public interface IDropDown : IRibbonId<IDropDown>, IRibbonExtra<IDropDown>, IRibbonImage<IDropDown>,
            IRibbonItemImage<IDropDown>, IRibbonItemLabel<IDropDown>, IRibbonLabel<IDropDown>,
            IRibbonDynamic<IDropDown, IItems>,
            IRibbonCallback<IDropDownCommand>
    {
        IDropDown Buttons(Action<IDropDownControls> items);
    }
}