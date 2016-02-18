using System;

namespace AddinX.Core.Contract.Control.Box
{
    public interface IBoxItems
    {
        void AddItems(Action<IBoxControls> items);
    }
}