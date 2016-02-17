namespace AddinX.Core.Contract.Control.GalleryUnsize
{
    public interface IGalleryUnsizeIdUi
    {
        IGalleryUnsizeLabel SetId(string name);

        IGalleryUnsizeLabel SetIdMso(string name);

        IGalleryUnsizeLabel SetIdQ(string ns, string name);
    }
}