namespace AddinX.Core.Contract.Control.CheckBox
{
    public interface ICheckboxExtra
    {
        ICheckboxExtra Description(string description);

        ICheckboxExtra Supertip(string supertip);

        ICheckboxExtra Keytip(string keytip);

        ICheckboxExtra Screentip(string screentip);
    }
}