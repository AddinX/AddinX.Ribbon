using System;
using System.Collections.Generic;

namespace AddinX.Core.Contract.Command
{
    public interface IDropDownCommand : ICommand
    {
        IDropDownCommand IsVisible(Func<bool> condition);

        IDropDownCommand IsEnabled(Func<bool> condition);

        IDropDownCommand Action(Action<int> act);
        
        IDropDownCommand ItemSelectionIndex(Func<int> selectedItemIndex);
        
        IDropDownCommand ItemCounts(Func<int> numberItems);

        IDropDownCommand ItemsId(Func<IList<object>> itemsId);

        IDropDownCommand ItemsLabel(Func<IList<string>> itemsLabel);

        IDropDownCommand ItemsScreentip(Func<IList<string>> itemsScreentip);

        IDropDownCommand ItemsSupertip(Func<IList<string>> itemsSupertip);

        IDropDownCommand ItemsImage(Func<IList<object>> itemsImage);
    }
}