using System;

namespace AddinX.Ribbon.Contract.Command {
    public interface IDropDownCommand : ICommand {
        IDropDownCommand GetVisible(Func<bool> condition);

        IDropDownCommand GetEnabled(Func<bool> condition);

        IDropDownCommand OnAction(Action<int> act);

        IDropDownCommand ItemSelectionIndex(Func<int> selectedItemIndex);

        IDropDownCommand ItemCounts(Func<int> numberItems);

        IDropDownCommand ItemsId(Func<int, string> itemsId);

        IDropDownCommand ItemsLabel(Func<int, string> itemsLabel);

        IDropDownCommand ItemsScreentip(Func<int, string> itemsScreentip);

        IDropDownCommand ItemsSupertip(Func<int, string> itemsSupertip);

        IDropDownCommand ItemsImage(Func<int, object> itemsImage);
    }

    public interface IDynamicItemsCommand<out T> : IControlCommand<T> where T : ICommand {
        
        T ItemCount(Func<int> numberItems);
        
        T ItemsId(Func<int, string> itemsId);
        
        T ItemsLabel(Func<int, string> itemLabelFunc);
        
        T ItemsScreentip(Func<int, string> itemsScreentip);
        
        T ItemsSupertip(Func<int, string> itemsSupertip);
        
        T ItemsImage(Func<int, object> itemImageFunc);
    }
}