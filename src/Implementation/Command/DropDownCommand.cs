using System;
using System.Collections.Generic;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Implementation.Command
{
    public class DropDownCommand : IDropDownCommand, IEnabledField, IVisibleField, IDynamicItemsField, IDropDownField
    {
        public Action<int> OnActionField { get; private set; }
        public Func<bool> IsEnabledField { get; private set; }
        public Func<bool> IsVisibleField { get; private set; }
        public Func<int> ItemCount { get; private set; }
        public Func<IList<object>> ItemId { get; private set; }
        public Func<IList<object>> ItemImage { get; private set; }
        public Func<IList<string>> ItemLabel { get; private set; }
        public Func<IList<string>> ItemScreentip { get; private set; }
        public Func<IList<string>> ItemSupertip { get; private set; }
        public Func<int> SelectedItemIndex { get; private set; }

        public DropDownCommand()
        {
            IsVisibleField = () => true;
            IsEnabledField = () => true;
            ItemCount = () => 0;
            ItemScreentip = () => null;
            ItemSupertip = () => null;
            ItemLabel = () => null;
            ItemImage = () => null;
            ItemId = () => null;
        }
        public IDropDownCommand IsVisible(Func<bool> condition)
        {
            IsVisibleField = condition;
            return this;
        }

        public IDropDownCommand IsEnabled(Func<bool> condition)
        {
            IsEnabledField = condition;
            return this;
        }

        public IDropDownCommand Action(Action<int> act)
        {
            OnActionField = act;
            return this;
        }

        public IDropDownCommand ItemSelectionIndex(Func<int> selectedItemIndex)
        {
            SelectedItemIndex = selectedItemIndex;
            return this;
        }
      
        public IDropDownCommand ItemCounts(Func<int> numberItems)
        {
            ItemCount = numberItems;
            return this;
        }

        public IDropDownCommand ItemsId(Func<IList<object>> itemsId)
        {
            ItemId = itemsId;
            return this;
        }

        public IDropDownCommand ItemsLabel(Func<IList<string>> itemsLabel)
        {
            ItemLabel = itemsLabel;
            return this;
        }
        
        public IDropDownCommand ItemsScreentip(Func<IList<string>> itemsScreentip)
        {
            ItemScreentip = itemsScreentip;
            return this;
        }

        public IDropDownCommand ItemsSupertip(Func<IList<string>> itemsSupertip)
        {
            ItemSupertip = itemsSupertip;
            return this;
        }

        public IDropDownCommand ItemsImage(Func<IList<object>> itemsImage)
        {
            ItemImage = itemsImage;
            return this;
        }


    }
}