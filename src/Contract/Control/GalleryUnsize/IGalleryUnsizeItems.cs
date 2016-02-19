using System;
using AddinX.Ribbon.Contract.Control.Item;

namespace AddinX.Ribbon.Contract.Control.GalleryUnsize
{
    public interface IGalleryUnsizeItems
    {
        IGalleryUnsizeExtra DynamicItems();

        IGalleryUnsizeExtra AddItems(Action<IItems> items);
    }
}