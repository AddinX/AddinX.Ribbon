namespace AddinX.Core.Contract.Control.Menu
{
    public interface IMenuExtra
    {
        IMenuExtra Description(string description);
        
        IMenuExtra Supertip(string supertip);

        IMenuExtra Keytip(string keytip);

        IMenuExtra Screentip(string screentip);
    }
}