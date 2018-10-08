namespace AddinX.Ribbon.Contract.Command {
    public interface ICommand {
        /// <summary>
        /// 命令所属控件Id, <see cref="WriteCallbackXml">生成 Ribbon Xml</see>时会更新此Id
        /// </summary>
        string ControlId { get; }

    }
}