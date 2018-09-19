using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Control.DropDown;
using AddinX.Ribbon.Contract.Control.Item;
using AddinX.Ribbon.Implementation.Ribbon;

namespace AddinX.Ribbon.Implementation.Control {
    public class DropDow : Control, IDropDown {
        private string _imageMso;
        private string _imagePath;
        private bool _imageVisible;
        private string _supertip;
        private string _screentip;
        private string _keytip;
        private bool _showLabel = true;
        private bool _showItemImage = true;
        private int _dropDownSize;
        private bool _showItemLabel = true;
        private bool _dynamicItemsLoading;
        private readonly IItems _data;
        private readonly IDropDownControls _controls;

        public DropDow() {
            _data = new Items();
            ElementName = "dropDown";
            Id = new ElementId();
            _controls = new Controls();
            _imageVisible = false;
            _dropDownSize = 7;
        }

        protected internal override XElement ToXml(XNamespace ns) {
            var tmpId = (ElementId) Id;

            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                , new XAttribute("label", Label)
                , new XAttribute("sizeString", new string('W', _dropDownSize))
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
                if (((AddInList) _data).ToXml(ns) != null) {
                    element.Add(((AddInList) _data).ToXml(ns));
                }
            }

            // Then the buttons
            if (((AddInList) _controls)?.ToXml(ns) != null) {
                element.Add(((AddInList) _controls).ToXml(ns));
            }

            return element;
        }

        public IDropDownExtra AddButtons(Action<IDropDownControls> items) {
            items.Invoke(_controls);
            return this;
        }

        public IDropDownExtra SizeString(int size) {
            _dropDownSize = size;
            return this;
        }

        public IDropDownExtra Supertip(string supertip) {
            this._supertip = supertip;
            return this;
        }

        public IDropDownExtra Keytip(string keytip) {
            this._keytip = keytip;
            return this;
        }

        public IDropDownExtra Screentip(string screentip) {
            this._screentip = screentip;
            return this;
        }

        public IDropDownLabel SetId(string name) {
            Id = new ElementId().SetId(name);
            return this;
        }

        public IDropDownLabel SetIdMso(string name) {
            Id = new ElementId().SetMicrosoftId(name);
            return this;
        }

        public IDropDownLabel SetIdQ(string ns, string name) {
            Id = new ElementId().SetNamespaceId(ns, name);
            return this;
        }

        public IDropDownItemLabel ImageMso(string name) {
            _imageVisible = true;
            _imageMso = name;
            return this;
        }

        public IDropDownItemLabel ImagePath(string name) {
            _imageVisible = true;
            _imagePath = name;
            return this;
        }

        public IDropDownItemLabel NoImage() {
            _imageVisible = false;
            return this;
        }

        public IDropDownItems ShowItemImage() {
            _showItemImage = true;
            return this;
        }

        public IDropDownItems HideItemImage() {
            _showItemImage = false;
            return this;
        }

        public IDropDownImage ShowLabel() {
            _showLabel = true;
            return this;
        }

        public IDropDownImage HideLabel() {
            _showLabel = false;
            return this;
        }

        public IDropDownItemImage ShowItemLabel() {
            _showItemLabel = true;
            return this;
        }

        public IDropDownItemImage HideItemLabel() {
            _showItemLabel = false;
            return this;
        }

        public IDropDownExtra DynamicItems() {
            _dynamicItemsLoading = true;
            return this;
        }

        public IDropDownExtra AddItems(Action<IItems> items) {
            _dynamicItemsLoading = false;
            items.Invoke(_data);
            return this;
        }
    }
}