using System.Xml.Linq;
using AddinX.Core.Contract.Control.ToggleButtonItem;

namespace AddinX.Core.Implementation.Control
{
    public class ToggleButtonItemUi : ControlUi, IToggleButtonItemUi
    {
        private bool imageVisible;
        private string imageMso;
        private string imagePath;
        private bool showLabel;
        private string description;
        private string supertip;
        private string screentip;
        private string keytip;

        public ToggleButtonItemUi()
        {
            ElementName = "toggleButton";
            Id = new ElementId();
            imageVisible = false;
        }

        protected internal IToggleButtonItemIdUi SetLabel(string value)
        {
            Label = value;
            return this;
        }

        protected internal override XElement ToXml(XNamespace ns)
        {
            var tmpId = (ElementId)Id;
            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                , new XAttribute("label", Label)
                , imageVisible
                    ? string.IsNullOrEmpty(imageMso)
                        ? new XAttribute("image", imagePath)
                        : new XAttribute("imageMso", imageMso)
                    : new XAttribute("showImage", "false")
                , new XAttribute("showLabel", showLabel)
                , new XAttribute("getEnabled", "GetEnabled")
                , new XAttribute("getVisible", "GetVisible")
                , new XAttribute("onAction", "OnAction")
                , new XAttribute("getPressed", "GetPressed")
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

        public IToggleButtonItemLabel SetId(string name)
        {
            Id = new ElementId().SetId(name);
            return this;
        }

        public IToggleButtonItemLabel SetIdMso(string name)
        {
            Id = new ElementId().SetMicrosoftId(name);
            return this;
        }

        public IToggleButtonItemLabel SetIdQ(string ns, string name)
        {
            Id = new ElementId().SetNamespaceId(ns, name);
            return this;
        }

        public IToggleButtonItemExtra ImageMso(string name)
        {
            imageVisible = true;
            imageMso = name;
            return this;
        }

        public IToggleButtonItemExtra ImagePath(string name)
        {
            imageVisible = true;
            imagePath = name;
            return this;
        }

        public IToggleButtonItemExtra NoImage()
        {
            imageVisible = false;
            return this;
        }

        public IToggleButtonItemImage ShowLabel()
        {
            showLabel = true;
            return this;
        }

        public IToggleButtonItemImage HideLabel()
        {
            showLabel = false;
            return this;
        }
        
        public IToggleButtonItemExtra Description(string description)
        {
            this.description = description;
            return this;
        }

        public IToggleButtonItemExtra Supertip(string supertip)
        {
            this.supertip = supertip;
            return this;
        }

        public IToggleButtonItemExtra Keytip(string keytip)
        {
            this.keytip = keytip;
            return this;
        }

        public IToggleButtonItemExtra Screentip(string screentip)
        {
            this.screentip = screentip;
            return this;
        }
    }
}