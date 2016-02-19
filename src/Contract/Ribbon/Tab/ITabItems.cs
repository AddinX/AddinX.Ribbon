using System;
using AddinX.Ribbon.Contract.Ribbon.Group;

namespace AddinX.Ribbon.Contract.Ribbon.Tab
{
    public interface ITabItems
    {
        ITabExtra Groups(Action<IGroups> value);
    }
}