using System;
using AddinX.Ribbon.Contract.Control.Item;

namespace AddinX.Ribbon.Contract.Control.ComboBox
{
    public interface IComboxBoxItems
    {
        IComboBoxExtra AddItems(Action<IItems> items);

        IComboBoxExtra DynamicItems();
    }
}