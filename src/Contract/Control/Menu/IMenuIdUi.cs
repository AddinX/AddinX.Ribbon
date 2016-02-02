namespace AddinX.Core.Contract.Control.Menu
{
    public interface IMenuIdUi
    {
        IMenuLabel SetId(string name);

        IMenuLabel SetIdMso(string name);

        IMenuLabel SetIdQ(string ns, string name);
    }
}