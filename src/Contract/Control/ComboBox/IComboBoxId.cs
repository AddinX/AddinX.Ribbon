namespace AddinX.Core.Contract.Control.ComboBox
{
    public interface IComboBoxId
    {
        IComboBoxLabel SetId(string name);

        IComboBoxLabel SetIdMso(string name);

        IComboBoxLabel SetIdQ(string ns, string name);
    }
}