namespace AddinX.Core.Contract.Control.Label
{
    public interface ILabelControlIdUi
    {
        ILabelControlExtra SetId(string name);

        ILabelControlExtra SetIdMso(string name);

        ILabelControlExtra SetIdQ(string ns, string name);
    }
}