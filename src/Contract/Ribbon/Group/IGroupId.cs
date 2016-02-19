namespace AddinX.Ribbon.Contract.Ribbon.Group
{
    public interface IGroupId
    {
        IGroupItems SetId(string name);

        IGroupItems SetIdMso(string name);

        IGroupItems SetIdQ(string ns, string name);
    }
}