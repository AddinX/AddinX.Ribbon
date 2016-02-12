using System;
using System.Collections.Generic;

namespace AddinX.Core.Contract.Command
{
    public interface IGalleryCommand : ICommand
    {
        IGalleryCommand IsVisible(Func<bool> condition);

        IGalleryCommand IsEnabled(Func<bool> condition);

        IGalleryCommand Action(Action<int> act);
        
        IGalleryCommand ItemSelectionIndex(Func<int> selectedItemIndex);
        
        IGalleryCommand ItemCounts(Func<int> numberItems);

        IGalleryCommand ItemsId(Func<IList<object>> itemsId);

        IGalleryCommand ItemsLabel(Func<IList<string>> itemsLabel);

        IGalleryCommand ItemsScreentip(Func<IList<string>> itemsScreentip);

        IGalleryCommand ItemsSupertip(Func<IList<string>> itemsSupertip);

        IGalleryCommand ItemsImage(Func<IList<object>> itemsImage);
    }
}