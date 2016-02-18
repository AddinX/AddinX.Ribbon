using System;
using AddinX.Core.Contract.Control.Item;

namespace AddinX.Core.Contract.Control.Gallery
{
    public interface IGalleryItems
    {
        IGalleryExtra DynamicItems();

        IGalleryExtra AddItems(Action<IItems> items);
    }
}