namespace AddinX.Core.Contract.Control.ToggleButtonItem
{
    public interface IToggleButtonItemExtra
    {
        IToggleButtonItemExtra Description(string description);

        IToggleButtonItemExtra Supertip(string supertip);

        IToggleButtonItemExtra Keytip(string keytip);

        IToggleButtonItemExtra Screentip(string screentip);
    }
}