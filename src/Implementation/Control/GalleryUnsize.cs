using System;
using System.Xml.Linq;
using AddinX.Core.Contract.Control.GalleryUnsize;
using AddinX.Core.Contract.Control.Item;
using AddinX.Core.Implementation.Ribbon;

namespace AddinX.Core.Implementation.Control
{
    public class GalleryUnsize : Control, IGalleryUnsize
    {
        private string imageMso;
        private string imagePath;
        private bool imageVisible;
        private string supertip;
        private string screentip;
        private string keytip;
        private bool showLabel = true;
        private bool showItemImage = true;
        private int gallerySize;
        private bool showItemLabel = true;
        private bool dynamicItemsLoading;
        private readonly IItems data;
        private int itemHeight;
        private int itemWidth;
        private int rows;
        private int cols;
        private readonly IGalleryUnsizeControls controls;

        public GalleryUnsize()
        {
            data = new Items();
            ElementName = "gallery";
            Id = new ElementId();
            controls = new Controls();
            imageVisible = false;
            gallerySize = 7;
            itemHeight = 0;
            itemWidth = 0;
            rows = -1;
            cols = -1;
        }

        protected internal IGalleryUnsizeId SetLabel(string value)
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
                , new XAttribute("sizeString", new string('W', gallerySize))
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

            if (itemHeight > 0)
            {
                element.Add(new XAttribute("itemHeight", itemHeight));
            }

            if (itemWidth > 0)
            {
                element.Add(new XAttribute("itemWidth", itemWidth));
            }

            if (rows >= 0)
            {
                element.Add(new XAttribute("rows", rows));
            }

            if (cols >= 0)
            {
                element.Add(new XAttribute("columns", cols));
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
                // Add the Items first
                if (((AddInList)data)?.ToXml(ns) != null)
                {
                    element.Add(((AddInList)data).ToXml(ns));
                }
            }
            // Then the buttons
            if (((AddInList)controls)?.ToXml(ns) != null)
            {
                element.Add(((AddInList)controls).ToXml(ns));
            }

            return element;
        }

        public IGalleryUnsizeExtra SizeString(int size)
        {
            gallerySize = size;
            return this;
        }

        public IGalleryUnsizeExtra ItemHeight(int height)
        {
            itemHeight = height;
            return this;
        }

        public IGalleryUnsizeExtra ItemWidth(int width)
        {
            itemWidth = width;
            return this;
        }

        public IGalleryUnsizeExtra NumberRows(int rows)
        {
            this.rows = rows;
            return this;
        }

        public IGalleryUnsizeExtra NumberColumns(int cols)
        {
            this.cols = cols;
            return this;
        }

        public IGalleryUnsizeExtra Supertip(string supertip)
        {
            this.supertip = supertip;
            return this;
        }

        public IGalleryUnsizeExtra Keytip(string keytip)
        {
            this.keytip = keytip;
            return this;
        }

        public IGalleryUnsizeExtra Screentip(string screentip)
        {
            this.screentip = screentip;
            return this;
        }

        public IGalleryUnsizeLabel SetId(string name)
        {
            Id.SetId(name);
            return this;
        }

        public IGalleryUnsizeLabel SetIdMso(string name)
        {
            Id.SetMicrosoftId(name);
            return this;
        }

        public IGalleryUnsizeLabel SetIdQ(string ns, string name)
        {
            Id.SetNamespaceId(ns, name);
            return this;
        }

        public IGalleryUnsizeItemLabel ImageMso(string name)
        {
            imageMso = name;
            return this;
        }

        public IGalleryUnsizeItemLabel ImagePath(string name)
        {
            imageVisible = true;
            imagePath = name;
            return this;
        }

        public IGalleryUnsizeItemLabel NoImage()
        {
            imageVisible = true;
            imageVisible = false;
            return this;
        }

        public IGalleryUnsizeItems ShowItemImage()
        {
            showItemImage = true;
            return this;
        }

        public IGalleryUnsizeItems HideItemImage()
        {
            showItemImage = false;
            return this;
        }

        public IGalleryUnsizeItemImage ShowItemLabel()
        {
            showItemLabel = true;
            return this;
        }

        public IGalleryUnsizeItemImage HideItemLabel()
        {
            showItemLabel = false;
            return this;
        }

        public IGalleryUnsizeImage ShowLabel()
        {
            showLabel = true;
            return this;
        }

        public IGalleryUnsizeImage HideLabel()
        {
            showLabel = false;
            return this;
        }

        public IGalleryUnsizeExtra DynamicItems()
        {
            dynamicItemsLoading = true;
            return this;
        }
        
        public IGalleryUnsizeExtra AddItems(Action<IItems> items)
        {
            dynamicItemsLoading = false;
            items.Invoke(data);
            return this;
        }

        public IGalleryUnsizeExtra AddButtons(Action<IGalleryUnsizeControls> items)
        {
            items.Invoke(controls);
            return this;
        }
    }
}