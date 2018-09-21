using System.Xml.Linq;
using AddinX.Ribbon.Contract.Control.Button;
using AddinX.Ribbon.Contract.Enums;

namespace AddinX.Ribbon.Implementation.Control
{
    public class Button : Control, IButton
    {
        private bool imageVisible;
        private string imageMso;
        private string imagePath;
        private string description;
        private string supertip;
        private ControlSize size;
        private string screentip;
        private string keytip;
        private bool showLabel;

        public Button()
        {
            ElementName = "button";
            Id = new ElementId();
            size = ControlSize.normal;
            imageVisible = false;
            showLabel = false;
        }

        protected internal IButtonId SetLabel(string value)
        {
            Label = value;
            return this;
        }

        protected internal override XElement ToXml(XNamespace ns)
        {
            var tmpId = (ElementId) Id;
            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                , new XAttribute("label", Label)
                , new XAttribute("showLabel", showLabel)
                , imageVisible
                    ? string.IsNullOrEmpty(imageMso)
                        ? new XAttribute("image", imagePath)
                        : new XAttribute("imageMso", imageMso)
                    : new XAttribute("showImage", "false")
                , new XAttribute("size", size.ToString())
                , new XAttribute("getEnabled", "GetEnabled")
                , new XAttribute("getVisible", "GetVisible")
                , new XAttribute("onAction", "OnAction")
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

            return element;
        }

        public IButtonSize SetIdMso(string name)
        {
            Id = new ElementId().SetMicrosoftId(name);
            return this;
        }

        public IButtonSize SetIdQ(string ns, string name)
        {
            Id = new ElementId().SetNamespaceId(ns, name);
            return this;
        }

        public IButtonSize SetId(string name)
        {
            Id = new ElementId().SetId(name);
            return this;
        }


        public IButtonLabel ImageMso(string name){
            imageVisible = true;
            imageMso = name;
            return this;
        }

        public IButtonLabel ImagePath(string name){
            imageVisible = true;
            imagePath = name;
            return this;
        }

        public IButtonLabel NoImage()
        {
            imageVisible = false;
            return this;
        }

        public IButtonExtra Description(string description){
            this.description = description;
            return this;
        }

        public IButtonExtra Keytip(string keytip)
        {
            this.keytip = keytip;
            return this;
        }

        public IButtonExtra Supertip(string supertip)
        {
            this.supertip = supertip;
            return this;
        }

        public IButtonExtra Screentip(string screentip)
        {
            this.screentip = screentip;
            return this;
        }

        public IButtonImage LargeSize()
        {
            size = ControlSize.large;
            return this;
        }

        public IButtonImage NormalSize()
        {
            size = ControlSize.normal;
            return this;
        }

        public IButtonExtra ShowLabel()
        {
            showLabel = true;
            return this;
        }

        public IButtonExtra HideLabel()
        {
            showLabel = false;
            return this;
        }
    }
}