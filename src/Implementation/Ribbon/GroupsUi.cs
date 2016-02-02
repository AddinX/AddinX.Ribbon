using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AddinX.Core.Contract.Ribbon.Group;
using AddinX.Core.Implementation.Control;

namespace AddinX.Core.Implementation.Ribbon
{
    public class GroupsUi : AddInList, IGroupsUi
    {
        private readonly IList<IGroupUi> groups;

        public GroupsUi()
        {
            groups = new List<IGroupUi>();
        }

        public IGroupIdUi AddGroup(string label)
        {
            var tab = new GroupUi().SetLabel(label);
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