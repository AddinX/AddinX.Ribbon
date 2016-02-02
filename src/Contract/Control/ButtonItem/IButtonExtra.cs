namespace AddinX.Core.Contract.Control.ButtonItem
{
    public interface IButtonItemExtra
    {   
        IButtonItemExtra Description(string description);

        IButtonItemExtra Supertip(string supertip);

        IButtonItemExtra Keytip(string keytip);

        IButtonItemExtra Screentip(string screentip);
    }
}