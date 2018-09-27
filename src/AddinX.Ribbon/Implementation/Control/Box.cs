using System;
using System.Linq;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Control.Box;
using AddinX.Ribbon.Contract.Enums;
using AddinX.Ribbon.Implementation.Command;
using AddinX.Ribbon.Implementation.Ribbon;

namespace AddinX.Ribbon.Implementation.Control {
    public class Box : Control<IBox,IBoxCommand>, IBox {
        private const string tag_boxStyle = "boxStyle";
        private readonly Controls _items;

        public Box(): base( "box") {
            _items = new Controls();
        }

        protected internal override void SetRegister(ICallbackRigister register) {
            base.SetRegister(register);
            _items?.SetRegister(register);
        }

        protected override IBox Interface => this;

        public IBox HorizontalDisplay() {
            SetAttribute(tag_boxStyle, BoxStyle.horizontal);
            return this;
        }

        public IBox VerticalDisplay() {
            SetAttribute(tag_boxStyle, BoxStyle.vertical); 
            return this;
        }

        public IBox Items(Action<IBoxControls> items) {
            items.Invoke(_items);
            return this;
        }

        protected internal override XElement ToXml(XNamespace ns) {
            var element = base.ToXml(ns);
            element.AddControls(_items, ns);
            return element;
        }


        #region Implementation of IRibbonCallback<out IBoxCommand>

        public void Callback(Action<IBoxCommand> builder) {
            builder(GetCommand<BoxCommand>());
        }

        #endregion
    }

    internal static class XElementExtensions {
        public static void AddControls(this XElement element, Controls items, XNamespace ns) {
            if (items == null) {
                return;
            }

            if (items.HasItems) {
                foreach (var item in items.ToXml(ns)) {
                    element.Add(item);
                }
            }
        }

        public static void AddControls<T>(this XElement element, AddInList<T> items, XNamespace ns) where T : AddInElement {
            if (items == null) {
                return;
            }

            foreach (var item in items) {
                element.Add(item.ToXml(ns));
            }
        }

        public static void AddControls(this XElement element, AddInList list, XNamespace ns) {
            var items = list?.ToXml(ns).ToArray();
            if (items != null && items.Any()) {
                foreach (var item in items) {
                    element.Add(item);
                }
            }
        }
    }
}