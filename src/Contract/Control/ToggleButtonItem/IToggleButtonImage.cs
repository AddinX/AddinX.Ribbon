namespace AddinX.Core.Contract.Control.ToggleButtonItem
{
    public interface IToggleButtonItemImage
    {
        IToggleButtonItemExtra ImageMso(string name);

        IToggleButtonItemExtra ImagePath(string name);

        IToggleButtonItemExtra NoImage();
    }
}