using System;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Control.Item;

namespace AddinX.Ribbon.Contract.Control.GalleryUnsize {
    public interface IGalleryUnsize : IRibbonId<IGalleryUnsize>, IRibbonGalleryExtra<IGalleryUnsize>,
            IRibbonImage<IGalleryUnsize>, IRibbonItemImage<IGalleryUnsize>, IRibbonItemLabel<IGalleryUnsize>,
            IRibbonLabel<IGalleryUnsize>, IRibbonItems<IGalleryUnsize, IItems>, IRibbonCallback<IGalleryCommand>
    {
        IGalleryUnsize Buttons(Action<IGalleryUnsizeControls> items);
    }
}