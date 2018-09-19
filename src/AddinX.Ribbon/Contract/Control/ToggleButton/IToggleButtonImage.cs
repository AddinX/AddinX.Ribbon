namespace AddinX.Ribbon.Contract.Control.ToggleButton
{
    public interface IToggleButtonImage
    {
        IToggleButtonExtra ImageMso(string name);

        IToggleButtonExtra ImagePath(string name);

        IToggleButtonExtra NoImage();
    }
}