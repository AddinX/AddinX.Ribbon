namespace AddinX.Core.Contract.Control.GalleryUnsize
{
    public interface IGalleryUnsizeId
    {
        IGalleryUnsizeLabel SetId(string name);

        IGalleryUnsizeLabel SetIdMso(string name);

        IGalleryUnsizeLabel SetIdQ(string ns, string name);
    }
}