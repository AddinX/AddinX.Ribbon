using System;
using AddinX.Ribbon.Contract.Control.Item;

namespace AddinX.Ribbon.Contract.Control.Gallery
{
    public interface IGalleryItems
    {
        IGalleryExtra DynamicItems();

        IGalleryExtra AddItems(Action<IItems> items);
    }
}