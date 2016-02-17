using System;

namespace AddinX.Core.Contract.Control.GalleryUnsize
{
    public interface IGalleryUnsizeExtra
    {
        IGalleryUnsizeExtra AddButtons(Action<IGalleryUnsizeControlsUi> items);

        IGalleryUnsizeExtra SizeString(int size);

        IGalleryUnsizeExtra ItemHeight(int height);

        IGalleryUnsizeExtra ItemWidth(int width);

        IGalleryUnsizeExtra NumberRows(int rows);

        IGalleryUnsizeExtra NumberColumns(int cols);

        IGalleryUnsizeExtra Supertip(string supertip);

        IGalleryUnsizeExtra Keytip(string keytip);

        IGalleryUnsizeExtra Screentip(string screentip);
    }
}