using System;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Control.Gallery;
using AddinX.Ribbon.Contract.Control.Item;

namespace AddinX.Ribbon.Contract.Control.GalleryUnsize
{
    public interface IGalleryUnsize : IRibbonId<IGalleryUnsize>,IRibbonGalleryExtra<IGalleryUnsize>,
        IRibbonImage<IGalleryUnsize>,IRibbonItemImage<IGalleryUnsize>,IRibbonItemLabel<IGalleryUnsize>,
        IRibbonLabel<IGalleryUnsize>,IRibbonItems<IGalleryUnsize, IItems>, IRibbonCallback<IGalleryCommand>
    //IGalleryUnsizeExtra, IGalleryUnsizeId,
    //IGalleryUnsizeImage, IGalleryUnsizeItemImage, IGalleryUnsizeItemLabel,
    //IGalleryUnsizeLabel, IGalleryUnsizeItems
    {
        IGalleryUnsize AddButtons(Action<IGalleryUnsizeControls> items);
    }
}