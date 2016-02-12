namespace AddinX.Core.Contract.Control.Gallery
{
    public interface IGalleryExtra
    {
        IGalleryExtra SizeString(int size);

        IGalleryExtra ItemHeight(int height);

        IGalleryExtra ItemWidth(int width);

        IGalleryExtra NumberRows(int rows);

        IGalleryExtra NumberColumns(int cols);

        IGalleryExtra Supertip(string supertip);

        IGalleryExtra Keytip(string keytip);

        IGalleryExtra Screentip(string screentip);
    }
}