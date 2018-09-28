using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Control.ComboBox;
using AddinX.Ribbon.Contract.Control.Item;
using AddinX.Ribbon.Implementation.Command;

namespace AddinX.Ribbon.Implementation.Control {
    public class ComboBox : Control<IComboBox, IComboBoxCommand>, IComboBox {
        private bool _dynamicItemLoading;
        private readonly Items _data;

        public ComboBox() : base("comboBox") {
            _data = new Items();
            //NoImage();
            MaxLength(7);
            SizeString(7);
        }

        protected internal override void SetRegister(ICallbackRigister register) {
            base.SetRegister(register);
            _data.SetRegister(register);
        }

        protected override IComboBox Interface => this;


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

            if (_dynamicItemLoading) {
                element.Add(new XAttribute("getItemCount", "GetItemCount")
                    , new XAttribute("getItemID", "GetItemId")
                    , new XAttribute("getItemImage", "GetItemImage")
                    , new XAttribute("getItemLabel", "GetItemLabel")
                    , new XAttribute("getItemScreentip", "GetItemScreentip")
                    , new XAttribute("getItemSupertip", "GetItemSupertip")
                );
            } else {
                if (_data?.ToXml(ns) != null) {
                    element.Add(_data.ToXml(ns));
                }
            }

            return element;
        }

        public IComboBox Items(Action<IItems> builder) {
            _dynamicItemLoading = false;
            builder.Invoke(_data);
            return this;
        }

        public IComboBox DynamicItems() {
            _dynamicItemLoading = true;
            return this;
        }

        #region Implementation of IRibbonCallback<out IComboBox,out IComboBoxCommand>

        public void Callback(Action<IComboBoxCommand> builder) {
            builder(GetCommand<ComboBoxCommand>());
        }

        #endregion
    }
}