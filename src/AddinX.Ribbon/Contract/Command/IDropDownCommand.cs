using System;
using System.Collections.Generic;

namespace AddinX.Ribbon.Contract.Command
{
    public interface IDropDownCommand : ICommand
    {
        IDropDownCommand IsVisible(Func<bool> condition);

        IDropDownCommand IsEnabled(Func<bool> condition);

        IDropDownCommand Action(Action<int> act);
        
        IDropDownCommand ItemSelectionIndex(Func<int> selectedItemIndex);
        
        IDropDownCommand ItemCounts(Func<int> numberItems);

        IDropDownCommand ItemsId(Func<int, string> itemsId);

        IDropDownCommand ItemsLabel(Func<int, string> itemsLabel);

        IDropDownCommand ItemsScreentip(Func<int,string> itemsScreentip);

        IDropDownCommand ItemsSupertip(Func<int,string> itemsSupertip);

        IDropDownCommand ItemsImage(Func <int ,object> itemsImage);
    }
}