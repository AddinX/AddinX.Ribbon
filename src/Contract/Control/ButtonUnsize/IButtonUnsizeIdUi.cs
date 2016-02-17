namespace AddinX.Core.Contract.Control.ButtonUnsize
{
    public interface IButtonUnsizeIdUi
    {
        IButtonUnsizeImage SetId(string name);

        IButtonUnsizeImage SetIdMso(string name);

        IButtonUnsizeImage SetIdQ(string ns, string name);
    }
}