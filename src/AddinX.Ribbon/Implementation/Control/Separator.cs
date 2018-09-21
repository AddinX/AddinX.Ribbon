using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Control.Separator;
using AddinX.Ribbon.Implementation.Command;

namespace AddinX.Ribbon.Implementation.Control {
    public class Separator : Control, ISeparator {
        public Separator(): base( "separator") {
        }

        protected internal override XElement ToXml(XNamespace ns) {
            var tmpId = (ElementId) Id;
            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                , new XAttribute("getVisible", "GetVisible")
            );

            return element;
        }

        public void SetId(string name) {
            Id.SetId(name);
        }

        public void SetIdQ(string ns, string name) {
            Id.SetNamespaceId(ns, name);
        }

        #region Implementation of IRibbonCallback<out ISeparator,out ISeparatorCommand>

        public ISeparator Callback(Action<ISeparatorCommand> builder) {
            builder(GetCommand<SeparatorCommand>());
            return this;
        }

        #endregion
    }
}