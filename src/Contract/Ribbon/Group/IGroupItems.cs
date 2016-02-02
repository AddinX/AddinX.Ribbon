using System;

namespace AddinX.Core.Contract.Ribbon.Group
{
    public interface IGroupItems
    {
        IGroupExtra Items(Action<IGroupControlsUi> value);
    }
}