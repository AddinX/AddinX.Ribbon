using System;
using AddinX.Ribbon.Contract.Ribbon.Group;
using AddinX.Ribbon.Contract.Ribbon.Tab;
using AddinX.Ribbon.Implementation.Control;

namespace AddinX.Ribbon.Implementation.Ribbon {
    public class Tab : ControlContainer<ITab, Groups>, ITab {
        public Tab() : base("tab") {
        }


        protected override ITab Interface => this;

        public ITab Groups(Action<IGroups> value) {
            value.Invoke(InnerItems);
            return this;
        }
    }
}