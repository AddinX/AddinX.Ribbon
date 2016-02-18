namespace AddinX.Core.Contract.Control.Button
{
    public interface IButtonId
    {
        IButtonSize SetId(string name);

        IButtonSize SetIdMso(string name);

        IButtonSize SetIdQ(string ns, string name);
    }
}