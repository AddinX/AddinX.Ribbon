namespace AddinX.Ribbon.Contract.Control.ToggleButton
{
    public interface IToggleButtonExtra
    {
        IToggleButtonExtra Description(string description);

        IToggleButtonExtra Supertip(string supertip);

        IToggleButtonExtra Keytip(string keytip);

        IToggleButtonExtra Screentip(string screentip);
    }
}