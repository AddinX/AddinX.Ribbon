using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Ribbon.Group;
using AddinX.Ribbon.Implementation.Control;

namespace AddinX.Ribbon.Implementation.Ribbon {
    public class Groups : AddInList, IGroups {
        private readonly IList<IGroup> _groups;
        private readonly ICallbackRigister _register;

        public Groups(ICallbackRigister register) {
            _register = register;
            _groups = new List<IGroup>();
        }

        public IGroup AddGroup(string label) {
            var tab = new Group(_register);
            tab.SetLabel(label);
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