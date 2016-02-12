namespace AddinX.Core.Contract.Control.ToggleButton
{
    public interface IToggleButtonIdUi
    {
        IToggleButtonLabel SetId(string name);

        IToggleButtonLabel SetIdMso(string name);

        IToggleButtonLabel SetIdQ(string ns, string name);
    }
}