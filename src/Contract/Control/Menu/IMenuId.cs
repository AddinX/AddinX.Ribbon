namespace AddinX.Core.Contract.Control.Menu
{
    public interface IMenuId
    {
        IMenuLabel SetId(string name);

        IMenuLabel SetIdMso(string name);

        IMenuLabel SetIdQ(string ns, string name);
    }
}