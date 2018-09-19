using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Control.ComboBox;
using AddinX.Ribbon.Contract.Control.Item;

namespace AddinX.Ribbon.Implementation.Control {
    public class ComboBox : Control, IComboBox {
        private string _imageMso;
        private string _imagePath;
        private bool _imageVisible;
        private string _supertip;
        private string _screentip;
        private string _keytip;
        private bool _showLabel;
        private bool _showItemImage;
        private int _comboBoxSize;
        private int _maxLength;
        private bool _dynamicItemLoading;
        private readonly IItems _data;

        public ComboBox() {
            _data = new Items();
            ElementName = "comboBox";
            Id = new ElementId();
            _imageVisible = false;
            _maxLength = 7;
            _comboBoxSize = _maxLength;
        }

        public IComboBox SetId(string name) {
            Id = new ElementId().SetId(name);
            return this;
        }

        public IComboBox SetIdMso(string name) {
            Id = new ElementId().SetMicrosoftId(name);
            return this;
        }

        public IComboBox SetIdQ(string ns, string name) {
            Id = new ElementId().SetNamespaceId(ns, name);
            return this;
        }

        public IComboBox ImageMso(string name) {
            _imageVisible = true;
            _imageMso = name;
            return this;
        }

        public IComboBox ImagePath(string name) {
            _imageVisible = true;
            _imagePath = name;
            return this;
        }

        public IComboBox NoImage() {
            _imageVisible = false;
            return this;
        }

        public IComboBox ShowItemImage() {
            _showItemImage = false;
            return this;
        }

        public IComboBox HideItemImage() {
            _showItemImage = false;
            return this;
        }

        public IComboBox ShowLabel() {
            _showLabel = true;
            return this;
        }

        public IComboBox HideLabel() {
            _showLabel = false;
            return this;
        }

        public IComboBox Supertip(string supertip) {
            this._supertip = supertip;
            return this;
        }

        public IComboBox Keytip(string keytip) {
            this._keytip = keytip;
            return this;
        }

        public IComboBox Screentip(string screentip) {
            this._screentip = screentip;
            return this;
        }

        public IComboBox MaxLength(int maxLength) {
            this._maxLength = maxLength;
            return this;
        }

        public IComboBox SizeString(int comboBoxSize) {
            this._comboBoxSize = comboBoxSize;
            return this;
        }

        protected internal override XElement ToXml(XNamespace ns) {
            var tmpId = (ElementId) Id;
            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                , new XAttribute("label", Label)
                , new XAttribute("maxLength", _maxLength)
                , new XAttribute("sizeString", new string('W', _comboBoxSize))
                , new XAttribute("showLabel", _showLabel)
                , new XAttribute("showItemImage", _showItemImage)
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

            if (_dynamicItemLoading) {
                element.Add(new XAttribute("getItemCount", "GetItemCount")
                    , new XAttribute("getItemID", "GetItemId")
                    , new XAttribute("getItemImage", "GetItemImage")
                    , new XAttribute("getItemLabel", "GetItemLabel")
                    , new XAttribute("getItemScreentip", "GetItemScreentip")
                    , new XAttribute("getItemSupertip", "GetItemSupertip")
                );
            } else {
                if (((AddInList) _data)?.ToXml(ns) != null) {
                    element.Add(((AddInList) _data).ToXml(ns));
                }
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

            return element;
        }

        public IComboBox AddItems(Action<IItems> items) {
            _dynamicItemLoading = false;
            items.Invoke(_data);
            return this;
        }

        public IComboBox DynamicItems() {
            _dynamicItemLoading = true;
            return this;
        }
    }
}