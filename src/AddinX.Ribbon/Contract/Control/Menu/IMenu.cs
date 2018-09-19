namespace AddinX.Ribbon.Contract.Control.Menu
{
    public interface IMenu : IRibbonIdQ<IMenu>,IRibbonExtra<IMenu>,IRibbonImage<IMenu>,IRibbonSize<IMenu>,
            IRibbonItemSize<IMenu>,IRibbonLabel<IMenu>,IRibbonItems<IMenu, IMenuControls>
        //IMenuExtra, IMenuId,
        //IMenuImage, IMenuSize, IMenuItemSize,
        //IMenuLabel, IMenuItems
    {

    }
}