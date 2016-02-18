namespace AddinX.Core.Contract.Control.ToggleButtonUnsize
{
    public interface IToggleButtonUnsizeImage
    {
        IToggleButtonUnsizeExtra ImageMso(string name);

        IToggleButtonUnsizeExtra ImagePath(string name);

        IToggleButtonUnsizeExtra NoImage();
    }
}