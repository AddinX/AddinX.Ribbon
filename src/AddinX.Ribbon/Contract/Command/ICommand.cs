using System.Xml.Linq;

namespace AddinX.Ribbon.Contract.Command
{
    public interface ICommand {
        /// <summary>
        /// 写入回调Xml属性
        /// </summary>
        /// <param name="element"></param>
        void WriteCallbackXml(XElement element);
    }
}