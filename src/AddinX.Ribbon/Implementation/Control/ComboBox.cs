using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Control.ComboBox;
using AddinX.Ribbon.Contract.Control.Item;
using AddinX.Ribbon.Implementation.Command;

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

        public ComboBox(ICallbackRigister register) : base(register, "comboBox") {
            _data = new Items(register);
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
            _imageVisible = !string.IsNullOrEmpty(name);;
            _imageMso = name;
            return this;
        }

        public IComboBox ImagePath(string name) {
            _imageVisible = !string.IsNullOrEmpty(name);;
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
            _supertip = supertip;
            return this;
        }

        public IComboBox Keytip(string keytip) {
            _keytip = keytip;
            return this;
        }

        public IComboBox Screentip(string screentip) {
            _screentip = screentip;
            return this;
        }

        public IComboBox MaxLength(int maxLength) {
            _maxLength = maxLength;
            return this;
        }

        public IComboBox SizeString(int comboBoxSize) {
            _comboBoxSize = comboBoxSize;
            return this;
        }

        protected internal override XElement ToXml(XNamespace ns) {
            /*var tmpId = (ElementId) Id;
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
            );*/

            var element = base.ToXml(ns);
            element.AddImageAttribute(_imageVisible, _imagePath, _imageMso);
            element.AddAttribute("maxLength", _maxLength);
            element.AddAttribute("sizeString", new string('W', _comboBoxSize));
            element.AddAttribute("showLabel", _showLabel);
            element.AddAttribute("showItemImage", _showItemImage);

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

            element.AddAttribute("screentip", _screentip);
            element.AddAttribute("supertip", _supertip);
            element.AddAttribute("keytip", _keytip);

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

        #region Implementation of IRibbonCallback<out IComboBox,out IComboBoxCommand>

        public IComboBox Callback(Action<IComboBoxCommand> builder) {
            builder(GetCommand<ComboBoxCommand>());
            return this;
        }

        #endregion
    }
}