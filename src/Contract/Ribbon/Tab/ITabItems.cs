using System;
using AddinX.Core.Contract.Ribbon.Group;

namespace AddinX.Core.Contract.Ribbon.Tab
{
    public interface ITabItems
    {
        ITabExtra Groups(Action<IGroupsUi> value);
    }
}