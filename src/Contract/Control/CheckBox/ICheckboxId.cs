namespace AddinX.Core.Contract.Control.CheckBox
{
    public interface ICheckboxId
    {
        ICheckboxExtra SetId(string name);

        ICheckboxExtra SetIdMso(string name);

        ICheckboxExtra SetIdQ(string ns, string name);
    }
}