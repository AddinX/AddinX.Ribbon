namespace AddinX.Ribbon.Contract.Control.EditBox
{
    public interface IEditBoxImage
    {
        IEditBoxExtra ImageMso(string name);

        IEditBoxExtra ImagePath(string name);

        IEditBoxExtra NoImage();
    }
}