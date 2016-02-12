namespace AddinX.Core.Contract.Control.EditBox
{
    public interface IEditBoxIdUi
    {
        IEditBoxImage SetId(string name);

        IEditBoxImage SetIdMso(string name);

        IEditBoxImage SetIdQ(string ns, string name);
    }
}