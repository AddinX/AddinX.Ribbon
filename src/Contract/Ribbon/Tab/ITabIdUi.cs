namespace AddinX.Core.Contract.Ribbon.Tab
{
    public interface ITabIdUi
    {
        ITabItems SetId(string name);

        ITabItems SetIdMso(string name);

        ITabItems SetIdQ(string ns, string name);
    }
}