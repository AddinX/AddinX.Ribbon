using System;

namespace AddinX.Ribbon.Contract.Control.ButtonGroup
{
    public interface IButtonGroupItems
    {
        void AddItems(Action<IButtonGroupControls> items);
    }
}