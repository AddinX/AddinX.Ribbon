using System;
using AddinX.Ribbon.Contract.Ribbon.Tab;

namespace AddinX.Ribbon.Contract.Ribbon.TabSet {
    public interface ITabSetItem {
        void Tabs(Action<ITabs> value);
    }
}