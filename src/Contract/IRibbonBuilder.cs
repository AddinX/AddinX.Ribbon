namespace AddinX.Ribbon.Contract
{
    public interface IRibbonBuilder
    {
        ICustomUi CustomUi { get; }

        string GetXmlString();
    }
}