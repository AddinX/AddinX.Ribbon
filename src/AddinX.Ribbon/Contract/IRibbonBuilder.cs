using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Control;

namespace AddinX.Ribbon.Contract
{
    public interface IRibbonBuilder
    {
        ICustomUi CustomUi { get; }

        string GetXmlString();
    }

    /// <summary>
    /// Ribbon callbck 注册器
    /// </summary>
    public interface ICallbackRigister {

        /// <summary>
        /// 注册命令
        /// </summary>
        /// <param name="elementId"></param>
        /// <param name="command"></param>
        void Add(IElementId elementId, ICommand command);
    }
}