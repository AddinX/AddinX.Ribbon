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

        public Button(ICallbackRigister register) :base(register, "button") {
            _size = ControlSize.normal;
            _imageVisible = false;
            _showLabel = false;
        }

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
        }

        public IButton SetIdMso(string name) {
            Id = new ElementId().SetMicrosoftId(name);
            return this;
        }

        public IButton SetIdQ(string ns, string name) {
            Id = new ElementId().SetNamespaceId(ns, name);
            return this;
        }

        public IButton SetId(string name) {
            Id = new ElementId().SetId(name);
            return this;
        }


        public IButton ImageMso(string name) {
            _imageVisible = !string.IsNullOrEmpty(name);
            _imageMso = name;
            return this;
        }

        public IButton ImagePath(string name) {
            _imageVisible = !string.IsNullOrEmpty(name);;
            _imagePath = name;
            return this;
        }

        public IButton NoImage() {
            _imageVisible = false;
            return this;
        }

        public IButton Description(string description) {
            _description = description;
            return this;
        }

        public IButton Keytip(string keytip) {
            _keytip = keytip;
            return this;
        }

        public IButton Supertip(string supertip) {
            _supertip = supertip;
            return this;
        }

        public IButton Screentip(string screentip) {
            _screentip = screentip;
            return this;
        }

        public IButton LargeSize() {
            _size = ControlSize.large;
            return this;
        }

        public IButton NormalSize() {
            _size = ControlSize.normal;
            return this;
        }

        public IButton ShowLabel() {
            _showLabel = true;
            return this;
        }

        public IButton HideLabel() {
            _showLabel = false;
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