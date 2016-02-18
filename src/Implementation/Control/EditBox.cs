using System.Xml.Linq;
using AddinX.Core.Contract.Control.EditBox;

namespace AddinX.Core.Implementation.Control
{
    public class EditBox : Control, IEditBox
    {
        private bool imageVisible;
        private string imageMso;
        private string imagePath;
        private string supertip;
        private string screentip;
        private string keytip;
        private int maxlength;
        private int editBoxSize;

        public EditBox()
        {
            ElementName = "editBox";
            Id = new ElementId();
            imageVisible = false;
            maxlength = 15;
            editBoxSize = maxlength;
        }

        protected internal override XElement ToXml(XNamespace ns)
        {
            var tmpId = (ElementId) Id;
            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                , new XAttribute("label", Label)
                , new XAttribute("maxLength", maxlength)
                , new XAttribute("sizeString", new string('W', editBoxSize))
                , imageVisible
                    ? string.IsNullOrEmpty(imageMso)
                        ? new XAttribute("image", imagePath)
                        : new XAttribute("imageMso", imageMso)
                    : new XAttribute("showImage", "false")
                , new XAttribute("getEnabled", "GetEnabled")
                , new XAttribute("getVisible", "GetVisible")
                , new XAttribute("onChange", "OnChange")
                , new XAttribute("getText", "GetText")
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

            return element;
        }

        protected internal IEditBoxId SetLabel(string value)
        {
            Label = value;
            return this;
        }

        public IEditBoxImage SetId(string name)
        {
            Id = new ElementId().SetId(name);
            return this;
        }

        public IEditBoxImage SetIdMso(string name)
        {
            Id = new ElementId().SetMicrosoftId(name);
            return this;
        }

        public IEditBoxImage SetIdQ(string ns, string name)
        {
            Id = new ElementId().SetNamespaceId(ns, name);
            return this;
        }

        public IEditBoxExtra ImageMso(string name)
        {
            imageVisible = true;
            imageMso = name;
            return this;
        }

        public IEditBoxExtra ImagePath(string name)
        {
            imageVisible = true;
            imagePath = name;
            return this;
        }

        public IEditBoxExtra NoImage()
        {
            imageVisible = false;
            return this;
        }

        public IEditBoxExtra MaxLength(int maxLength)
        {
            this.maxlength = maxLength;
            return this;
        }

        public IEditBoxExtra SizeString(int editBoxSize)
        {
            this.editBoxSize = editBoxSize;
            return this;
        }

        public IEditBoxExtra Supertip(string supertip)
        {
            this.supertip = supertip;
            return this;
        }

        public IEditBoxExtra Keytip(string keytip)
        {
            this.keytip = keytip;
            return this;
        }

        public IEditBoxExtra Screentip(string screentip)
        {
            this.screentip = screentip;
            return this;
        }
    }
}