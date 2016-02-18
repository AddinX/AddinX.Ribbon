using System;
using AddinX.Core.Contract.Ribbon.Tab;

namespace AddinX.Core.Contract.Ribbon
{
    public interface IRibbon
    {
        IRibbon StartFromStrach(bool value);

        IRibbon Tabs(Action<ITabs> value);

        IRibbon ContextualTabs(Action<IContextualTabs> value);
    }
}