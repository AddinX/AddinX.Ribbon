using System;
using System.Linq;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Control.MenuUnsize;
using AddinX.Ribbon.Contract.Enums;
using AddinX.Ribbon.Implementation.Ribbon;

namespace AddinX.Ribbon.Implementation.Control {
    public class MenuUnsize : ControlContainer<IMenuUnsize>, IMenuUnsize {

        private bool _showLabel = true;
        private ControlSize _itemSize = ControlSize.normal;

        public MenuUnsize(): base( "menu") {
            NoImage();
        }


        protected override IMenuUnsize Interface => this;
        

        public IMenuUnsize AddItems(Action<IMenuUnsizeControls> items) {
            items.Invoke(Controls);
            return this;
        }

        /*
        protected internal override XElement ToXml(XNamespace ns) {
            var tmpId = (ElementId) Id;

            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                , new XAttribute("label", Label)
                , new XAttribute("showLabel", _showLabel)
                , new XAttribute("itemSize", _itemSize.ToString())
                , _imageVisible
                    ? string.IsNullOrEmpty(_imageMso)
                        ? new XAttribute("image", _imagePath)
                        : new XAttribute("imageMso", _imageMso)
                    : new XAttribute("showImage", "false")
                , new XAttribute("getEnabled", "GetEnabled")
                , new XAttribute("getVisible", "GetVisible")
                , new XAttribute("tag", tmpId.Value)
            );
            var element = base.ToXml(ns);
           

            if (Controls.Any()) {
                element.Add(Controls.ToXml(ns));
            }
            return element;
        }*/
    }
}