namespace AddinX.Ribbon.Contract.Control.EditBox
{
    public interface IEditBoxId
    {
        IEditBoxImage SetId(string name);

        IEditBoxImage SetIdMso(string name);

        IEditBoxImage SetIdQ(string ns, string name);
    }
}