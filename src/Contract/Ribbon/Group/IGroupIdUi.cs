namespace AddinX.Core.Contract.Ribbon.Group
{
    public interface IGroupIdUi
    {
        IGroupItems SetId(string name);

        IGroupItems SetIdMso(string name);

        IGroupItems SetIdQ(string ns, string name);
    }
}