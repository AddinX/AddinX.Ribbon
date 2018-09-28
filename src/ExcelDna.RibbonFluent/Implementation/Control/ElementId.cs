using AddinX.Ribbon.Contract.Control;
using AddinX.Ribbon.Contract.Enums;

namespace AddinX.Ribbon.Implementation.Control {
    public class ElementId : IElementId {
        private static int _autoId = 1;
        public IdType Type { get; private set; }
        public string Value { get; private set; }

        public ElementId() {
            Value = $"id_{_autoId++:0000}";
        }

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

        #region Overrides of Object

        /// <summary>���ر�ʾ��ǰ <see cref="T:System.Object" /> �� <see cref="T:System.String" />��</summary>
        /// <returns>
        /// <see cref="T:System.String" />����ʾ��ǰ�� <see cref="T:System.Object" />��</returns>
        public override string ToString() {
            return $"{Type}={Value}";
        }

        #endregion
    }
}