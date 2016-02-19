using System;

namespace AddinX.Ribbon.Contract.Control.Box
{
    public interface IBoxItems
    {
        void AddItems(Action<IBoxControls> items);
    }
}