using System.Xml.Linq;
using AddinX.Core.Contract.Control.Item;

namespace AddinX.Core.Implementation.Control
{
    public class ItemUi : ControlUi, IItemUi
    {
        private string imageMso;
        private string imagePath;
        private bool imageVisible;
        private string supertip;
        private string screentip;

        public ItemUi()
        {
            ElementName = "item";
            Id = new ElementId();
            imageVisible = false;
        }

        protected internal IItemUiId SetLabel(string label)
        {
            Label = label;
            return this;
        }

        protected internal override XElement ToXml(XNamespace ns)
        {
            var tmpId = (ElementId) Id;

            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                , new XAttribute("label", Label)
                );

            if (imageVisible)
            {
                element.Add(string.IsNullOrEmpty(imageMso)
                    ? new XAttribute("image", imagePath)
                    : new XAttribute("imageMso", imageMso));
            }

            if (!string.IsNullOrEmpty(screentip))
            {
                element.Add(new XAttribute("screentip", screentip));
            }

            if (!string.IsNullOrEmpty(supertip))
            {
                element.Add(new XAttribute("supertip", supertip));
            }

            return element;
        }

        public IItemImage SetId(string name)
        {
            Id.SetId(name);
            return this;
        }

        public IItemExtra ImageMso(string name)
        {
            imageVisible = true;
            imageMso = name;
            return this;
        }

        public IItemExtra ImagePath(string name)
        {
            imageVisible = true;
            imagePath = name;
            return this;
        }

        public IItemExtra NoImage()
        {
            imageVisible = false;
            return this;
        }

        public IItemExtra Supertip(string supertip)
        {
            this.supertip = supertip;
            return this;
        }

        public IItemExtra Screentip(string screentip)
        {
            this.screentip = screentip;
            return this;
        }
    }
}