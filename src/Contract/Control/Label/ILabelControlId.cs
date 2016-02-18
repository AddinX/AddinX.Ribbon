namespace AddinX.Core.Contract.Control.Label
{
    public interface ILabelControlId
    {
        ILabelControlExtra SetId(string name);

        ILabelControlExtra SetIdMso(string name);

        ILabelControlExtra SetIdQ(string ns, string name);
    }
}