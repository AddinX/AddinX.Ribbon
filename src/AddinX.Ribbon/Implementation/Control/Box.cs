using System;
using System.Linq;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Control.Box;
using AddinX.Ribbon.Contract.Control.Gallery;
using AddinX.Ribbon.Contract.Enums;
using AddinX.Ribbon.Implementation.Ribbon;

namespace AddinX.Ribbon.Implementation.Control {
    public class Box : Control, IBox {
        private readonly Controls _items;
        private BoxStyle _style;

        public Box() {
            _items = new Controls();
            ElementName = "box";
            Id = new ElementId();
        }

        public IBox SetId(string name) {
            Id.SetId(name);
            return this;
        }

        public IBox SetIdMso(string name) {
           // throw new NotImplementedException();
            return this;
        }

        public IBox SetIdQ(string ns, string name) {
            Id.SetNamespaceId(ns, name);
            return this;
        }

        public IBox HorizontalDisplay() {
            _style = BoxStyle.horizontal;
            return this;
        }

        public IBox VerticalDisplay() {
            _style = BoxStyle.vertical;
            return this;
        }

        public IBox AddItems(Action<IBoxControls> items) {
            items.Invoke(this._items);
            return this;
        }

        protected internal override XElement ToXml(XNamespace ns) {
            var element = base.ToXml(ns);
            element.AddCallbackAttribute("getVisible",this.IsVisibleField);
            element.AddAttribute("boxStyle",_style);
            element.AddControls(_items, ns);
            return element;
        }

        #region Implementation of IBoxCommand

        public Func<bool> IsVisibleField { get; private set; }

        public void IsVisible(Func<bool> condition) {
            IsVisibleField = condition;
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

        public static void AddControls(this XElement element, IGalleryControls controls, XNamespace ns) {
            if (controls is Controls ctls) {
                element.AddControls(ctls, ns);
            }
        }

        public static void AddControls(this XElement element, AddInList list, XNamespace ns) {
            var items = list?.ToXml(ns);
            if (items != null && items.Any()) {
                foreach (var item in items) {
                    element.Add(item);
                }
            }
        }
    }
}