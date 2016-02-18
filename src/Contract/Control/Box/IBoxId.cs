namespace AddinX.Core.Contract.Control.Box
{
    public interface IBoxId
    {
        IBoxStyle SetId(string name);

        IBoxStyle SetIdQ(string ns, string name);
    }
}