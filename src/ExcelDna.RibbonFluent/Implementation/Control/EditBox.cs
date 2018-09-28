using System;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Control.EditBox;
using AddinX.Ribbon.Implementation.Command;

namespace AddinX.Ribbon.Implementation.Control {
    public class EditBox : Control<IEditBox, IEditBoxCommand>, IEditBox {
        public EditBox() : base("editBox") {
            NoImage();
            MaxLength(15);
            SizeString(15);
        }

        protected override IEditBox Interface => this;

        #region Implementation of IRibbonCallback<out IEditBox,out IEditBoxCommand>

        public void Callback(Action<IEditBoxCommand> builder) {
            base.BuildCallback<EditBoxCommand>(builder);
        }

        #endregion
    }
}