using System;
using AddinX.Core.Contract.Ribbon.TabSet;

namespace AddinX.Core.Contract.Ribbon
{
    public interface IContextualTabsUi
    {
        IContextualTabsUi AddTabSet(Action<ITabSetUi> value);
    }
}