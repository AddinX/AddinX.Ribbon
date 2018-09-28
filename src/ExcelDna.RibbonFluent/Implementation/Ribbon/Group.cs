using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Ribbon.Group;
using AddinX.Ribbon.Implementation.Command;
using AddinX.Ribbon.Implementation.Control;

namespace AddinX.Ribbon.Implementation.Ribbon {
    public class Group : ControlContainer<IGroup, Controls>, IGroup {
        private Controls _boxLauncher;

        public Group() : base("group") {
        }

        #region Overrides of AddInElement

        protected internal override void SetRegister(ICallbackRigister register) {
            base.SetRegister(register);
            _boxLauncher?.SetRegister(register);
        }

        #endregion

        protected internal override XElement ToXml(XNamespace ns) {
            var element = base.ToXml(ns);

            if (_boxLauncher != null) {
                element.AddControls((AddInList) _boxLauncher, ns);
            }

            return element;
        }

        protected override IGroup Interface => this;

        public IGroup DialogBoxLauncher(Action<IGroupDialogBox> dialogBox) {
            _boxLauncher = new Controls();
            dialogBox.Invoke(_boxLauncher);
            return this;
        }

        #region Implementation of IRibbonCallback<out IGroup,out IGroupCommand>

        public void Callback(Action<IGroupCommand> builder) {
            builder?.Invoke(GetCommand<GroupCommand>());
        }

        public void Callback(IGroupCommand command) {
            base.SetCommand(command);
        }

        #endregion

        #region Implementation of IRibbonItems<out IGroup,out IGroupControls>

        public IGroup Items(Action<IGroupControls> builder) {
            builder?.Invoke(base.InnerItems);
            return this;
        }

        #endregion
    }
}