namespace AddinX.Core.Contract.Control.Button
{
    public interface IButtonIdUi
    {
        IButtonSize SetId(string name);

        IButtonSize SetIdMso(string name);

        IButtonSize SetIdQ(string ns, string name);
    }
}