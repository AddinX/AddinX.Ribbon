using System;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Control.Label;
using AddinX.Ribbon.Implementation.Command;

namespace AddinX.Ribbon.Implementation.Control {
    public class LabelControl : Control<ILabelControl, ILabelCommand>, ILabelControl {
        public LabelControl() : base("labelControl") {
        }


        protected override ILabelControl Interface => this;


        #region Implementation of IRibbonCallback<out ILabelControl,out ILabelCommand>

        public void Callback(Action<ILabelCommand> builder) {
            builder(GetCommand<LabelCommand>());
        }

        #endregion
    }
}