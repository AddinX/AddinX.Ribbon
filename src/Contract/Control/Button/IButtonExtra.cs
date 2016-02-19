namespace AddinX.Ribbon.Contract.Control.Button
{
    public interface IButtonExtra
    {   
        IButtonExtra Description(string description);

        IButtonExtra Supertip(string supertip);

        IButtonExtra Keytip(string keytip);

        IButtonExtra Screentip(string screentip);
    }
}