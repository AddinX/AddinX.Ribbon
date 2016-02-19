using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Control.MenuUnsize;
using AddinX.Ribbon.Contract.Enums;
using AddinX.Ribbon.Implementation.Ribbon;

namespace AddinX.Ribbon.Implementation.Control
{
    public class MenuUnsize : Control, IMenuUnsize
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

        private readonly IMenuUnsizeControls controls;

        public MenuUnsize()
        {
            ElementName = "menu";
            Id = new ElementId();
            controls = new Controls();
            imageVisible = false;
        }

        protected internal IMenuUnsizeId SetLabel(string value)
        {
            Label = value;
            return this;
        }

        public IMenuUnsizeExtra Description(string description)
        {
            this.description = description;
            return this;
        }

        public IMenuUnsizeExtra Supertip(string supertip)
        {
            this.supertip = supertip;
            return this;
        }

        public IMenuUnsizeExtra Keytip(string keytip)
        {
            this.keytip = keytip;
            return this;
        }

        public IMenuUnsizeExtra Screentip(string screentip)
        {
            this.screentip = screentip;
            return this;
        }

        public IMenuUnsizeLabel SetId(string name)
        {
            Id.SetId(name);
            return this;
        }

        public IMenuUnsizeLabel SetIdMso(string name)
        {
            Id.SetMicrosoftId(name);
            return this;
        }

        public IMenuUnsizeLabel SetIdQ(string ns, string name)
        {
            Id.SetNamespaceId(ns, name);
            return this;
        }

        public IMenuUnsizeItemSize ImageMso(string name)
        {
            imageVisible = true;
            imageMso = name;
            return this;
        }

        public IMenuUnsizeItemSize ImagePath(string name)
        {
            imageVisible = true;
            imagePath = name;
            return this;
        }

        public IMenuUnsizeItemSize NoImage()
        {
            imageVisible = false;
            return this;
        }
        
        public IMenuUnsizeItems ItemNormalSize()
        {
            itemSize = ControlSize.normal;
            return this;
        }

        public IMenuUnsizeItems ItemLargeSize()
        {
            itemSize = ControlSize.large;
            return this;
        }

        public IMenuUnsizeImage ShowLabel()
        {
            showLabel = true;
            return this;
        }

        public IMenuUnsizeImage HideLabel()
        {
            showLabel = false;
            return this;
        }

        public IMenuUnsizeExtra AddItems(Action<IMenuUnsizeControls> items)
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