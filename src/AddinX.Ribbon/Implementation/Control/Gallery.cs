using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Control.Gallery;
using AddinX.Ribbon.Contract.Control.Item;
using AddinX.Ribbon.Implementation.Command;
using AddinX.Ribbon.Implementation.Ribbon;

namespace AddinX.Ribbon.Implementation.Control {
    public class Gallery : Control<IGallery, IGalleryCommand>, IGallery {
        private bool _dynamicItemsLoading;
        private readonly Items _data;
        private readonly Controls _controls;

        public Gallery() : base("gallery") {
            _data = new Items();
            NormalSize();
            _controls = new Controls();
            NoImage();
            SizeString(7);
        }

        protected internal override void SetRegister(ICallbackRigister register) {
            base.SetRegister(register);
            _data.SetRegister(register);
            _controls.SetRegister(register);
        }

        protected internal override XElement ToXml(XNamespace ns) {
            /*var tmpId = (ElementId) Id;
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
            );*/

            var element = base.ToXml(ns);
            if (_dynamicItemsLoading) {
                element.Add(new XAttribute("getItemCount", "GetItemCount")
                    , new XAttribute("getItemID", "GetItemId")
                    , new XAttribute("getItemImage", "GetItemImage")
                    , new XAttribute("getItemLabel", "GetItemLabel")
                    , new XAttribute("getItemScreentip", "GetItemScreentip")
                    , new XAttribute("getItemSupertip", "GetItemSupertip"));
            } else {
                // Add the Items first
                element.AddControls(_data, ns);
            }

            // Then the buttons
            element.AddControls(_controls, ns);

            return element;
        }

        protected override IGallery Interface => this;


        public IGallery DynamicItems() {
            _dynamicItemsLoading = true;
            return this;
        }


        public IGallery Items(Action<IItems> builder) {
            _dynamicItemsLoading = false;
            builder.Invoke(_data);
            return this;
        }

        public IGallery Buttons(Action<IGalleryControls> items) {
            items.Invoke(_controls);
            return this;
        }

        #region Implementation of IRibbonCallback<out IGallery,out IGalleryCommand>

        public void Callback(Action<IGalleryCommand> builder) {
            builder(GetCommand<GalleryCommand>());
        }

        #endregion
    }
}