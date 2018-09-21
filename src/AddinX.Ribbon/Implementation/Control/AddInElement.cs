using System.Collections.Generic;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Control;

namespace AddinX.Ribbon.Implementation.Control {
    public abstract class AddInElement {
        protected const string tag_size = "size";
        protected const string tag_getSize = "getSize";
        protected const string tag_onAction = "onAction";
        protected const string tag_enabled = "enabled";
        protected const string tag_getEnabled = "getEnabled";
        protected const string tag_description = "description";
        protected const string tag_getDescription = "getDescription";
        protected const string tag_image = "image";
        protected const string tag_imageMso = "imageMso";
        protected const string tag_getImage = "getImage";
        protected const string tag_id = "id";
        protected const string tag_idQ = "idQ";
        protected const string tag_tag = "tag";
        protected const string tag_idMso = "idMso";
        protected const string tag_screentip = "screentip";
        protected const string tag_getScreentip = "getScreentip";
        protected const string tag_supertip = "supertip";
        protected const string tag_getSupertip = "getSupertip";
        protected const string tag_label = "label";
        protected const string tag_getLabel = "getLabel";
        protected const string tag_insertAfterMso = "insertAfterMso";
        protected const string tag_insertBeforeMso = "insertBeforeMso";
        protected const string tag_insertAfterQ = "insertAfterQ";
        protected const string tag_insertBeforeQ = "insertBeforeQ";
        protected const string tag_visible = "visible";
        protected const string tag_getVisible = "getVisible";
        protected const string tag_keytip = "keytip";
        protected const string tag_getKeytip = "getKeytip";
        protected const string tag_showLabel = "showLabel";
        protected const string tag_getShowLabel = "getShowLabel";
        protected const string tag_showImage = "showImage";
        protected const string tag_getShowImage = "getShowImage";

        private IDictionary<string, object> _attributes;

        protected AddInElement(string elementName) {
            ElementName = elementName;
        }

        /// <summary>
        /// Xml element Name
        /// </summary>
        protected string ElementName { get; }

        protected internal void SetAttribute(string attrName, object value) {
            if (_attributes == null) {
                _attributes = new Dictionary<string, object>();
            }

            if (_attributes.ContainsKey(attrName)) {
                _attributes[attrName] = value;
            } else {
                _attributes.Add(attrName,value);
            }
        }

        protected internal void RemoveAttribute(string attrName) {
            if (_attributes == null) {
                return;
            }
            if (_attributes.ContainsKey(attrName)) {
                _attributes.Remove(attrName);
            }
        }

        /// <summary>
        /// callback register
        /// </summary>
        protected ICallbackRigister Register { get; private set; }

        protected internal virtual void SetRegister(ICallbackRigister register) {
            this.Register = register;
        }

        protected internal virtual XElement ToXml(XNamespace ns) {
            var element = new XElement(ns + ElementName);
            if (_attributes != null) {
                foreach (var item in _attributes) {
                    element.Add(new XAttribute(item.Key, item.Value));
                }
            }

            return element;
        }

        protected XElement ToXml(XNamespace ns,params XAttribute[] attributes) {
            var element = new XElement(ns + ElementName);
            foreach (var attr in attributes) {
                element.Add(attr);
            }
            if (_attributes != null) {
                foreach (var item in _attributes) {
                    element.Add(new XAttribute(item.Key, item.Value));
                }
            }

            return element;
        }
    }
}