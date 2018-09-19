namespace AddinX.Ribbon.Contract.Control.Item
{
    public interface IItemExtra
    {
        IItemExtra Supertip(string supertip);

        IItemExtra Screentip(string screentip);
    }
}