using System;
using AddinX.Ribbon.Contract.Control;
using AddinX.Ribbon.Contract.Ribbon.Group;

namespace AddinX.Ribbon.Contract.Ribbon.Tab {
    public interface ITab : IRibbonId<ITab>, IRibbonKeytip<ITab>
        //ITabItems, 
    {
        ITab Groups(Action<IGroups> value);
    }
}