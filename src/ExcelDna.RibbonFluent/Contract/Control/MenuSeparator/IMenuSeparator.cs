namespace AddinX.Ribbon.Contract.Control.MenuSeparator {
    public interface IMenuSeparator : IRibbonIdQ<IMenuSeparator>
    {
        IMenuSeparator SetTitle(string title);
    }
}