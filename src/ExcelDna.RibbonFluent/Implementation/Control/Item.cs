using AddinX.Ribbon.Contract.Control.Item;

namespace AddinX.Ribbon.Implementation.Control {
    public class Item : Control<IItem>, IItem {
        public Item() : base("item") {
            //NoImage();
        }

        protected override IItem Interface => this;
    }
}