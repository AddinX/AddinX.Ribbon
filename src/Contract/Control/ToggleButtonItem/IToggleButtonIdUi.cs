namespace AddinX.Core.Contract.Control.ToggleButtonItem
{
    public interface IToggleButtonItemIdUi
    {
        IToggleButtonItemLabel SetId(string name);

        IToggleButtonItemLabel SetIdMso(string name);

        IToggleButtonItemLabel SetIdQ(string ns, string name);
    }
}