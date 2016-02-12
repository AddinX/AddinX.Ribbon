namespace AddinX.Core.Contract
{
    public interface IRibbonBuilder
    {
        ICustomUi CustomUi { get; }

        string GetXmlString();
    }
}