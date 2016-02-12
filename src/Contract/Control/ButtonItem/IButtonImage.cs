namespace AddinX.Core.Contract.Control.ButtonItem
{
    public interface IButtonItemImage
    {
        IButtonItemLabel ImageMso(string name);

        IButtonItemLabel ImagePath(string name);

        IButtonItemLabel NoImage();
    }
}