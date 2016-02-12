namespace AddinX.Core.Contract.Control.DropDown
{
    public interface IDropDownIdUi
    {
        IDropDownLabel SetId(string name);

        IDropDownLabel SetIdMso(string name);

        IDropDownLabel SetIdQ(string ns, string name);
    }
}