using System;
using System.Xml.Linq;
using AddinX.Core.Contract.Control.Menu;
using AddinX.Core.Contract.Enums;
using AddinX.Core.Implementation.Ribbon;

namespace AddinX.Core.Implementation.Control
{
    public class MenuUi : ControlUi, IMenuUi
    {
        private string imageMso;
        private string imagePath;
        private bool imageVisible;
        private string supertip;
        private string screentip;
        private string keytip;
        private string description;
        private bool showLabel = true;
        private ControlSize itemSize = ControlSize.normal;
        private ControlSize size = ControlSize.normal;

        private readonly IMenuControlsUi controls;

        public MenuUi()
        {
            ElementName = "menu";
            Id = new ElementId();
            controls = new ControlsUi();
            imageVisible = false;
        }

        protected internal IMenuIdUi SetLabel(string value)
        {
            Label = value;
            return this;
        }

        public IMenuExtra Description(string description)
        {
            this.description = description;
            return this;
        }

        public IMenuExtra Supertip(string supertip)
        {
            this.supertip = supertip;
            return this;
        }

        public IMenuExtra Keytip(string keytip)
        {
            this.keytip = keytip;
            return this;
        }

        public IMenuExtra Screentip(string screentip)
        {
            this.screentip = screentip;
            return this;
        }

        public IMenuLabel SetId(string name)
        {
            Id.SetId(name);
            return this;
        }

        public IMenuLabel SetIdMso(string name)
        {
            Id.SetMicrosoftId(name);
            return this;
        }

        public IMenuLabel SetIdQ(string ns, string name)
        {
            Id.SetNamespaceId(ns, name);
            return this;
        }

        public IMenuSize ImageMso(string name)
        {
            imageVisible = true;
            imageMso = name;
            return this;
        }

        public IMenuSize ImagePath(string name)
        {
            imageVisible = true;
            imagePath = name;
            return this;
        }

        public IMenuSize NoImage()
        {
            imageVisible = false;
            return this;
        }

        public IMenuItemSize NormalSize()
        {
            size = ControlSize.normal;
            return this;
        }

        public IMenuItemSize LargeSize()
        {
            size = ControlSize.large;
            return this;
        }

        public IMenuItems ItemNormalSize()
        {
            itemSize = ControlSize.normal;
            return this;
        }

        public IMenuItems ItemLargeSize()
        {
            itemSize = ControlSize.large;
            return this;
        }

        public IMenuImage ShowLabel()
        {
            showLabel = true;
            return this;
        }

        public IMenuImage HideLabel()
        {
            showLabel = false;
            return this;
        }

        public IMenuExtra AddItems(Action<IMenuControlsUi> items)
        {
            items.Invoke(controls);
            return this;
        }

        protected internal override XElement ToXml(XNamespace ns)
        {
            var tmpId = (ElementId)Id;

            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                , new XAttribute("label", Label)
                , new XAttribute("size", size.ToString())
                , new XAttribute("showLabel", showLabel.ToString().ToLower())
                , new XAttribute("itemSize", itemSize.ToString())
                , imageVisible
                    ? string.IsNullOrEmpty(imageMso)
                        ? new XAttribute("image", imagePath)
                        : new XAttribute("imageMso", imageMso)
                    : new XAttribute("showImage", "false")
                , new XAttribute("getEnabled", "GetEnabled")
                , new XAttribute("getVisible", "GetVisible")
                , new XAttribute("tag", tmpId.Value)
                );

            if (!string.IsNullOrEmpty(screentip))
            {
                element.Add(new XAttribute("screentip", screentip));
            }

            if (!string.IsNullOrEmpty(supertip))
            {
                element.Add(new XAttribute("supertip", supertip));
            }

            if (!string.IsNullOrEmpty(keytip))
            {
                element.Add(new XAttribute("keytip", keytip));
            }

            if (!string.IsNullOrEmpty(description))
            {
                element.Add(new XAttribute("description", description));
            }

            if (((AddInList)controls)?.ToXml(ns) != null)
            {
                element.Add(((AddInList)controls).ToXml(ns));
            }

            return element;
        }
    }
}