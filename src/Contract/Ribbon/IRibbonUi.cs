using System;
using AddinX.Core.Contract.Ribbon.Tab;

namespace AddinX.Core.Contract.Ribbon
{
    public interface IRibbonUi
    {
        IRibbonUi StartFromStrach(bool value);

        IRibbonUi Tabs(Action<ITabsUi> value);

        IRibbonUi ContextualTabs(Action<IContextualTabsUi> value);
    }
}