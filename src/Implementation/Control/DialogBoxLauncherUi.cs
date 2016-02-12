using System.Xml.Linq;
using AddinX.Core.Contract.Control.DialogBoxLauncher;

namespace AddinX.Core.Implementation.Control
{
    public class DialogBoxLauncherUi : ControlUi, IDialogBoxLauncherUi
    {
        private readonly ButtonItemUi btn;

        public DialogBoxLauncherUi()
        {
            ElementName = "dialogBoxLauncher";
            btn = new ButtonItemUi();
            btn.HideLabel();
            btn.NoImage();
        }

        protected internal override XElement ToXml(XNamespace ns)
        {
            var element = new XElement(ns + ElementName,
                btn.ToXml(ns)
                );
            return element;
        }

        public IDialogBoxLauncherExtra Description(string description)
        {
            btn.Description(description);
            return this;
        }

        public IDialogBoxLauncherExtra Supertip(string supertip)
        {
            btn.Supertip(supertip);
            return this;
        }

        public IDialogBoxLauncherExtra Keytip(string keytip)
        {
            btn.Keytip(keytip);
            return this;
        }

        public IDialogBoxLauncherExtra Screentip(string screentip)
        {
            btn.Screentip(screentip);
            return this;
        }

        public IDialogBoxLauncherExtra SetId(string name)
        {
            btn.SetId(name);
            return this;
        }

        public IDialogBoxLauncherExtra SetIdQ(string ns, string name)
        {
            btn.SetIdQ(ns, name);
            return this;
        }
    }
}