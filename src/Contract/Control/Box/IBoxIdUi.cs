namespace AddinX.Core.Contract.Control.Box
{
    public interface IBoxIdUi
    {
        IBoxStyle SetId(string name);

        IBoxStyle SetIdQ(string ns, string name);
    }
}