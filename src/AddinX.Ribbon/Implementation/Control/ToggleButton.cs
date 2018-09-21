using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Control.ToggleButton;
using AddinX.Ribbon.Contract.Enums;
using AddinX.Ribbon.Implementation.Command;

namespace AddinX.Ribbon.Implementation.Control {
    public class ToggleButton : Control, IToggleButton {
        private bool _imageVisible;
        private string _imageMso;
        private string _imagePath;
        private bool _showLabel;
        private string _description;
        private string _supertip;
        private ControlSize _size;
        private string _screentip;
        private string _keytip;

        public ToggleButton(): base( "toggleButton") {
            _imageVisible = false;
            _size = ControlSize.normal;
            _showLabel = true;
        }

        protected internal override XElement ToXml(XNamespace ns) {
            /*var tmpId = (ElementId) Id;
            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                , new XAttribute("label", Label)
                , _imageVisible
                    ? string.IsNullOrEmpty(_imageMso)
                        ? new XAttribute("image", _imagePath)
                        : new XAttribute("imageMso", _imageMso)
                    : new XAttribute("showImage", "false")
                , new XAttribute("showLabel", _showLabel)
                , new XAttribute("size", _size.ToString())
                , new XAttribute("getEnabled", "GetEnabled")
                , new XAttribute("getVisible", "GetVisible")
                , new XAttribute("onAction", "OnActionPressed")
                , new XAttribute("getPressed", "GetPressed")
                , new XAttribute("tag", tmpId.Value)
            );*/

            var element = base.ToXml(ns);
            element.AddAttribute("showLabel", _showLabel);
            element.AddAttribute("size", _size);
            element.AddImageAttribute(_imageVisible, _imagePath, _imageMso);

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

            return element;
        }

        public IToggleButton SetId(string name) {
            Id.SetId(name);
            return this;
        }

        public IToggleButton SetIdMso(string name) {
            Id.SetMicrosoftId(name);
            return this;
        }

        public IToggleButton SetIdQ(string ns, string name) {
            Id.SetNamespaceId(ns, name);
            return this;
        }

        public IToggleButton ImageMso(string name) {
            _imageVisible = !string.IsNullOrEmpty(name);
            _imageMso = name;
            return this;
        }

        public IToggleButton ImagePath(string path) {
            _imageVisible = !string.IsNullOrEmpty(path);
            _imagePath = path;
            return this;
        }

        public IToggleButton NoImage() {
            _imageVisible = false;
            return this;
        }

        public IToggleButton ShowLabel() {
            _showLabel = true;
            return this;
        }

        public IToggleButton HideLabel() {
            _showLabel = false;
            return this;
        }

        public IToggleButton LargeSize() {
            _size = ControlSize.large;
            return this;
        }

        public IToggleButton NormalSize() {
            _size = ControlSize.normal;
            return this;
        }

        public IToggleButton Description(string description) {
            _description = description;
            return this;
        }

        public IToggleButton Supertip(string supertip) {
            _supertip = supertip;
            return this;
        }

        public IToggleButton Keytip(string keytip) {
            _keytip = keytip;
            return this;
        }

        public IToggleButton Screentip(string screentip) {
            _screentip = screentip;
            return this;
        }

        #region Implementation of IRibbonCallback<out IToggleButton,out IToggleButtonCommand>

        public IToggleButton Callback(Action<IToggleButtonCommand> builder) {
            builder(GetCommand<ToggleButtonCommand>());
            return this;
        }

        #endregion
    }
}