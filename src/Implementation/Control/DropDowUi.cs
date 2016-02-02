using System;
using System.Xml.Linq;
using AddinX.Core.Contract.Control.DropDown;
using AddinX.Core.Contract.Control.Item;

namespace AddinX.Core.Implementation.Control
{
    public class DropDowUi : ControlUi, IDropDownUi
    {
        private string imageMso;
        private string imagePath;
        private bool imageVisible;
        private string supertip;
        private string screentip;
        private string keytip;
        private bool showLabel = true;
        private bool showItemImage = true;
        private int dropDownSize;
        private bool showItemLabel = true;
        private bool dynamicItemsLoading;
        private readonly IItemsUi data;

        public DropDowUi()
        {
            data = new ItemsUi();
            ElementName = "dropDown";
            Id = new ElementId();
            imageVisible = false;
            dropDownSize = 7;
        }

        protected internal IDropDownIdUi SetLabel(string value)
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
                , new XAttribute("sizeString", new string('W', dropDownSize))
                , new XAttribute("showLabel", showLabel.ToString().ToLower())
                , new XAttribute("showItemImage", showItemImage.ToString().ToLower())
                , new XAttribute("showItemLabel", showItemLabel.ToString().ToLower())
                , imageVisible
                    ? string.IsNullOrEmpty(imageMso)
                        ? new XAttribute("image", imagePath)
                        : new XAttribute("imageMso", imageMso)
                    : new XAttribute("showImage", "false")
                , new XAttribute("getEnabled", "GetEnabled")
                , new XAttribute("getVisible", "GetVisible")
                , new XAttribute("onAction", "OnActionDropDown")
                , new XAttribute("getSelectedItemIndex", "GetSelectedItemIndex")
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

            if (dynamicItemsLoading)
            {
                element.Add(new XAttribute("getItemCount", "GetItemCount")
                    , new XAttribute("getItemID", "GetItemId")
                    , new XAttribute("getItemImage", "GetItemImage")
                    , new XAttribute("getItemLabel", "GetItemLabel")
                    , new XAttribute("getItemScreentip", "GetItemScreentip")
                    , new XAttribute("getItemSupertip", "GetItemSupertip"));
            }
            else
            {
                if (((AddInList)data).ToXml(ns) != null)
                {
                    element.Add(((AddInList)data).ToXml(ns));
                }
            }

            return element;
        }

        public IDropDownExtra SizeString(int size)
        {
            dropDownSize = size;
            return this;
        }

        public IDropDownExtra Supertip(string supertip)
        {
            this.supertip = supertip;
            return this;
        }

        public IDropDownExtra Keytip(string keytip)
        {
            this.keytip = keytip;
            return this;
        }

        public IDropDownExtra Screentip(string screentip)
        {
            this.screentip = screentip;
            return this;
        }

        public IDropDownLabel SetId(string name)
        {
            Id = new ElementId().SetId(name);
            return this;
        }

        public IDropDownLabel SetIdMso(string name)
        {
            Id = new ElementId().SetMicrosoftId(name);
            return this;
        }

        public IDropDownLabel SetIdQ(string ns, string name)
        {
            Id = new ElementId().SetNamespaceId(ns, name);
            return this;
        }

        public IDropDownItemLabel ImageMso(string name)
        {
            imageVisible = true;
            imageMso = name;
            return this;
        }

        public IDropDownItemLabel ImagePath(string name)
        {
            imageVisible = true;
            imagePath = name;
            return this;
        }

        public IDropDownItemLabel NoImage()
        {
            imageVisible = false;
            return this;
        }

        public IDropDownItems ShowItemImage()
        {
            showItemImage = true;
            return this;
        }

        public IDropDownItems HideItemImage()
        {
            showItemImage = false;
            return this;
        }

        public IDropDownImage ShowLabel()
        {
            showLabel = true;
            return this;
        }

        public IDropDownImage HideLabel()
        {
            showLabel = false;
            return this;
        }

        public IDropDownItemImage ShowItemLabel()
        {
            showItemLabel = true;
            return this;
        }

        public IDropDownItemImage HideItemLabel()
        {
            showItemLabel = false;
            return this;
        }

        public IDropDownExtra DynamicItems()
        {
            dynamicItemsLoading = true;
            return this;
        }

        public IDropDownExtra AddItems(Action<IItemsUi> items)
        {
            dynamicItemsLoading = false;
            items.Invoke(data);
            return this;
        }
    }
}