using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Control.ToggleButton;
using AddinX.Ribbon.Contract.Enums;
using AddinX.Ribbon.Implementation.Command;

namespace AddinX.Ribbon.Implementation.Control {
    public class ToggleButton : Control<IToggleButton,IToggleButtonCommand>, IToggleButton {
        public ToggleButton(): base( "toggleButton") {
            NoImage();
            NormalSize();
            ShowLabel();
        }

        protected override IToggleButton Interface => this;

        #region Implementation of IRibbonCallback<IToggleButtonCommand>

        public void Callback(Action<IToggleButtonCommand> builder) {
            builder?.Invoke(GetCommand<ToggleButtonCommand>());
        }

        #endregion
    }
}