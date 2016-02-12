using System;

namespace AddinX.Core.Contract.Control.Menu
{
    public interface IMenuItems
    {
        IMenuExtra AddItems(Action<IMenuControlsUi> items);
    }
}