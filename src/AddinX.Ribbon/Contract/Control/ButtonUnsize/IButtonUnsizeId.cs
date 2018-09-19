namespace AddinX.Ribbon.Contract.Control.ButtonUnsize
{
    public interface IButtonUnsizeId
    {
        IButtonUnsizeImage SetId(string name);

        IButtonUnsizeImage SetIdMso(string name);

        IButtonUnsizeImage SetIdQ(string ns, string name);
    }
}