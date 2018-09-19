using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Control.GalleryUnsize;
using AddinX.Ribbon.Contract.Control.Item;
using AddinX.Ribbon.Implementation.Ribbon;

namespace AddinX.Ribbon.Implementation.Control {
    public class GalleryUnsize : Control, IGalleryUnsize {
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
        private readonly IGalleryUnsizeControls _controls;

        public GalleryUnsize() {
            _data = new Items();
            ElementName = "gallery";
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
                if (((AddInList) _data)?.ToXml(ns) != null) {
                    element.Add(((AddInList) _data).ToXml(ns));
                }
            }

            // Then the buttons
            if (((AddInList) _controls)?.ToXml(ns) != null) {
                element.Add(((AddInList) _controls).ToXml(ns));
            }

            return element;
        }

        public IGalleryUnsizeExtra SizeString(int size) {
            _gallerySize = size;
            return this;
        }

        public IGalleryUnsizeExtra ItemHeight(int height) {
            _itemHeight = height;
            return this;
        }

        public IGalleryUnsizeExtra ItemWidth(int width) {
            _itemWidth = width;
            return this;
        }

        public IGalleryUnsizeExtra NumberRows(int rows) {
            this._rows = rows;
            return this;
        }

        public IGalleryUnsizeExtra NumberColumns(int cols) {
            this._cols = cols;
            return this;
        }

        public IGalleryUnsizeExtra Supertip(string supertip) {
            this._supertip = supertip;
            return this;
        }

        public IGalleryUnsizeExtra Keytip(string keytip) {
            this._keytip = keytip;
            return this;
        }

        public IGalleryUnsizeExtra Screentip(string screentip) {
            this._screentip = screentip;
            return this;
        }

        public IGalleryUnsizeLabel SetId(string name) {
            Id.SetId(name);
            return this;
        }

        public IGalleryUnsizeLabel SetIdMso(string name) {
            Id.SetMicrosoftId(name);
            return this;
        }

        public IGalleryUnsizeLabel SetIdQ(string ns, string name) {
            Id.SetNamespaceId(ns, name);
            return this;
        }

        public IGalleryUnsizeItemLabel ImageMso(string name) {
            _imageMso = name;
            return this;
        }

        public IGalleryUnsizeItemLabel ImagePath(string name) {
            _imageVisible = true;
            _imagePath = name;
            return this;
        }

        public IGalleryUnsizeItemLabel NoImage() {
            _imageVisible = true;
            _imageVisible = false;
            return this;
        }

        public IGalleryUnsizeItems ShowItemImage() {
            _showItemImage = true;
            return this;
        }

        public IGalleryUnsizeItems HideItemImage() {
            _showItemImage = false;
            return this;
        }

        public IGalleryUnsizeItemImage ShowItemLabel() {
            _showItemLabel = true;
            return this;
        }

        public IGalleryUnsizeItemImage HideItemLabel() {
            _showItemLabel = false;
            return this;
        }

        public IGalleryUnsizeImage ShowLabel() {
            _showLabel = true;
            return this;
        }

        public IGalleryUnsizeImage HideLabel() {
            _showLabel = false;
            return this;
        }

        public IGalleryUnsizeExtra DynamicItems() {
            _dynamicItemsLoading = true;
            return this;
        }

        public IGalleryUnsizeExtra AddItems(Action<IItems> items) {
            _dynamicItemsLoading = false;
            items.Invoke(_data);
            return this;
        }

        public IGalleryUnsizeExtra AddButtons(Action<IGalleryUnsizeControls> items) {
            items.Invoke(_controls);
            return this;
        }
    }
}