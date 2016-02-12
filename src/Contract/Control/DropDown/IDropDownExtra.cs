namespace AddinX.Core.Contract.Control.DropDown
{
    public interface IDropDownExtra
    {
        IDropDownExtra SizeString(int size);

        IDropDownExtra Supertip(string supertip);

        IDropDownExtra Keytip(string keytip);

        IDropDownExtra Screentip(string screentip);
    }
}