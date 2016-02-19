using NetOffice.ExcelApi;

namespace AddinX.Ribbon.IntegrationTest.ComboBoxAndDropDown
{
    // This class implements the ExcelDna.Integration.IExcelAddIn interface.
    // This allows the add-in to run code at start-up

    public class AddinContext
    {
        public static Application ExcelApp { get; set; }
    }
}
