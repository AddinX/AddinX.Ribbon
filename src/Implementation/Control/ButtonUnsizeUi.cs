using System.Xml.Linq;
using AddinX.Core.Contract.Control.ButtonUnsize;

namespace AddinX.Core.Implementation.Control
{
    public class ButtonUnsizeUi : ControlUi, IButtonUnsizeUi
    {
        private bool imageVisible;
        private string imageMso;
        private string imagePath;
        private string description;
        private string supertip;
        private string screentip;
        private string keytip;
        private bool showLabel;

        public ButtonUnsizeUi()
        {
            ElementName = "button";
            Id = new ElementId();
            imageVisible = false;
        }

        protected internal IButtonUnsizeIdUi SetLabel(string value)
        {
            Label = value;
            return this;
        }

        protected internal override XElement ToXml(XNamespace ns)
        {
            var tmpId = (ElementId)Id;
            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                , new XAttribute("showLabel", showLabel.ToString().ToLower())
                , imageVisible
                    ? string.IsNullOrEmpty(imageMso)
                        ? new XAttribute("image", imagePath)
                        : new XAttribute("imageMso", imageMso)
                    : new XAttribute("showImage", "false")
                , new XAttribute("getEnabled", "GetEnabled")
                , new XAttribute("getVisible", "GetVisible")
                , new XAttribute("onAction", "OnAction")
                , new XAttribute("tag", tmpId.Value)
                );

            if (!string.IsNullOrEmpty(Label))
            {
                element.Add(new XAttribute("label", Label));
            }

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

        public IButtonUnsizeImage SetIdMso(string name)
        {
            Id = new ElementId().SetMicrosoftId(name);
            return this;
        }

        public IButtonUnsizeImage SetIdQ(string ns, string name)
        {
            Id = new ElementId().SetNamespaceId(ns, name);
            return this;
        }

        public IButtonUnsizeImage SetId(string name)
        {
            Id = new ElementId().SetId(name);
            return this;
        }


        public IButtonUnsizeLabel ImageMso(string name)
        {
            imageVisible = true;
            imageMso = name;
            return this;
        }

        public IButtonUnsizeLabel ImagePath(string name)
        {
            imageVisible = true;
            imagePath = name;
            return this;
        }

        public IButtonUnsizeLabel NoImage()
        {
            imageVisible = false;
            return this;
        }

        public IButtonUnsizeExtra Description(string description)
        {
            this.description = description;
            return this;
        }

        public IButtonUnsizeExtra Keytip(string keytip)
        {
            this.keytip = keytip;
            return this;
        }

        public IButtonUnsizeExtra Supertip(string supertip)
        {
            this.supertip = supertip;
            return this;
        }

        public IButtonUnsizeExtra Screentip(string screentip)
        {
            this.screentip = screentip;
            return this;
        }
        
        public IButtonUnsizeExtra ShowLabel()
        {
            showLabel = true;
            return this;
        }

        public IButtonUnsizeExtra HideLabel()
        {
            showLabel = false;
            return this;
        }
    }
}