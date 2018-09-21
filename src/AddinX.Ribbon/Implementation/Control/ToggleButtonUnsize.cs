using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Control.ToggleButtonUnsize;

namespace AddinX.Ribbon.Implementation.Control {
    public class ToggleButtonUnsize : Control, IToggleButtonUnsize {
        private bool _imageVisible;
        private string _imageMso;
        private string _imagePath;
        private bool _showLabel;
        private string _description;
        private string _supertip;
        private string _screentip;
        private string _keytip;

        public ToggleButtonUnsize(): base( "toggleButton") {
            _imageVisible = false;
        }

        protected internal override XElement ToXml(XNamespace ns) {
            var tmpId = (ElementId) Id;
            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                , new XAttribute("label", Label)
                , _imageVisible
                    ? string.IsNullOrEmpty(_imageMso)
                        ? new XAttribute("image", _imagePath)
                        : new XAttribute("imageMso", _imageMso)
                    : new XAttribute("showImage", "false")
                , new XAttribute("showLabel", _showLabel)
                , new XAttribute("getEnabled", "GetEnabled")
                , new XAttribute("getVisible", "GetVisible")
                , new XAttribute("onAction", "OnActionPressed")
                , new XAttribute("getPressed", "GetPressed")
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

            return element;
        }

        public IToggleButtonUnsize SetId(string name) {
            Id.SetId(name);
            return this;
        }

        public IToggleButtonUnsize SetIdMso(string name) {
            Id.SetMicrosoftId(name);
            return this;
        }

        public IToggleButtonUnsize SetIdQ(string ns, string name) {
            Id.SetNamespaceId(ns, name);
            return this;
        }

        public IToggleButtonUnsize ImageMso(string name) {
            _imageVisible = !string.IsNullOrEmpty(name);
            _imageMso = name;
            return this;
        }

        public IToggleButtonUnsize ImagePath(string path) {
            _imageVisible = !string.IsNullOrEmpty(path);
            _imagePath = path;
            return this;
        }

        public IToggleButtonUnsize NoImage() {
            _imageVisible = false;
            return this;
        }

        public IToggleButtonUnsize ShowLabel() {
            _showLabel = true;
            return this;
        }

        public IToggleButtonUnsize HideLabel() {
            _showLabel = false;
            return this;
        }

        public IToggleButtonUnsize Description(string description) {
            _description = description;
            return this;
        }

        public IToggleButtonUnsize Supertip(string supertip) {
            _supertip = supertip;
            return this;
        }

        public IToggleButtonUnsize Keytip(string keytip) {
            _keytip = keytip;
            return this;
        }

        public IToggleButtonUnsize Screentip(string screentip) {
            _screentip = screentip;
            return this;
        }
    }
}