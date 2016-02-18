using System;
using AddinX.Core.Contract.Control.Item;

namespace AddinX.Core.Contract.Control.GalleryUnsize
{
    public interface IGalleryUnsizeItems
    {
        IGalleryUnsizeExtra DynamicItems();

        IGalleryUnsizeExtra AddItems(Action<IItems> items);
    }
}