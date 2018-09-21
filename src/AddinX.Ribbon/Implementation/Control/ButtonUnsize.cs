using System.Xml.Linq;
using AddinX.Ribbon.Contract;
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

        public ButtonUnsize(): base( "button") {
            _imageVisible = false;
        }

        protected internal override XElement ToXml(XNamespace ns) {
            //var tmpId = (ElementId) Id;
            var element = base.ToXml(ns);
            /*var element = new XElement(ns + ElementName
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
            );*/

                element.AddAttribute("showLabel", _showLabel);
            element.AddImageAttribute(_imageVisible,_imagePath,_imageMso);

            element.AddAttribute("screentip", _screentip);
            element.AddAttribute("supertip", _supertip);
            element.AddAttribute("keytip", _keytip);
            element.AddAttribute("description", _description);

            return element;
        }

        public IButtonUnsize SetIdMso(string name) {
            Id.SetMicrosoftId(name);
            return this;
        }

        public IButtonUnsize SetIdQ(string ns, string name) {
            Id.SetNamespaceId(ns, name);
            return this;
        }

        public IButtonUnsize SetId(string name) {
            Id.SetId(name);
            return this;
        }


        public IButtonUnsize ImageMso(string name) {
            _imageVisible = !string.IsNullOrEmpty(name);;
            _imageMso = name;
            return this;
        }

        public IButtonUnsize ImagePath(string path) {
            _imageVisible = !string.IsNullOrEmpty(path);;
            _imagePath = path;
            return this;
        }

        public IButtonUnsize NoImage() {
            _imageVisible = false;
            return this;
        }

        public IButtonUnsize Description(string description) {
            _description = description;
            return this;
        }

        public IButtonUnsize Keytip(string keytip) {
            _keytip = keytip;
            return this;
        }

        public IButtonUnsize Supertip(string supertip) {
            _supertip = supertip;
            return this;
        }

        public IButtonUnsize Screentip(string screentip) {
            _screentip = screentip;
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