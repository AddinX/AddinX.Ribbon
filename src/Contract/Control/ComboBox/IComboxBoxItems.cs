using System;
using AddinX.Core.Contract.Control.Item;

namespace AddinX.Core.Contract.Control.ComboBox
{
    public interface IComboxBoxItems
    {
        IComboBoxExtra AddItems(Action<IItems> items);

        IComboBoxExtra DynamicItems();
    }
}