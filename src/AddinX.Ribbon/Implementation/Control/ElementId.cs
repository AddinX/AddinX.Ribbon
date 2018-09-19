using AddinX.Ribbon.Contract.Control;
using AddinX.Ribbon.Contract.Enums;

namespace AddinX.Ribbon.Implementation.Control {
    public class ElementId : IElementId {
        protected internal IdType Type = IdType.id;
        protected internal string Value = "s";

        public IElementId SetId(string name) {
            Value = name;
            Type = IdType.id;
            return this;
        }

        public IElementId SetMicrosoftId(string name) {
            Value = name;
            Type = IdType.idMso;
            return this;
        }

        public IElementId SetNamespaceId(string namespaceKey, string name) {
            Value = namespaceKey + ":" + name;
            Type = IdType.idQ;
            return this;
        }
    }
}