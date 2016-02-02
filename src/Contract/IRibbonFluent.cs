using AddinX.Core.Contract.Command;

namespace AddinX.Core.Contract
{
    public interface IRibbonFluent
    {
        string GetRibbonXml();

        ICommand FindRibbonCmd(string id);

        void OnClosing();

        void OnOpening();
    }
}