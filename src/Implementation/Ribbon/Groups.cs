using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Ribbon.Group;
using AddinX.Ribbon.Implementation.Control;

namespace AddinX.Ribbon.Implementation.Ribbon
{
    public class Groups : AddInList, IGroups
    {
        private readonly IList<IGroup> groups;

        public Groups()
        {
            groups = new List<IGroup>();
        }

        public IGroupId AddGroup(string label)
        {
            var tab = new Group().SetLabel(label);
            groups.Add(tab);
            return tab;
        }

        protected internal override XElement[] ToXml(XNamespace ns)
        {
            if (groups == null || !groups.Any())
            {
                return null;
            }
            return groups.Select(
                gp => ((AddInElement) gp).ToXml(ns)).ToArray();
        }
    }
}