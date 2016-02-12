using System;
using AddinX.Core.Contract.Ribbon.Tab;

namespace AddinX.Core.Contract.Ribbon.TabSet
{
    public interface ITabSetItem
    {
        void Tabs(Action<ITabsUi> value);
    }
}