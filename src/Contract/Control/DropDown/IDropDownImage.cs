namespace AddinX.Core.Contract.Control.DropDown
{
    public interface IDropDownImage
    {
        IDropDownItemLabel ImageMso(string name);

        IDropDownItemLabel ImagePath(string name);

        IDropDownItemLabel NoImage();
    }
}