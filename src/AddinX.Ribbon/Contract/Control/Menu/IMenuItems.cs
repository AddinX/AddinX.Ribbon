using System;

namespace AddinX.Ribbon.Contract.Control.Menu
{
    public interface IMenuItems
    {
        IMenuExtra AddItems(Action<IMenuControls> items);
    }
}