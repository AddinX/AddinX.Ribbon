namespace AddinX.Core.Contract.Control.Button
{
    public interface IButtonExtra
    {   
        IButtonExtra Description(string description);

        IButtonExtra Supertip(string supertip);

        IButtonExtra Keytip(string keytip);

        IButtonExtra Screentip(string screentip);
    }
}