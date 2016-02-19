using System.Xml.Linq;
using AddinX.Ribbon.Contract.Control.DialogBoxLauncher;

namespace AddinX.Ribbon.Implementation.Control
{
    public class DialogBoxLauncher : Control, IDialogBoxLauncher
    {
        private readonly ButtonUnsize btn;

        public DialogBoxLauncher()
        {
            ElementName = "dialogBoxLauncher";
            btn = new ButtonUnsize();
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