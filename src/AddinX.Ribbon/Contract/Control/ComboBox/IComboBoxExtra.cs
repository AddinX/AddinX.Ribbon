namespace AddinX.Ribbon.Contract.Control.ComboBox
{
    public interface IComboBoxExtra
    {
        IComboBoxExtra MaxLength(int maxLength);

        IComboBoxExtra SizeString(int comboBoxSize);

        IComboBoxExtra Supertip(string supertip);

        IComboBoxExtra Keytip(string keytip);

        IComboBoxExtra Screentip(string screentip);
    }
}