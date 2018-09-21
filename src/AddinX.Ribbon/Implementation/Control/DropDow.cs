using System;
using System.Linq;
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
        private readonly Items _data;
        private readonly Controls _controls;

        public DropDow(): base( "dropDown") {
            _data = new Items();
            _controls = new Controls();
            _imageVisible = false;
            _dropDownSize = 7;
        }

        protected internal override void SetRegister(ICallbackRigister register) {
            base.SetRegister(register);
            _data.SetRegister(register);
            _controls.SetRegister(register);
        }

        protected internal override XElement ToXml(XNamespace ns) {
            
            /*
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
            );*/
            var element = base.ToXml(ns);
            element.AddAttribute("sizeString", new string('W', _dropDownSize));
            element.AddAttribute("showLabel", _showLabel);
            element.AddAttribute("showItemImage", _showItemImage);
            element.AddAttribute("showItemLabel", _showItemLabel);
            element.AddImageAttribute(_imageVisible,_imagePath,_imageMso);

            element.AddAttribute("screentip", _screentip);
            element.AddAttribute("supertip", _supertip);
            element.AddAttribute("keytip", _keytip);

            if (_dynamicItemsLoading) {
                element.Add(new XAttribute("getItemCount", "GetItemCount")
                    , new XAttribute("getItemID", "GetItemId")
                    , new XAttribute("getItemImage", "GetItemImage")
                    , new XAttribute("getItemLabel", "GetItemLabel")
                    , new XAttribute("getItemScreentip", "GetItemScreentip")
                    , new XAttribute("getItemSupertip", "GetItemSupertip"));
            } else {
                // Add the Items first
                if (_data.Any()) {
                    element.Add(_data.ToXml(ns));
                }
            }

            // Then the buttons
            if (_controls.Any()) {
                element.Add(_controls.ToXml(ns));
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
            Id.SetId(name);
            return this;
        }

        public IDropDown SetIdMso(string name) {
            Id.SetMicrosoftId(name);
            return this;
        }

        public IDropDown SetIdQ(string ns, string name) {
            Id.SetNamespaceId(ns, name);
            return this;
        }

        public IDropDown ImageMso(string name) {
            _imageVisible = !string.IsNullOrEmpty(name);;
            _imageMso = name;
            return this;
        }

        public IDropDown ImagePath(string path) {
            _imageVisible = !string.IsNullOrEmpty(path);;
            _imagePath = path;
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