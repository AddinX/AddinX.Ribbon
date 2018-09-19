using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Control.Gallery;
using AddinX.Ribbon.Contract.Control.Item;
using AddinX.Ribbon.Contract.Enums;
using AddinX.Ribbon.Implementation.Ribbon;

namespace AddinX.Ribbon.Implementation.Control {
    public class Gallery : Control, IGallery {
        private ControlSize _size;
        private string _imageMso;
        private string _imagePath;
        private bool _imageVisible;
        private string _supertip;
        private string _screentip;
        private string _keytip;
        private bool _showLabel = true;
        private bool _showItemImage = true;
        private int _gallerySize;
        private bool _showItemLabel = true;
        private bool _dynamicItemsLoading;
        private readonly IItems _data;
        private int _itemHeight;
        private int _itemWidth;
        private int _rows;
        private int _cols;
        private readonly IGalleryControls _controls;

        public Gallery() {
            _data = new Items();
            ElementName = "gallery";
            _size = ControlSize.normal;
            Id = new ElementId();
            _controls = new Controls();
            _imageVisible = false;
            _gallerySize = 7;
            _itemHeight = 0;
            _itemWidth = 0;
            _rows = -1;
            _cols = -1;
        }

        protected internal override XElement ToXml(XNamespace ns) {
            var tmpId = (ElementId) Id;

            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                , new XAttribute("label", Label)
                , new XAttribute("sizeString", new string('W', _gallerySize))
                , new XAttribute("showLabel", _showLabel)
                , new XAttribute("showItemImage", _showItemImage)
                , new XAttribute("showItemLabel", _showItemLabel)
                , _imageVisible
                    ? string.IsNullOrEmpty(_imageMso)
                        ? new XAttribute("image", _imagePath)
                        : new XAttribute("imageMso", _imageMso)
                    : new XAttribute("showImage", "false")
                , new XAttribute("size", _size.ToString())
                , new XAttribute("getEnabled", "GetEnabled")
                , new XAttribute("getVisible", "GetVisible")
                , new XAttribute("onAction", "OnActionDropDown")
                , new XAttribute("getSelectedItemIndex", "GetSelectedItemIndex")
                , new XAttribute("tag", tmpId.Value)
            );

            if (_itemHeight > 0) {
                element.Add(new XAttribute("itemHeight", _itemHeight));
            }

            if (_itemWidth > 0) {
                element.Add(new XAttribute("itemWidth", _itemWidth));
            }

            if (_rows >= 0) {
                element.Add(new XAttribute("rows", _rows));
            }

            if (_cols >= 0) {
                element.Add(new XAttribute("columns", _cols));
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

            if (_dynamicItemsLoading) {
                element.Add(new XAttribute("getItemCount", "GetItemCount")
                    , new XAttribute("getItemID", "GetItemId")
                    , new XAttribute("getItemImage", "GetItemImage")
                    , new XAttribute("getItemLabel", "GetItemLabel")
                    , new XAttribute("getItemScreentip", "GetItemScreentip")
                    , new XAttribute("getItemSupertip", "GetItemSupertip"));
            } else {
                // Add the Items first
                element.AddControls((AddInList) _data, ns);
            }

            // Then the buttons
            element.AddControls(_controls, ns);

            return element;
        }

        public IGalleryExtra SizeString(int size) {
            _gallerySize = size;
            return this;
        }

        public IGalleryExtra ItemHeight(int height) {
            _itemHeight = height;
            return this;
        }

        public IGalleryExtra ItemWidth(int width) {
            _itemWidth = width;
            return this;
        }

        public IGalleryExtra NumberRows(int rows) {
            this._rows = rows;
            return this;
        }

        public IGalleryExtra NumberColumns(int cols) {
            this._cols = cols;
            return this;
        }

        public IGalleryExtra Supertip(string supertip) {
            this._supertip = supertip;
            return this;
        }

        public IGalleryExtra Keytip(string keytip) {
            this._keytip = keytip;
            return this;
        }

        public IGalleryExtra Screentip(string screentip) {
            this._screentip = screentip;
            return this;
        }

        public IGalleryLabel SetId(string name) {
            Id.SetId(name);
            return this;
        }

        public IGalleryLabel SetIdMso(string name) {
            Id.SetMicrosoftId(name);
            return this;
        }

        public IGalleryLabel SetIdQ(string ns, string name) {
            Id.SetNamespaceId(ns, name);
            return this;
        }

        public IGalleryItemLabel ImageMso(string name) {
            _imageVisible = true;
            _imageMso = name;
            return this;
        }

        public IGalleryItemLabel ImagePath(string name) {
            _imageVisible = true;
            _imagePath = name;
            return this;
        }

        public IGalleryItemLabel NoImage() {
            _imageVisible = false;
            return this;
        }

        public IGalleryItems ShowItemImage() {
            _showItemImage = true;
            return this;
        }

        public IGalleryItems HideItemImage() {
            _showItemImage = false;
            return this;
        }

        public IGalleryItemImage ShowItemLabel() {
            _showItemLabel = true;
            return this;
        }

        public IGalleryItemImage HideItemLabel() {
            _showItemLabel = false;
            return this;
        }

        public IGallerySize ShowLabel() {
            _showLabel = true;
            return this;
        }

        public IGallerySize HideLabel() {
            _showLabel = false;
            return this;
        }

        public IGalleryExtra DynamicItems() {
            _dynamicItemsLoading = true;
            return this;
        }

        public IGalleryImage LargeSize() {
            _size = ControlSize.large;
            return this;
        }

        public IGalleryImage NormalSize() {
            _size = ControlSize.normal;
            return this;
        }

        public IGalleryExtra AddItems(Action<IItems> items) {
            _dynamicItemsLoading = false;
            items.Invoke(_data);
            return this;
        }

        public IGalleryExtra AddButtons(Action<IGalleryControls> items) {
            items.Invoke(_controls);
            return this;
        }
    }
}