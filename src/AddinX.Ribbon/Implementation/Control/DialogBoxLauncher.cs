using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Control.DialogBoxLauncher;
using AddinX.Ribbon.Implementation.Command;

namespace AddinX.Ribbon.Implementation.Control {
    public class DialogBoxLauncher : Control, IDialogBoxLauncher {
        private readonly ButtonUnsize _btn;

        public DialogBoxLauncher(): base( "dialogBoxLauncher") {
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

        public IDialogBoxLauncher Description(string description) {
            _btn.Description(description);
            return this;
        }

        public IDialogBoxLauncher Supertip(string supertip) {
            _btn.Supertip(supertip);
            return this;
        }

        public IDialogBoxLauncher Keytip(string keytip) {
            _btn.Keytip(keytip);
            return this;
        }

        public IDialogBoxLauncher Screentip(string screentip) {
            _btn.Screentip(screentip);
            return this;
        }

        public IDialogBoxLauncher SetId(string name) {
            _btn.SetId(name);
            return this;
        }

        public IDialogBoxLauncher SetIdQ(string ns, string name) {
            _btn.SetIdQ(ns, name);
            return this;
        }

        #region Implementation of IRibbonCallback<out IDialogBoxLauncher,out IDialogBoxLauncherCommand>

        public IDialogBoxLauncher Callback(Action<IDialogBoxLauncherCommand> builder) {
            builder(GetCommand<DialogBoxLauncherCommand>());
            return this;
        }

        #endregion
    }
}