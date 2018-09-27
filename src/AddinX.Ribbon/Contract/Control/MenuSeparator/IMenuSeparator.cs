namespace AddinX.Ribbon.Contract.Control.MenuSeparator
{
    public interface IMenuSeparator : IRibbonIdQ<IMenuSeparator>
        //IMenuSeparatorId 
    {
        IMenuSeparator SetTitle(string title);

    }
}