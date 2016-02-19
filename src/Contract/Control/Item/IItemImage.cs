namespace AddinX.Ribbon.Contract.Control.Item
{
    public interface IItemImage
    {
        IItemExtra ImageMso(string name);

        IItemExtra ImagePath(string name);

        IItemExtra NoImage();
    }
}