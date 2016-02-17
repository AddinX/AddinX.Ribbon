namespace AddinX.Core.Contract.Control.MenuUnsize
{
    public interface IMenuUnsizeExtra
    {
        IMenuUnsizeExtra Description(string description);

        IMenuUnsizeExtra Supertip(string supertip);

        IMenuUnsizeExtra Keytip(string keytip);

        IMenuUnsizeExtra Screentip(string screentip);
    }
}