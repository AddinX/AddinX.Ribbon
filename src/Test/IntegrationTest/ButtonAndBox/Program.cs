using System;
using ExcelDna.Integration;
using ExcelDna.Logging;
using NetOffice.ExcelApi;

namespace AddinX.Ribbon.IntegrationTest.ButtonAndBox
{
    // This class implements the ExcelDna.Integration.IExcelAddIn interface.
    // This allows the add-in to run code at start-up
    public class Program : IExcelAddIn
    {
        public void AutoOpen()
        {
            try
            {
                // The Excel Application object
                AddinContext.ExcelApp = new Application(null, ExcelDnaUtil.Application);

            }
            catch (Exception e)
            {
                LogDisplay.RecordLine(e.Message);
                LogDisplay.RecordLine(e.StackTrace);
                LogDisplay.Show();
            }
        }

        public void AutoClose()
        {
            throw new NotImplementedException();
        }
    }
}