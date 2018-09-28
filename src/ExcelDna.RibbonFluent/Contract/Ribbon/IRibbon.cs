using System;
using AddinX.Ribbon.Contract.Ribbon.Tab;

namespace AddinX.Ribbon.Contract.Ribbon {
    public interface IRibbon {
        IRibbon StartFromStrach(bool value);

        IRibbon Tabs(Action<ITabs> value);

        IRibbon ContextualTabs(Action<IContextualTabs> value);
    }
}