namespace AddinX.Ribbon.Contract.Control.ButtonUnsize
{
    public interface IButtonUnsizeExtra
    {   
        IButtonUnsizeExtra Description(string description);

        IButtonUnsizeExtra Supertip(string supertip);

        IButtonUnsizeExtra Keytip(string keytip);

        IButtonUnsizeExtra Screentip(string screentip);
    }
}