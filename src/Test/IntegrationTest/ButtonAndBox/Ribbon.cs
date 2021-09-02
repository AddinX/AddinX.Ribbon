using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.ExcelDna;

namespace AddinX.Ribbon.IntegrationTest.ButtonAndBox
{
    [ComVisible(true)]
    public class Ribbon : RibbonFluent
    {
        private const string DataGroupId = "DataGroupId";
        private const string PortfolioAllocationBtn = "portfolioAllocation";
        private const string PortfolioContributorBtn = "portfolioContributor";
        private const string AnalyticsGroup = "analyticsGroup";
        private const string MyTabId = "MyTabId";
        private const string PortfolioAnalyzerBtn = "portfolioAnalyzer";
        private const string ReportingBox = "reportingBox";
        private const string PortfolioPerformanceBtn = "portfolioPerformance";

        protected override void CreateFluentRibbon(IRibbonBuilder builder)
        {
            builder.CustomUi.AddNamespace("acme", "acme.addin.sync").Ribbon.Tabs(c =>
            {
                c.AddTab("My Tab").SetIdQ("acme", MyTabId)
                    .Groups(g =>
                    {
                        g.AddGroup("Data").SetIdQ("acme", DataGroupId)
                            .Items(d =>
                            {
                                d.AddButton("Allocation")
                                    .SetId(PortfolioAllocationBtn)
                                    .LargeSize()
                                    .ImageMso("HappyFace");
                                d.AddBox().SetId(ReportingBox)
                                    .HorizontalDisplay().AddItems(i =>
                                    {
                                        i.AddButton("Performance")
                                            .SetId(PortfolioPerformanceBtn)
                                            .NormalSize()
                                            .ImageMso("HappyFace");
                                        i.AddButton("Contributor").SetId(PortfolioContributorBtn)
                                            .NormalSize().NoImage().ShowLabel()
                                            .Supertip("Portfolio best contributor")
                                            .Screentip(
                                                "Display the top / bottom X contributor to the portfolio performance.");

                                    });
                            });
                        g.AddGroup("Analytic").SetId(AnalyticsGroup)
                            .Items(i => i.AddButton("Portfolio Analysis").SetId(PortfolioAnalyzerBtn).NormalSize()
                                .NoImage().ShowLabel());
                    });
            });
        }

        protected override void CreateRibbonCommand(IRibbonCommands cmds)
        {
            

            cmds.AddButtonCommand(PortfolioAnalyzerBtn).IsEnabled(() => SheetCount() > 1)
                .Action(() => MessageBox.Show("Analyzer button clicked"));
            cmds.AddButtonCommand(PortfolioContributorBtn)
                .Action(() => MessageBox.Show("Portfolio contributors button clicked"));
            cmds.AddButtonCommand(PortfolioAllocationBtn)
                .Action(() => MessageBox.Show("Portfolio allocation button clicked"));
            cmds.AddBoxCommand(ReportingBox).IsVisible(() => SheetCount () > 1);
        }

        private int SheetCount()
        {
            var sheetCount = 0;
            if (AddinContext.ExcelApp.Workbooks!= null || AddinContext.ExcelApp.Workbooks.Count>0)
            {
                sheetCount = AddinContext.ExcelApp.Worksheets.Count;
            }

            return sheetCount;
        }

        public override void OnClosing()
        {
            AddinContext.ExcelApp.SheetActivate -= (e) => RefreshRibbon();
            AddinContext.ExcelApp.SheetChange -= (a, e) => RefreshRibbon();

            //AddinContext.ExcelApp.DisposeChildInstances(true);
            AddinContext.ExcelApp = null;
        }

        public override void OnOpening()
        {
            AddinContext.ExcelApp.SheetActivate += (e) => RefreshRibbon();
            AddinContext.ExcelApp.SheetChange += (a, e) => RefreshRibbon();
        }

        private void RefreshRibbon()
        {
            Ribbon?.Invalidate();
        }
    }
}
