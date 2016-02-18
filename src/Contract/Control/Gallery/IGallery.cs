namespace AddinX.Core.Contract.Control.Gallery
{
    public interface IGallery : IGalleryExtra, IGalleryId,
        IGalleryImage, IGalleryItemImage, IGalleryItemLabel,
        IGalleryLabel, IGalleryItems, IGallerySize
    {

    }
}