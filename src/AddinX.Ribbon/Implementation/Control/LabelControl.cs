using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Control.Label;
using AddinX.Ribbon.Implementation.Command;

namespace AddinX.Ribbon.Implementation.Control {
    public class LabelControl : Control, ILabelControl {
        private string _supertip;
        private string _screentip;

        public LabelControl(): base( "labelControl") {
        }

        protected internal override XElement ToXml(XNamespace ns) {
            /*var tmpId = (ElementId) Id;
            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                , new XAttribute("getEnabled", "GetEnabled")
                , new XAttribute("getVisible", "GetVisible")
                , new XAttribute("getLabel", "GetLabel")
                , new XAttribute("tag", tmpId.Value)
            );*/

            var element = base.ToXml(ns);
            element.AddAttribute("screentip", _screentip);
            element.AddAttribute("supertip", _supertip);

            return element;
        }

        public ILabelControl SetId(string name) {
            Id.SetId(name);
            return this;
        }

        public ILabelControl SetIdMso(string name) {
            Id.SetMicrosoftId(name);
            return this;
        }

        public ILabelControl SetIdQ(string ns, string name) {
            Id.SetNamespaceId(ns, name);
            return this;
        }

        public ILabelControl Supertip(string supertip) {
            _supertip = supertip;
            return this;
        }

        public ILabelControl Keytip(string keytip) {
            //throw new NotImplementedException();
            return this;
        }

        public ILabelControl Screentip(string screentip) {
            _screentip = screentip;
            return this;
        }

        #region Implementation of IRibbonCallback<out ILabelControl,out ILabelCommand>

        public ILabelControl Callback(Action<ILabelCommand> builder) {
            builder(GetCommand<LabelCommand>());
            return this;
        }

        #endregion
    }
}