using System;

namespace AddinX.Ribbon.Contract.Control.MenuUnsize
{
    public interface IMenuUnsizeItems
    {
        IMenuUnsizeExtra AddItems(Action<IMenuUnsizeControls> items);
    }
}