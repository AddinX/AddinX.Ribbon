using System;
using AddinX.Core.Contract.Control.Item;

namespace AddinX.Core.Contract.Control.DropDown
{
    public interface IDropDownItems
    {
        IDropDownExtra DynamicItems();

        IDropDownExtra AddItems(Action<IItems> items);
    }
}