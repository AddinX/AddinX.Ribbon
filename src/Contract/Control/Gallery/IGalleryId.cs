namespace AddinX.Core.Contract.Control.Gallery
{
    public interface IGalleryId
    {
        IGalleryLabel SetId(string name);

        IGalleryLabel SetIdMso(string name);

        IGalleryLabel SetIdQ(string ns, string name);
    }
}