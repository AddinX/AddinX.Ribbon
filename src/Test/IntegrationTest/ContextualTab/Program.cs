using System;
using ExcelDna.Integration;
using ExcelDna.Logging;
using NetOffice.ExcelApi;

namespace ContextualTab
{
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
