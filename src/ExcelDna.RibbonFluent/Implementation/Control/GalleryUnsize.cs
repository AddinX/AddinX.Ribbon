using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Control.GalleryUnsize;
using AddinX.Ribbon.Contract.Control.Item;
using AddinX.Ribbon.Implementation.Command;
using AddinX.Ribbon.Implementation.Ribbon;

namespace AddinX.Ribbon.Implementation.Control {
    public class GalleryUnsize : Control<IGalleryUnsize, IGalleryCommand>, IGalleryUnsize {
        private readonly Items _data;
        private readonly Controls _controls;

        public GalleryUnsize() : base("gallery") {
            _data = new Items();
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
                , new XAttribute("getEnabled", "GetEnabled")
                , new XAttribute("getVisible", "GetVisible")
                , new XAttribute("onAction", "OnActionDropDown")
                , new XAttribute("getSelectedItemIndex", "GetSelectedItemIndex")
                , new XAttribute("tag", tmpId.Value)
            );*/

            var element = base.ToXml(ns);

            if (!HasCallback) {
                foreach (var item in _data.ToXml(ns)) {
                    element.Add(item);
                }
            }

            // Then the buttons
            foreach (var item in _controls.ToXml(ns)) {
                element.Add(item);
            }
            return element;
        }

        protected override IGalleryUnsize Interface => this;

        public IGalleryUnsize Items(Action<IItems> builder) {
            builder.Invoke(_data);
            return this;
        }

        public IGalleryUnsize Buttons(Action<IGalleryUnsizeControls> items) {
            items.Invoke(_controls);
            return this;
        }

        #region Implementation of IRibbonCallback<IGalleryCommand>

        public void Callback(Action<IGalleryCommand> builder) {
            builder?.Invoke(base.GetCommand<GalleryCommand>());
        }

        #endregion
    }
}