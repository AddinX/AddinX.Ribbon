using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Control;
using AddinX.Ribbon.Contract.Control.DropDown;
using AddinX.Ribbon.Contract.Control.Item;
using AddinX.Ribbon.Implementation.Command;
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

        public DropDow(ICallbackRigister register) : base(register, "dropDown") {
            _data = new Items(register);
            _controls = new Controls(register);
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

        public IRibbonExtra<IDropDown> AddButtons(Action<IDropDownControls> items) {
            items.Invoke(_controls);
            return this;
        }

        public IDropDown SizeString(int size) {
            _dropDownSize = size;
            return this;
        }

        public IDropDown Supertip(string supertip) {
            _supertip = supertip;
            return this;
        }

        public IDropDown Keytip(string keytip) {
            _keytip = keytip;
            return this;
        }

        public IDropDown Screentip(string screentip) {
            _screentip = screentip;
            return this;
        }

        public IDropDown SetId(string name) {
            Id = new ElementId().SetId(name);
            return this;
        }

        public IDropDown SetIdMso(string name) {
            Id = new ElementId().SetMicrosoftId(name);
            return this;
        }

        public IDropDown SetIdQ(string ns, string name) {
            Id = new ElementId().SetNamespaceId(ns, name);
            return this;
        }

        public IDropDown ImageMso(string name) {
            _imageVisible = !string.IsNullOrEmpty(name);;
            _imageMso = name;
            return this;
        }

        public IDropDown ImagePath(string name) {
            _imageVisible = !string.IsNullOrEmpty(name);;
            _imagePath = name;
            return this;
        }

        public IDropDown NoImage() {
            _imageVisible = false;
            return this;
        }

        public IDropDown ShowItemImage() {
            _showItemImage = true;
            return this;
        }

        public IDropDown HideItemImage() {
            _showItemImage = false;
            return this;
        }

        public IDropDown ShowLabel() {
            _showLabel = true;
            return this;
        }

        public IDropDown HideLabel() {
            _showLabel = false;
            return this;
        }

        public IDropDown ShowItemLabel() {
            _showItemLabel = true;
            return this;
        }

        public IDropDown HideItemLabel() {
            _showItemLabel = false;
            return this;
        }

        public IDropDown DynamicItems() {
            _dynamicItemsLoading = true;
            return this;
        }

        public IDropDown AddItems(Action<IItems> items) {
            _dynamicItemsLoading = false;
            items.Invoke(_data);
            return this;
        }

        #region Implementation of IRibbonCallback<out IDropDown,out IDropDownCommand>

        public IDropDown Callback(Action<IDropDownCommand> builder) {
            builder(GetCommand<DropDownCommand>());
            return this;
        }

        #endregion
    }
}