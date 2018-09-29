using System;

namespace AddinX.Ribbon.Contract.Command {
    public interface IDynamicItemsCommand<out T> : IControlCommand<T> where T : ICommand {
        
        T GetItemCount(Func<int> itemCount);
        
        T GetItemId(Func<int, string> itemsId);
        
        T GetItemLabel(Func<int, string> itemLabel);
        
        T GetItemScreentip(Func<int, string> itemsScreentip);
        
        T GetItemSupertip(Func<int, string> itemsSupertip);
        
        T GetItemImage(Func<int, object> itemImage);
    }
}