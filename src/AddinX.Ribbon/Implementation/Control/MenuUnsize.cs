using System;
using AddinX.Ribbon.Contract.Control.MenuUnsize;
using AddinX.Ribbon.Implementation.Ribbon;

namespace AddinX.Ribbon.Implementation.Control {
    public class MenuUnsize : ControlContainer<IMenuUnsize, Controls>, IMenuUnsize {
        public MenuUnsize() : base("menu") {
            NoImage();
        }


        protected override IMenuUnsize Interface => this;


        public IMenuUnsize Items(Action<IMenuUnsizeControls> builder) {
            builder?.Invoke(base.InnerItems);
            return this;
        }
    }
}