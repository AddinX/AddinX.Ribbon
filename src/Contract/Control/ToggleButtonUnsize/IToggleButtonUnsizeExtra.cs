namespace AddinX.Core.Contract.Control.ToggleButtonUnsize
{
    public interface IToggleButtonUnsizeExtra
    {
        IToggleButtonUnsizeExtra Description(string description);

        IToggleButtonUnsizeExtra Supertip(string supertip);

        IToggleButtonUnsizeExtra Keytip(string keytip);

        IToggleButtonUnsizeExtra Screentip(string screentip);
    }
}