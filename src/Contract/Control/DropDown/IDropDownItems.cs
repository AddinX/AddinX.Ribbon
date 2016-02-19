using System;
using AddinX.Ribbon.Contract.Control.Item;

namespace AddinX.Ribbon.Contract.Control.DropDown
{
    public interface IDropDownItems
    {
        IDropDownExtra DynamicItems();

        IDropDownExtra AddItems(Action<IItems> items);
    }
}