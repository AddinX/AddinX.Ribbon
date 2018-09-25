using System;
using System.Linq;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Control.Menu;
using AddinX.Ribbon.Contract.Enums;
using AddinX.Ribbon.Implementation.Command;
using AddinX.Ribbon.Implementation.Ribbon;

namespace AddinX.Ribbon.Implementation.Control {
    public class Menu : ControlContainer<IMenu>, IMenu {

        public Menu(): base( "menu") {
            NoImage();
        }

        public IMenu AddItems(Action<IMenuControls> items) {
            items.Invoke(Controls);
            return this;
        }
        /*
        protected internal override XElement ToXml(XNamespace ns) {
            var tmpId = (ElementId) Id;
            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                , new XAttribute("label", Label)
                , new XAttribute("size", _size.ToString())
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
        }
        */

        #region Implementation of IRibbonCallback<out IMenu,out IMenuCommand>

        public void Callback(Action<IMenuCommand> builder) {
            builder(GetCommand<MenuCommand>());
        }

        #endregion

        #region Overrides of Control<IMenu>

        protected override IMenu Interface => this;

        #endregion

        #region Implementation of IRibbonCallback<out IMenu,IMenuCommand>

        public void Callback(IMenuCommand command) {
            base.SetCommand(command);
        }

        #endregion
    }
}