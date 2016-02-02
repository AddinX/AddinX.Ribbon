namespace AddinX.Core.Contract.Control.ButtonGroup
{
    public interface IButtonGroupIdUi
    {
        IButtonGroupItems SetId(string name);

        IButtonGroupItems SetIdQ(string ns, string name);
    }
}