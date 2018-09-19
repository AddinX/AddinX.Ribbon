using System.Xml.Linq;
using AddinX.Ribbon.Contract.Control.ButtonUnsize;

namespace AddinX.Ribbon.Implementation.Control {
    public class ButtonUnsize : Control, IButtonUnsize {
        private bool _imageVisible;
        private string _imageMso;
        private string _imagePath;
        private string _description;
        private string _supertip;
        private string _screentip;
        private string _keytip;
        private bool _showLabel;

        public ButtonUnsize() {
            ElementName = "button";
            Id = new ElementId();
            _imageVisible = false;
        }

        protected internal override XElement ToXml(XNamespace ns) {
            var tmpId = (ElementId) Id;
            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                , new XAttribute("showLabel", _showLabel)
                , _imageVisible
                    ? string.IsNullOrEmpty(_imageMso)
                        ? new XAttribute("image", _imagePath)
                        : new XAttribute("imageMso", _imageMso)
                    : new XAttribute("showImage", "false")
                , new XAttribute("getEnabled", "GetEnabled")
                , new XAttribute("getVisible", "GetVisible")
                , new XAttribute("onAction", "OnAction")
                , new XAttribute("tag", tmpId.Value)
            );

            if (!string.IsNullOrEmpty(Label)) {
                element.Add(new XAttribute("label", Label));
            }

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

        public IButtonUnsize SetIdMso(string name) {
            Id = new ElementId().SetMicrosoftId(name);
            return this;
        }

        public IButtonUnsize SetIdQ(string ns, string name) {
            Id = new ElementId().SetNamespaceId(ns, name);
            return this;
        }

        public IButtonUnsize SetId(string name) {
            Id = new ElementId().SetId(name);
            return this;
        }


        public IButtonUnsize ImageMso(string name) {
            _imageVisible = true;
            _imageMso = name;
            return this;
        }

        public IButtonUnsize ImagePath(string name) {
            _imageVisible = true;
            _imagePath = name;
            return this;
        }

        public IButtonUnsize NoImage() {
            _imageVisible = false;
            return this;
        }

        public IButtonUnsize Description(string description) {
            this._description = description;
            return this;
        }

        public IButtonUnsize Keytip(string keytip) {
            this._keytip = keytip;
            return this;
        }

        public IButtonUnsize Supertip(string supertip) {
            this._supertip = supertip;
            return this;
        }

        public IButtonUnsize Screentip(string screentip) {
            this._screentip = screentip;
            return this;
        }

        public IButtonUnsize ShowLabel() {
            _showLabel = true;
            return this;
        }

        public IButtonUnsize HideLabel() {
            _showLabel = false;
            return this;
        }
    }
}