namespace AddinX.Core.Contract.Control.ButtonItem
{
    public interface IButtonItemIdUi
    {
        IButtonItemImage SetId(string name);

        IButtonItemImage SetIdMso(string name);

        IButtonItemImage SetIdQ(string ns, string name);
    }
}