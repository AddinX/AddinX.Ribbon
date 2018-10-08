using AddinX.Ribbon.Contract.Command;

namespace AddinX.Ribbon.Implementation.Command {
    public class LabelCommand : ControlCommand<ILabelCommand>, ILabelCommand {
        #region Implementation of ICommand

        protected override ILabelCommand Interface => this;

        #endregion
    }
}