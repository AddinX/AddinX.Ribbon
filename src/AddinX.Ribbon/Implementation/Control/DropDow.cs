using System;
using System.Linq;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Control.DropDown;
using AddinX.Ribbon.Contract.Control.Item;
using AddinX.Ribbon.Implementation.Command;
using AddinX.Ribbon.Implementation.Ribbon;

namespace AddinX.Ribbon.Implementation.Control {
    public class DropDow : Control<IDropDown, IDropDownCommand>, IDropDown {
        private bool _dynamicItemsLoading;
        private readonly Items _data;
        private readonly Controls _controls;

        public DropDow() : base("dropDown") {
            _data = new Items();
            _controls = new Controls();
            NoImage();
            SizeString(7);
        }

        protected internal override void SetRegister(ICallbackRigister register) {
            base.SetRegister(register);
            _data.SetRegister(register);
            _controls.SetRegister(register);
        }

        protected internal override XElement ToXml(XNamespace ns) {
            var element = base.ToXml(ns);
            if (!_dynamicItemsLoading) {
                // Add the Items first
                if (_data.Any()) {
                    element.Add(_data.ToXml(ns));
                }
            }

            // Then the buttons
            if (_controls.Any()) {
                element.Add(_controls.ToXml(ns));
            }

            return element;
        }

        public IDropDown Buttons(Action<IDropDownControls> items) {
            items.Invoke(_controls);
            return this;
        }

        protected override IDropDown Interface => this;

        public IDropDown DynamicItems() {
            _dynamicItemsLoading = true;
            return this;
        }

        public IDropDown Items(Action<IItems> builder) {
            _dynamicItemsLoading = false;
            builder.Invoke(_data);
            return this;
        }

        #region Implementation of IRibbonCallback<out IDropDown,out IDropDownCommand>

        public void Callback(Action<IDropDownCommand> builder) {
            builder(GetCommand<DropDownCommand>());
        }

        #endregion
    }
}