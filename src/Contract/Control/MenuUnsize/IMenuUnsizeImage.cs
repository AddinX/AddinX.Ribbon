namespace AddinX.Core.Contract.Control.MenuUnsize
{
    public interface IMenuUnsizeImage
    {
        IMenuUnsizeItemSize ImageMso(string name);

        IMenuUnsizeItemSize ImagePath(string name);

        IMenuUnsizeItemSize NoImage();
    }
}