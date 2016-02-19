namespace AddinX.Ribbon.Contract.Control.EditBox
{
    public interface IEditBoxExtra
    {
        IEditBoxExtra MaxLength(int maxLength);

        IEditBoxExtra SizeString(int editBoxSize);

        IEditBoxExtra Supertip(string supertip);

        IEditBoxExtra Keytip(string keytip);

        IEditBoxExtra Screentip(string screentip);
    }
}