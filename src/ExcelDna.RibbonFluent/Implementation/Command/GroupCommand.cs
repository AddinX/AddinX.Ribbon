using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Implementation.Command {
    public class GroupCommand : ControlCommand<IGroupCommand>, IGroupCommand, IVisibleField {

        protected override IGroupCommand Interface => this;

    }
}