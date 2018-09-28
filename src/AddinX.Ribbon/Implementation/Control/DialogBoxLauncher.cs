using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Control.DialogBoxLauncher;
using AddinX.Ribbon.Implementation.Command;

namespace AddinX.Ribbon.Implementation.Control {
    public class DialogBoxLauncher : Control<IDialogBoxLauncher, IDialogBoxLauncherCommand>, IDialogBoxLauncher {
        private readonly ButtonUnsize _btn;

        public DialogBoxLauncher() : base("dialogBoxLauncher") {
            _btn = new ButtonUnsize();
            _btn.HideLabel();
            _btn.NoImage();
        }

        protected internal override void SetRegister(ICallbackRigister register) {
            base.SetRegister(register);
            _btn.SetRegister(register);
        }

        protected internal override XElement ToXml(XNamespace ns) {
            var element = new XElement(ns + ElementName,
                _btn.ToXml(ns)
            );
            return element;
        }

        protected override IDialogBoxLauncher Interface => this;


        #region Implementation of IRibbonCallback<out IDialogBoxLauncher,out IDialogBoxLauncherCommand>

        public void Callback(Action<IDialogBoxLauncherCommand> builder) {
            builder(GetCommand<DialogBoxLauncherCommand>());
        }

        #endregion
    }
}