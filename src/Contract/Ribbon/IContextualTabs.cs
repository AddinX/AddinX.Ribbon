using System;
using AddinX.Core.Contract.Ribbon.TabSet;

namespace AddinX.Core.Contract.Ribbon
{
    public interface IContextualTabs
    {
        IContextualTabs AddTabSet(Action<ITabSetId> value);
    }
}