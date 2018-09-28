using System;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Control.CheckBox;
using AddinX.Ribbon.Implementation.Command;

namespace AddinX.Ribbon.Implementation.Control {
    public class Checkbox : Control<ICheckbox, ICheckBoxCommand>, ICheckbox {
        public Checkbox() : base("checkBox") {
        }

        protected override ICheckbox Interface => this;

        #region Implementation of IRibbonCallback<out ICheckBoxCommand>

        public void Callback(Action<ICheckBoxCommand> builder) {
            builder(GetCommand<CheckBoxCommand>());
        }

        #endregion
    }
}