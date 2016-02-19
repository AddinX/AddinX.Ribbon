using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Control.ComboBox;
using AddinX.Ribbon.Contract.Control.Item;

namespace AddinX.Ribbon.Implementation.Control
{
    public class ComboBox : Control, IComboBox
    {
        private string imageMso;
        private string imagePath;
        private bool imageVisible;
        private string supertip;
        private string screentip;
        private string keytip;
        private bool showLabel;
        private bool showItemImage;
        private int comboBoxSize;
        private int maxLength;
        private bool dynamicItemLoading;
        private readonly IItems data;

        public ComboBox()
        {
            data = new Items();
            ElementName = "comboBox";
            Id = new ElementId();
            imageVisible = false;
            maxLength = 7;
            comboBoxSize = maxLength;
        }

        protected internal IComboBoxId SetLabel(string value)
        {
            Label = value;
            return this;
        }

        public IComboBoxLabel SetId(string name)
        {
            Id = new ElementId().SetId(name);
            return this;
        }

        public IComboBoxLabel SetIdMso(string name)
        {
            Id = new ElementId().SetMicrosoftId(name);
            return this;
        }

        public IComboBoxLabel SetIdQ(string ns, string name)
        {
            Id = new ElementId().SetNamespaceId(ns, name);
            return this;
        }

        public IComboxBoxItems ImageMso(string name)
        {
            imageVisible = true;
            imageMso = name;
            return this;
        }

        public IComboxBoxItems ImagePath(string name)
        {
            imageVisible = true;
            imagePath = name;
            return this;
        }

        public IComboxBoxItems NoImage()
        {
            imageVisible = false;
            return this;
        }

        public IComboxBoxItems ShowItemImage()
        {
            showItemImage = false;
            return this;
        }

        public IComboxBoxItems HideItemImage()
        {
            showItemImage = false;
            return this;
        }

        public IComboBoxImage ShowLabel()
        {
            showLabel = true;
            return this;
        }

        public IComboBoxImage HideLabel()
        {
            showLabel = false;
            return this;
        }

        public IComboBoxExtra Supertip(string supertip)
        {
            this.supertip = supertip;
            return this;
        }

        public IComboBoxExtra Keytip(string keytip)
        {
            this.keytip = keytip;
            return this;
        }

        public IComboBoxExtra Screentip(string screentip)
        {
            this.screentip = screentip;
            return this;
        }

        public IComboBoxExtra MaxLength(int maxLength)
        {
            this.maxLength = maxLength;
            return this;
        }

        public IComboBoxExtra SizeString(int comboBoxSize)
        {
            this.comboBoxSize = comboBoxSize;
            return this;
        }

        protected internal override XElement ToXml(XNamespace ns)
        {
            var tmpId = (ElementId) Id;
            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                , new XAttribute("label", Label)
                , new XAttribute("maxLength", maxLength)
                , new XAttribute("sizeString", new string('W', comboBoxSize))
                , new XAttribute("showLabel", showLabel.ToString().ToLower())
                , new XAttribute("showItemImage", showItemImage.ToString().ToLower())
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

            if (dynamicItemLoading)
            {
                element.Add(new XAttribute("getItemCount", "GetItemCount")
                    , new XAttribute("getItemID", "GetItemId")
                    , new XAttribute("getItemImage", "GetItemImage")
                    , new XAttribute("getItemLabel", "GetItemLabel")
                    , new XAttribute("getItemScreentip", "GetItemScreentip")
                    , new XAttribute("getItemSupertip", "GetItemSupertip")
                    );
            }
            else
            {

                if (((AddInList)data)?.ToXml(ns)!=null)
                {
                    element.Add(((AddInList)data).ToXml(ns));
                }
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

            return element;
        }

        public IComboBoxExtra AddItems(Action<IItems> items)
        {
            dynamicItemLoading = false;
            items.Invoke(data);
            return this;
        }

        public IComboBoxExtra DynamicItems()
        {
            dynamicItemLoading = true;
            return this;
        }
    }
}