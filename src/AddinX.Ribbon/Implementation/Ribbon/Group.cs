using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Control;
using AddinX.Ribbon.Contract.Ribbon.Group;
using AddinX.Ribbon.Implementation.Control;

namespace AddinX.Ribbon.Implementation.Ribbon {
    public class Group : AddInElement, IGroup {
        private IElementId _id;
        private readonly IGroupControls _controls;
        private IGroupDialogBox _boxLauncher;

        private string _label;
        private string _supertip;
        private string _screentip;
        private string _keytip;


        public Group() {
            ElementName = "group";
            _id = new ElementId();
            _controls = new Controls();
        }

        protected internal Group SetLabel(string value) {
            _label = value;
            return this;
        }

        public IGroupExtra Items(Action<IGroupControls> value) {
            value.Invoke(_controls);
            return this;
        }


        protected internal override XElement ToXml(XNamespace ns) {
            var tmpId = (ElementId) _id;

            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                , new XAttribute("label", _label)
                , new XAttribute("getVisible", "GetVisible")
            );

            element.AddControls((AddInList) _controls, ns);

            if (!string.IsNullOrEmpty(_screentip)) {
                element.Add(new XAttribute("screentip", _screentip));
            }

            if (!string.IsNullOrEmpty(_supertip)) {
                element.Add(new XAttribute("supertip", _supertip));
            }

            if (!string.IsNullOrEmpty(_keytip)) {
                element.Add(new XAttribute("keytip", _keytip));
            }

            if (_boxLauncher != null) {
                element.AddControls((AddInList) _boxLauncher, ns);
                //element.Add(((AddInList) _boxLauncher).ToXml(ns));
            }

            return element;
        }

        public IGroupItems SetId(string name) {
            _id = new ElementId().SetId(name);
            return this;
        }

        public IGroupItems SetIdMso(string name) {
            _id = new ElementId().SetMicrosoftId(name);
            return this;
        }

        public IGroupItems SetIdQ(string ns, string name) {
            _id = new ElementId().SetNamespaceId(ns, name);
            return this;
        }

        public IGroupExtra Supertip(string supertip) {
            this._supertip = supertip;
            return this;
        }

        public IGroupExtra Keytip(string keytip) {
            this._keytip = keytip;
            return this;
        }

        public IGroupExtra Screentip(string screentip) {
            this._screentip = screentip;
            return this;
        }

        public IGroupExtra DialogBoxLauncher(Action<IGroupDialogBox> dialogBox) {
            _boxLauncher = new Controls();
            dialogBox.Invoke(_boxLauncher);
            return this;
        }
    }
}