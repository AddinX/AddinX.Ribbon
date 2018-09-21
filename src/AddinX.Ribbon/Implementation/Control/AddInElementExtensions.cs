using AddinX.Ribbon.Contract.Enums;

namespace AddinX.Ribbon.Implementation.Control {
    internal static class AddInElementExtensions{
        private const string tag_size = "size";
        private const string tag_getSize = "getSize";
        private const string tag_onAction = "onAction";
        private const string tag_enabled = "enabled";
        private const string tag_getEnabled = "getEnabled";
        private const string tag_description = "description";
        private const string tag_getDescription = "getDescription";
        private const string tag_image = "image";
        private const string tag_imageMso = "imageMso";
        private const string tag_getImage = "getImage";
        private const string tag_id = "id";
        private const string tag_idQ = "idQ";
        private const string tag_tag = "tag";
        private const string tag_idMso = "idMso";
        private const string tag_screentip = "screentip";
        private const string tag_getScreentip = "getScreentip";
        private const string tag_supertip = "supertip";
        private const string tag_getSupertip = "getSupertip";
        private const string tag_label = "label";
        private const string tag_getLabel = "getLabel";
        private const string tag_insertAfterMso = "insertAfterMso";
        private const string tag_insertBeforeMso = "insertBeforeMso";
        private const string tag_insertAfterQ = "insertAfterQ";
        private const string tag_insertBeforeQ = "insertBeforeQ";
        private const string tag_visible = "visible";
        private const string tag_getVisible = "getVisible";
        private const string tag_keytip = "keytip";
        private const string tag_getKeytip = "getKeytip";
        private const string tag_showLabel = "showLabel";
        private const string tag_getShowLabel = "getShowLabel";
        private const string tag_showImage = "showImage";
        private const string tag_getShowImage = "getShowImage";


        public static void ImageMsoImpl(this AddInElement element,string name) {
            //_imageVisible = !string.IsNullOrEmpty(name);
            //_imageMso = name;
            element.SetAttribute(tag_showImage, true);
            element.SetAttribute(tag_imageMso, name);
        }

        public static void  ImagePathImpl(this AddInElement element,string path) {
            element.SetAttribute(tag_showImage, true);
            element.SetAttribute(tag_image, path);
            //_imageVisible = !string.IsNullOrEmpty(path);;
            //_imagePath = path;
        }

        public static void  NoImageImpl(this AddInElement element) {
            element.SetAttribute(tag_showImage, false);
            element.RemoveAttribute(tag_image);
            element.RemoveAttribute(tag_imageMso);
        }

        public static void DescriptionImpl(this AddInElement element,string description) {
            element.SetAttribute(tag_description, description);
            //_description = description;
        }

        public static void KeytipImpl(this AddInElement element,string keytip) {
            element.SetAttribute(tag_keytip, keytip);
            //_keytip = keytip;
        }

        public static void SupertipImpl(this AddInElement element,string supertip) {
            element.SetAttribute(tag_supertip, supertip);
            //_supertip = supertip;
        }

        public static void ScreentipImpl(this AddInElement element,string screentip) {
            element.SetAttribute(tag_screentip, screentip);
            //_screentip = screentip;
        }

        public static void LargeSizeImpl(this AddInElement element) {
            element.SetAttribute(tag_size, ControlSize.large);
            //_size = ControlSize.large;
        }

        public static void NormalSizeImpl(this AddInElement element) {
            element.SetAttribute(tag_size, ControlSize.normal);
            //_size = ControlSize.normal;
        }

        public static void ShowLabelImpl(this AddInElement element) {
            element.SetAttribute(tag_showLabel, true);
            //_showLabel = true;
        }

        public static void HideLabelImpl(this AddInElement element) {
            element.SetAttribute(tag_showLabel, false);
            //_showLabel = false;
        }
    }
}