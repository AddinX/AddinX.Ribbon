namespace AddinX.Ribbon.Contract.Control.Button
{
    public interface IButtonImage
    {
        IButtonLabel ImageMso(string name);

        IButtonLabel ImagePath(string name);

        IButtonLabel NoImage();
    }
}