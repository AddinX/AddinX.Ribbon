using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Ribbon.Group;
using AddinX.Ribbon.Implementation.Control;

namespace AddinX.Ribbon.Implementation.Ribbon {
    public class Groups : AddInList, IGroups {
        private readonly IList<IGroup> _groups;

        public Groups() {
            _groups = new List<IGroup>();
        }

        public IGroupId AddGroup(string label) {
            var tab = new Group().SetLabel(label);
            _groups.Add(tab);
            return tab;
        }

        protected internal override XElement[] ToXml(XNamespace ns) {
            if (_groups == null || !_groups.Any()) {
                return null;
            }

            return _groups.Select(
                gp => ((AddInElement) gp).ToXml(ns)).ToArray();
        }
    }
}