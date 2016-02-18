using System;

namespace AddinX.Core.Contract.Control.MenuUnsize
{
    public interface IMenuUnsizeItems
    {
        IMenuUnsizeExtra AddItems(Action<IMenuUnsizeControls> items);
    }
}