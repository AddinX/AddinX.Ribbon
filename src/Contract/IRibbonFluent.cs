using AddinX.Ribbon.Contract.Command;

namespace AddinX.Ribbon.Contract
{
    public interface IRibbonFluent
    {
        string GetRibbonXml();

        ICommand FindRibbonCmd(string id);

        void OnClosing();

        void OnOpening();
    }
}