namespace AddinX.Ribbon.Contract.Control.Menu
{
    public interface IMenuImage
    {
        IMenuSize ImageMso(string name);

        IMenuSize ImagePath(string name);

        IMenuSize NoImage();
    }
}