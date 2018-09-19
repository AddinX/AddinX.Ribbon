using System.Xml.Linq;
using AddinX.Ribbon.Contract.Control.DialogBoxLauncher;

namespace AddinX.Ribbon.Implementation.Control {
    public class DialogBoxLauncher : Control, IDialogBoxLauncher {
        private readonly ButtonUnsize _btn;

        public DialogBoxLauncher() {
            ElementName = "dialogBoxLauncher";
            _btn = new ButtonUnsize();
            _btn.HideLabel();
            _btn.NoImage();
        }

        protected internal override XElement ToXml(XNamespace ns) {
            var element = new XElement(ns + ElementName,
                _btn.ToXml(ns)
            );
            return element;
        }

        public IDialogBoxLauncherExtra Description(string description) {
            _btn.Description(description);
            return this;
        }

        public IDialogBoxLauncherExtra Supertip(string supertip) {
            _btn.Supertip(supertip);
            return this;
        }

        public IDialogBoxLauncherExtra Keytip(string keytip) {
            _btn.Keytip(keytip);
            return this;
        }

        public IDialogBoxLauncherExtra Screentip(string screentip) {
            _btn.Screentip(screentip);
            return this;
        }

        public IDialogBoxLauncherExtra SetId(string name) {
            _btn.SetId(name);
            return this;
        }

        public IDialogBoxLauncherExtra SetIdQ(string ns, string name) {
            _btn.SetIdQ(ns, name);
            return this;
        }
    }
}