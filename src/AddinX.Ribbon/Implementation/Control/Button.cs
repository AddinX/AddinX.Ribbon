using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Control.Button;
using AddinX.Ribbon.Contract.Enums;
using AddinX.Ribbon.Implementation.Command;

namespace AddinX.Ribbon.Implementation.Control {
    public class Button : Control, IButton {
        private bool _imageVisible;
        private string _imageMso;
        private string _imagePath;
        private string _description;
        private string _supertip;
        private ControlSize _size;
        private string _screentip;
        private string _keytip;
        private bool _showLabel;

        public Button() :base("button") {
            _size = ControlSize.normal;
            _imageVisible = false;
            _showLabel = false;
        }

        /*
        protected internal override XElement ToXml(XNamespace ns) {
           
            var element = base.ToXml(ns);
            // new XElement(ns + ElementName
            
            element.AddAttribute("showLabel", _showLabel,false);
            if (_imageVisible) {
                element.AddAttribute("image", _imagePath);
                element.AddAttribute("imageMso", _imageMso);
            } else {
                element.AddAttribute("showImage", false,false);
            }
            element.AddAttribute("size", _size);

            element.AddAttribute("screentip", _screentip);
            element.AddAttribute("supertip", _supertip);
            element.AddAttribute("keytip", _keytip);
            element.AddAttribute("description", _description);
            
            return element;
        }*/

        public IButton SetIdMso(string name) {
            Id.SetMicrosoftId(name);
            return this;
        }

        public IButton SetIdQ(string ns, string name) {
            Id.SetNamespaceId(ns, name);
            return this;
        }

        public IButton SetId(string name) {
            Id.SetId(name);
            return this;
        }


        public IButton ImageMso(string name) {
            //_imageVisible = !string.IsNullOrEmpty(name);
            //_imageMso = name;
            this.ImageMsoImpl(name);
            return this;
        }

        public IButton ImagePath(string path) {
            this.ImagePathImpl(path);
            //_imageVisible = !string.IsNullOrEmpty(path);;
            //_imagePath = path;
            return this;
        }

        public IButton NoImage() {
            base.SetAttribute(tag_showImage,false);
            base.RemoveAttribute(tag_image);
            base.RemoveAttribute(tag_imageMso);
            // _imageVisible = false;
            return this;
        }

        public IButton Description(string description) {
            base.SetAttribute(tag_description,description);
            //_description = description;
            return this;
        }

        public IButton Keytip(string keytip) {
            base.SetAttribute(tag_keytip,keytip);
            //_keytip = keytip;
            return this;
        }

        public IButton Supertip(string supertip) {
            base.SetAttribute(tag_supertip,supertip);
            //_supertip = supertip;
            return this;
        }

        public IButton Screentip(string screentip) {
            this.ScreentipImpl(screentip);
            //_screentip = screentip;
            return this;
        }

        public IButton LargeSize() {
            base.SetAttribute(tag_size,ControlSize.large);
            //_size = ControlSize.large;
            return this;
        }

        public IButton NormalSize() {
            base.SetAttribute(tag_size, ControlSize.normal);
            //_size = ControlSize.normal;
            return this;
        }

        public IButton ShowLabel() {
            base.SetAttribute(tag_showLabel,true);
            //_showLabel = true;
            return this;
        }

        public IButton HideLabel() {
            base.SetAttribute(tag_showLabel, false);
            //_showLabel = false;
            return this;
        }

        #region Implementation of IRibbonCommands<out IButtonCommand>

        public IButton Callback(Action<IButtonCommand> builder) {
            builder(GetCommand<ButtonCommand>());
            return this;
        }

        #endregion
    }
}