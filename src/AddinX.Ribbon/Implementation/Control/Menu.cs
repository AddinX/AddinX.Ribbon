using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Control.Menu;
using AddinX.Ribbon.Contract.Enums;
using AddinX.Ribbon.Implementation.Command;
using AddinX.Ribbon.Implementation.Ribbon;

namespace AddinX.Ribbon.Implementation.Control {
    public class Menu : Control, IMenu {
        private string _imageMso;
        private string _imagePath;
        private bool _imageVisible;
        private string _supertip;
        private string _screentip;
        private string _keytip;
        private string _description;
        private bool _showLabel = true;
        private ControlSize _itemSize = ControlSize.normal;
        private ControlSize _size = ControlSize.normal;

        private readonly IMenuControls _controls;

        public Menu(ICallbackRigister register) : base(register, "menu") {
            _controls = new Controls(register);
            _imageVisible = false;
        }

        public IMenu Description(string description) {
            _description = description;
            return this;
        }

        public IMenu Supertip(string supertip) {
            _supertip = supertip;
            return this;
        }

        public IMenu Keytip(string keytip) {
            _keytip = keytip;
            return this;
        }

        public IMenu Screentip(string screentip) {
            _screentip = screentip;
            return this;
        }

        public IMenu SetId(string name) {
            Id.SetId(name);
            return this;
        }

        public IMenu SetIdMso(string name) {
            Id.SetMicrosoftId(name);
            return this;
        }

        public IMenu SetIdQ(string ns, string name) {
            Id.SetNamespaceId(ns, name);
            return this;
        }

        public IMenu ImageMso(string name) {
            _imageVisible = !string.IsNullOrEmpty(name);
            _imageMso = name;
            return this;
        }

        public IMenu ImagePath(string name) {
            _imageVisible = !string.IsNullOrEmpty(name);
            _imagePath = name;
            return this;
        }

        public IMenu NoImage() {
            _imageVisible = false;
            return this;
        }

        public IMenu NormalSize() {
            _size = ControlSize.normal;
            return this;
        }

        public IMenu LargeSize() {
            _size = ControlSize.large;
            return this;
        }

        public IMenu ItemNormalSize() {
            _itemSize = ControlSize.normal;
            return this;
        }

        public IMenu ItemLargeSize() {
            _itemSize = ControlSize.large;
            return this;
        }

        public IMenu ShowLabel() {
            _showLabel = true;
            return this;
        }

        public IMenu HideLabel() {
            _showLabel = false;
            return this;
        }

        public IMenu AddItems(Action<IMenuControls> items) {
            items.Invoke(_controls);
            return this;
        }

        protected internal override XElement ToXml(XNamespace ns) {
            var tmpId = (ElementId) Id;

            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                , new XAttribute("label", Label)
                , new XAttribute("size", _size.ToString())
                , new XAttribute("showLabel", _showLabel)
                , new XAttribute("itemSize", _itemSize.ToString())
                , _imageVisible
                    ? string.IsNullOrEmpty(_imageMso)
                        ? new XAttribute("image", _imagePath)
                        : new XAttribute("imageMso", _imageMso)
                    : new XAttribute("showImage", "false")
                , new XAttribute("getEnabled", "GetEnabled")
                , new XAttribute("getVisible", "GetVisible")
                , new XAttribute("tag", tmpId.Value)
            );

            if (!string.IsNullOrEmpty(_screentip)) {
                element.Add(new XAttribute("screentip", _screentip));
            }

            if (!string.IsNullOrEmpty(_supertip)) {
                element.Add(new XAttribute("supertip", _supertip));
            }

            if (!string.IsNullOrEmpty(_keytip)) {
                element.Add(new XAttribute("keytip", _keytip));
            }

            if (!string.IsNullOrEmpty(_description)) {
                element.Add(new XAttribute("description", _description));
            }

            if (((AddInList) _controls)?.ToXml(ns) != null) {
                element.Add(((AddInList) _controls).ToXml(ns));
            }

            return element;
        }

        #region Implementation of IRibbonCallback<out IMenu,out IMenuCommand>

        public IMenu Callback(Action<IMenuCommand> builder) {
            builder(GetCommand<MenuCommand>());
            return this;
        }

        #endregion
    }
}