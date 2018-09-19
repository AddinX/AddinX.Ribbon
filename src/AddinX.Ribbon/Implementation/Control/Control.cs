using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;
using AddinX.Ribbon.Contract.Control;

namespace AddinX.Ribbon.Implementation.Control {
    public abstract class Control : AddInElement {
        protected internal IElementId Id { get; protected set; }
        protected internal string Label { get; set; }

        private readonly IDictionary<string, ICallbackField> _callbacks = new ConcurrentDictionary<string, ICallbackField>();

        protected Control() {
            Id = new ElementId();
            Label = string.Empty;
        }

        protected internal void SetLabel(string label) {
            this.Label = label;
        }

        /// <summary>
        /// 注册 Callback
        /// </summary>
        /// <param name="name"></param>
        /// <param name="command"></param>
        protected void RegisteCallback(string name, ICallbackField command) {
            if (_callbacks.ContainsKey(name)) {
                _callbacks[name] = command;
            } else {
                _callbacks.Add(name,command);
            }
        }

        private void ToCallbackXml(XElement element) {
            if (this._callbacks.Any()) {
                foreach (var key in _callbacks.Keys) {
                    var callbackFunc = Char.ToUpper(key[0]) + key.Substring(1);
                    var name = Char.ToLower(key[0]) + key.Substring(1);
                    element.Add(new XAttribute(name,callbackFunc));
                }
            }
        }

        protected internal override XElement ToXml(XNamespace ns) {
            var element = base.ToXml(ns);
            var tmpId = (ElementId) Id;
            element.Add(new XAttribute(tmpId.Type.ToString(), tmpId.Value));
            element.AddAttribute("label", Label,string.Empty);
            element.Add(new XAttribute("tag", tmpId.Value));
            ToCallbackXml(element);
            return element;
        }
    }
}