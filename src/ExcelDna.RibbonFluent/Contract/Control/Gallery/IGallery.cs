using System;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Control.Item;

namespace AddinX.Ribbon.Contract.Control.Gallery {
    public interface IGallery : IRibbonId<IGallery>, IRibbonGalleryExtra<IGallery>,
            IRibbonImage<IGallery>, IRibbonItemImage<IGallery>, IRibbonItemLabel<IGallery>,
            IRibbonLabel<IGallery>, IRibbonDynamic<IGallery, IItems>, IRibbonSize<IGallery>,
            IRibbonCallback<IGalleryCommand>
    {
        IGallery Buttons(Action<IGalleryControls> items);
    }
}