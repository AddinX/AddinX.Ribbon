using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
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

        protected internal override IEnumerable<XElement> ToXml(XNamespace ns) {
            return InnerList.Select(tab => tab.ToXml(ns));
        }
    }
}