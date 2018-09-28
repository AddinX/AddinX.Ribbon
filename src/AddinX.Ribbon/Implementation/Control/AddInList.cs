using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;

namespace AddinX.Ribbon.Implementation.Control {
    public abstract class AddInList {
        protected internal abstract IEnumerable<XElement> ToXml(XNamespace ns);

        /// <summary>
        /// callback register
        /// </summary>
        protected ICallbackRigister Register { get; private set; }

        protected internal virtual void SetRegister(ICallbackRigister register) {
            this.Register = register;
        }
    }

    public abstract class AddInList<TItem> : AddInList, IEnumerable<TItem> where TItem : AddInElement {
        protected readonly IList<TItem> InnerList = new List<TItem>();

        protected AddInList() {
        }

        protected internal override void SetRegister(ICallbackRigister register) {
            base.SetRegister(register);
            foreach (var item in InnerList) {
                item.SetRegister(register);
            }
        }

        protected internal override IEnumerable<XElement> ToXml(XNamespace ns) {
            return InnerList.Select(gp => gp.ToXml(ns));
        }

        #region Implementation of IEnumerable

        /// <summary>返回一个循环访问集合的枚举器。</summary>
        /// <returns>可用于循环访问集合的 <see cref="T:System.Collections.Generic.IEnumerator`1" />。</returns>
        public IEnumerator<TItem> GetEnumerator() {
            foreach (var item in InnerList) {
                yield return item;
            }
        }

        /// <summary>返回一个循环访问集合的枚举器。</summary>
        /// <returns>可用于循环访问集合的 <see cref="T:System.Collections.IEnumerator" /> 对象。</returns>
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion
    }
}