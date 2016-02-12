using System;

namespace AddinX.Core.Contract.Control.ButtonGroup
{
    public interface IButtonGroupItems
    {
        void AddItems(Action<IButtonGroupControlsUi> items);
    }
}