using System;
using AddinX.Ribbon.Contract.Ribbon.TabSet;

namespace AddinX.Ribbon.Contract.Ribbon {
    public interface IContextualTabs {
        IContextualTabs AddTabSet(Action<ITabSetId> value);
    }
}