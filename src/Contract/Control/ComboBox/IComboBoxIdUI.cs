namespace AddinX.Core.Contract.Control.ComboBox
{
    public interface IComboBoxIdUi
    {
        IComboBoxLabel SetId(string name);

        IComboBoxLabel SetIdMso(string name);

        IComboBoxLabel SetIdQ(string ns, string name);
    }
}