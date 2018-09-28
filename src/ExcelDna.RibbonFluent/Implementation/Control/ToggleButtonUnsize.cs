using AddinX.Ribbon.Contract.Control.ToggleButtonUnsize;

namespace AddinX.Ribbon.Implementation.Control {
    public class ToggleButtonUnsize : Control<IToggleButtonUnsize>, IToggleButtonUnsize {
        public ToggleButtonUnsize() : base("toggleButton") {
            NoImage();
        }

        /*
        protected internal override XElement ToXml(XNamespace ns) {
            var tmpId = (ElementId) Id;
            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                , new XAttribute("label", Label)
                , _imageVisible
                    ? string.IsNullOrEmpty(_imageMso)
                        ? new XAttribute("image", _imagePath)
                        : new XAttribute("imageMso", _imageMso)
                    : new XAttribute("showImage", "false")
                , new XAttribute("showLabel", _showLabel)
                , new XAttribute("getEnabled", "GetEnabled")
                , new XAttribute("getVisible", "GetVisible")
                , new XAttribute("onAction", "OnActionPressed")
                , new XAttribute("getPressed", "GetPressed")
                , new XAttribute("tag", tmpId.Value)
            );

            if (!string.IsNullOrEmpty(_screentip)) {
                element.Add(new XAttribute("screentip", _screentip));
            }

            if (!string.IsNullOrEmpty(_supertip)) {
                element.Add(new XAttribute("supertip", _supertip));
            }

            if (!string.IsNullOrEmpty(_keytip)) {
                element.Add(new XAttribute("keytip", _keytip));
            }

            if (!string.IsNullOrEmpty(_description)) {
                element.Add(new XAttribute("description", _description));
            }

            return element; 
        }*/

        protected override IToggleButtonUnsize Interface => this;
    }
}