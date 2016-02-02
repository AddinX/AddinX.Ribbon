namespace AddinX.Core.Contract.Control.Gallery
{
    public interface IGalleryImage
    {
        IGalleryItemLabel ImageMso(string name);

        IGalleryItemLabel ImagePath(string name);

        IGalleryItemLabel NoImage();
    }
}