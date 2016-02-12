using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AddinX.Core.Contract.Control.Item;

namespace AddinX.Core.Implementation.Control
{
    public class ItemsUi : AddInList, IItemsUi
    {
        private readonly IList<IItemUi> items;

        public ItemsUi()
        {
            items = new List<IItemUi>();
        }

        public IItemUi AddItem(string label)
        {
            var item = new ItemUi().SetLabel(label) as IItemUi;
            items.Add(item);
            return item;
        }

        protected internal override XElement[] ToXml(XNamespace ns)
        {
            return items == null || !items.Any()
                ? null
                : items.Select(o => ((ControlUi)o).ToXml(ns)).ToArray();
        }
    }
}