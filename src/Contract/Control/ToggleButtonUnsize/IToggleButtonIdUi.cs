namespace AddinX.Core.Contract.Control.ToggleButtonUnsize
{
    public interface IToggleButtonUnsizeIdUi
    {
        IToggleButtonUnsizeLabel SetId(string name);

        IToggleButtonUnsizeLabel SetIdMso(string name);

        IToggleButtonUnsizeLabel SetIdQ(string ns, string name);
    }
}