using System;

namespace AddinX.Ribbon.Contract.Command {
    public interface IGalleryCommand : IDynamicItemsCommand<IGalleryCommand> {

        IGalleryCommand OnItemAction(Action<int> act);

        IGalleryCommand ItemSelectionIndex(Func<int> selectedItemIndex);
    }
}