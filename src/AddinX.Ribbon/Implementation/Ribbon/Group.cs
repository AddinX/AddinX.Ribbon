using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Control;
using AddinX.Ribbon.Contract.Ribbon.Group;
using AddinX.Ribbon.Implementation.Command;
using AddinX.Ribbon.Implementation.Control;

namespace AddinX.Ribbon.Implementation.Ribbon {
    public class Group : Control.Control, IGroup {
        private IElementId _id;
        private readonly Controls _controls;
        private Controls _boxLauncher;

        private string _supertip;
        private string _screentip;
        private string _keytip;


        public Group() :base("group") {
            _controls = new Controls();
        }

        #region Overrides of AddInElement

        protected internal override void SetRegister(ICallbackRigister register) {
            base.SetRegister(register);
            _controls.SetRegister(register);
            _boxLauncher?.SetRegister(register);
        }

        #endregion

        public IGroupExtra Items(Action<IGroupControls> value) {
            value.Invoke(_controls);
            return this;
        }


        protected internal override XElement ToXml(XNamespace ns) {
            var tmpId = (ElementId) _id;

            var element = base.ToXml(ns);

            element.AddControls(_controls, ns);

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
            _supertip = supertip;
            return this;
        }

        public IGroupExtra Keytip(string keytip) {
            _keytip = keytip;
            return this;
        }

        public IGroupExtra Screentip(string screentip) {
            _screentip = screentip;
            return this;
        }

        public IGroupExtra DialogBoxLauncher(Action<IGroupDialogBox> dialogBox) {
            _boxLauncher = new Controls();
            dialogBox.Invoke(_boxLauncher);
            return this;
        }

        #region Implementation of IRibbonCallback<out IGroup,out IGroupCommand>

        public IGroup Callback(Action<IGroupCommand> builder) {
            builder(base.GetCommand<GroupCommand>());
            return this;
        }

        #endregion
    }
}