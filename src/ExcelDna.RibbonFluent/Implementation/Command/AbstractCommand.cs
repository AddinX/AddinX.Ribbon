using System.Xml.Linq;
using AddinX.Ribbon.Contract.Command;

namespace AddinX.Ribbon.Implementation.Command {
    /// <summary>
    /// 抽象命令,用于更新 <see cref="ControlId"/>
    /// </summary>
    public abstract class AbstractCommand : ICommand {
        #region Implementation of ICommand

        public string ControlId { get; protected internal set; }

        /// <summary>
        /// 写入回调Xml属性
        /// </summary>
        /// <param name="element"></param>
        protected internal abstract void WriteXml(XElement element);

        #endregion
    }
}