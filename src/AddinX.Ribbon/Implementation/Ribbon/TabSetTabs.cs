using AddinX.Ribbon.Contract.Ribbon.Tab;
using AddinX.Ribbon.Implementation.Control;

namespace AddinX.Ribbon.Implementation.Ribbon {
    public class TabSetTabs : AddInList<Tab>, ITabs {
        public TabSetTabs() {
        }

        public ITab AddTab(string label) {
            var tab = new Tab();
            tab.SetLabel(label);
            InnerList.Add(tab);
            return tab;
        }
    }
}