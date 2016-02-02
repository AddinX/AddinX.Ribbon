using System;

namespace AddinX.Core.Contract.Control.Gallery
{
    public interface IGalleryButtons
    {
        IGalleryExtra AddButtons(Action<IGalleryControlsUi> items);
    }
}