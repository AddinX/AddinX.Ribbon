namespace AddinX.Ribbon.Contract.Control.MenuUnsize
{
    public interface IMenuUnsizeId
    {
        IMenuUnsizeLabel SetId(string name);

        IMenuUnsizeLabel SetIdMso(string name);

        IMenuUnsizeLabel SetIdQ(string ns, string name);
    }
}