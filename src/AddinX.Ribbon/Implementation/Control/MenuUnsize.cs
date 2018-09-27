using System;
using AddinX.Ribbon.Contract.Control.MenuUnsize;

namespace AddinX.Ribbon.Implementation.Control {
    public class MenuUnsize : ControlContainer<IMenuUnsize>, IMenuUnsize {

        public MenuUnsize(): base( "menu") {
            NoImage();
        }


        protected override IMenuUnsize Interface => this;
        

        public IMenuUnsize AddItems(Action<IMenuUnsizeControls> items) {
            items.Invoke(Controls);
            return this;
        }
    }
}