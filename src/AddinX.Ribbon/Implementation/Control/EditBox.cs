using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Control.EditBox;
using AddinX.Ribbon.Implementation.Command;

namespace AddinX.Ribbon.Implementation.Control {
    public class EditBox : Control, IEditBox {
        private bool _imageVisible;
        private string _imageMso;
        private string _imagePath;
        private string _supertip;
        private string _screentip;
        private string _keytip;
        private int _maxlength;
        private int _editBoxSize;

        public EditBox(): base( "editBox") {
            _imageVisible = false;
            _maxlength = 15;
            _editBoxSize = _maxlength;
        }

        protected internal override XElement ToXml(XNamespace ns) {
            var tmpId = (ElementId) Id;
            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                , new XAttribute("label", Label)
                , new XAttribute("maxLength", _maxlength)
                , new XAttribute("sizeString", new string('W', _editBoxSize))
                , _imageVisible
                    ? string.IsNullOrEmpty(_imageMso)
                        ? new XAttribute("image", _imagePath)
                        : new XAttribute("imageMso", _imageMso)
                    : new XAttribute("showImage", "false")
                , new XAttribute("getEnabled", "GetEnabled")
                , new XAttribute("getVisible", "GetVisible")
                , new XAttribute("onChange", "OnChange")
                , new XAttribute("getText", "GetText")
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

            return element;
        }


        public IEditBox SetId(string name) {
            Id.SetId(name);
            return this;
        }

        public IEditBox SetIdMso(string name) {
            Id.SetMicrosoftId(name);
            return this;
        }

        public IEditBox SetIdQ(string ns, string name) {
            Id.SetNamespaceId(ns, name);
            return this;
        }

        public IEditBox ImageMso(string name) {
            _imageVisible = !string.IsNullOrEmpty(name);;
            _imageMso = name;
            return this;
        }

        public IEditBox ImagePath(string path) {
            _imageVisible = !string.IsNullOrEmpty(path);;
            _imagePath = path;
            return this;
        }

        public IEditBox NoImage() {
            _imageVisible = false;
            return this;
        }

        public IEditBox MaxLength(int maxLength) {
            _maxlength = maxLength;
            return this;
        }

        public IEditBox SizeString(int editBoxSize) {
            _editBoxSize = editBoxSize;
            return this;
        }

        public IEditBox Supertip(string supertip) {
            _supertip = supertip;
            return this;
        }

        public IEditBox Keytip(string keytip) {
            _keytip = keytip;
            return this;
        }

        public IEditBox Screentip(string screentip) {
            _screentip = screentip;
            return this;
        }

        #region Implementation of IRibbonCallback<out IEditBox,out IEditBoxCommand>

        public IEditBox Callback(Action<IEditBoxCommand> builder) {
            builder(GetCommand<EditBoxCommand>());
            return this;
        }

        #endregion
    }
}