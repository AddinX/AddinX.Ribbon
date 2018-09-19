using System;

namespace AddinX.Ribbon.Contract.Ribbon.Group
{
    public interface IGroupItems
    {
        IGroupExtra Items(Action<IGroupControls> value);
    }
}