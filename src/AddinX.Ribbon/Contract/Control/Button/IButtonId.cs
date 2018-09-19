namespace AddinX.Ribbon.Contract.Control.Button
{
    public interface IButtonId
    {
        IButton SetId(string name);

        IButton SetIdMso(string name);

        IButton SetIdQ(string ns, string name);
    }
}