namespace AddinX.Core.Contract.Control.DropDown
{
    public interface IDropDownId
    {
        IDropDownLabel SetId(string name);

        IDropDownLabel SetIdMso(string name);

        IDropDownLabel SetIdQ(string ns, string name);
    }
}