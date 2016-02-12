namespace AddinX.Core.Contract.Control.Menu
{
    public interface IMenuSize
    {
        IMenuItemSize NormalSize();

        IMenuItemSize LargeSize();
    }
}