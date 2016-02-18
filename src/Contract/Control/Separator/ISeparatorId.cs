namespace AddinX.Core.Contract.Control.Separator
{
    public interface ISeparatorId
    {
        void SetId(string name);

        void SetIdQ(string ns, string name);
    }
}