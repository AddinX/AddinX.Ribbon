namespace AddinX.Core.Contract.Control.ComboBox
{
    public interface IComboBoxImage
    {
        IComboxBoxItems ImageMso(string name);

        IComboxBoxItems ImagePath(string name);

        IComboxBoxItems NoImage();
    }
}