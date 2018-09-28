using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Control.ButtonGroup;
using AddinX.Ribbon.Implementation.Command;
using AddinX.Ribbon.Implementation.Ribbon;

namespace AddinX.Ribbon.Implementation.Control {
    public class ButtonGroup : Control<IButtonGroup, IButtonGroupCommand>, IButtonGroup {
        private readonly Controls _items;

        public ButtonGroup() : base("buttonGroup") {
            _items = new Controls();
        }

        protected internal override XElement ToXml(XNamespace ns) {
            /*var tmpId = (ElementId) Id;
            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                , new XAttribute("getVisible", "GetVisible")
            );
            */
            var element = base.ToXml(ns);
            foreach (var item in _items.ToXml(ns)) {
                element.Add(item);
            }

            return element;
        }

        protected override IButtonGroup Interface => this;

        public IButtonGroup Items(Action<IButtonGroupControls> builder) {
            builder.Invoke(_items);
            return this;
        }

        #region Implementation of IRibbonCallback<out IButtonGroup,out IButtonGroupCommand>

        public void Callback(Action<IButtonGroupCommand> builder) {
            builder(GetCommand<ButtonGroupCommand>());
        }

        #endregion
    }
}