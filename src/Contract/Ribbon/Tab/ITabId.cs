namespace AddinX.Core.Contract.Ribbon.Tab
{
    public interface ITabId
    {
        ITabItems SetId(string name);

        ITabItems SetIdMso(string name);

        ITabItems SetIdQ(string ns, string name);
    }
}