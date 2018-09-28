using System;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Control.Separator;
using AddinX.Ribbon.Implementation.Command;

namespace AddinX.Ribbon.Implementation.Control {
    public class Separator : Control<ISeparator, ISeparatorCommand>, ISeparator {
        public Separator() : base("separator") {
        }

        protected override ISeparator Interface => this;

        #region Implementation of IRibbonCallback<ISeparatorCommand>

        public void Callback(Action<ISeparatorCommand> builder) {
            builder?.Invoke(GetCommand<SeparatorCommand>());
        }

        #endregion
    }
}