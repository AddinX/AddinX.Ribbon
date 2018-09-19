using System;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Implementation.Command {
    public class GroupCommand : IGroupCommand, IVisibleField {
        public Func<bool> IsVisibleField { get; private set; }

        public GroupCommand() {
            IsVisibleField = () => true;
        }

        public void IsVisible(Func<bool> condition) {
            IsVisibleField = condition;
        }
    }
}