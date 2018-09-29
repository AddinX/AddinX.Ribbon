using System.Collections.Generic;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;

namespace AddinX.Ribbon.Implementation.Control {
    public abstract class AddInElement {
        private IDictionary<string, object> _attributes;

        protected AddInElement(string elementName) {
            ElementName = elementName;
        }

        /// <summary>
        /// Xml element Name
        /// </summary>
        protected string ElementName { get; }

        protected void SetAttribute(string attrName, object value) {
            if (_attributes == null) {
                _attributes = new Dictionary<string, object>();
            }

            if (_attributes.ContainsKey(attrName)) {
                _attributes[attrName] = value;
            } else {
                _attributes.Add(attrName, value);
            }
        }

        protected void RemoveAttribute(string attrName) {
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
                    if (item.Value != null) {
                        element.Add(new XAttribute(item.Key, item.Value));
                    }
                }
            }

            return element;
        }

        protected XElement ToXml(XNamespace ns, params XAttribute[] attributes) {
            var element = new XElement(ns + ElementName);
            foreach (var attr in attributes) {
                element.Add(attr);
            }

            if (_attributes != null) {
                foreach (var item in _attributes) {
                    if (item.Value != null) {
                        element.Add(new XAttribute(item.Key, item.Value));
                    }
                }
            }

            return element;
        }
    }
}