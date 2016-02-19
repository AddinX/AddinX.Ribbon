namespace AddinX.Ribbon.Contract.Control.ButtonUnsize
{
    public interface IButtonUnsizeImage
    {
        IButtonUnsizeLabel ImageMso(string name);

        IButtonUnsizeLabel ImagePath(string name);

        IButtonUnsizeLabel NoImage();
    }
}