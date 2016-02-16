using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AddinX.Core.Contract;
using AddinX.Core.Contract.Command;
using AddinX.Core.ExcelDna;

namespace AddinX.Core.IntegrationTest.ButtonAndBox
{
    [ComVisible(true)]
    public class Ribbon : RibbonFluent
    {
        private const string ReportingGroup = "reportingGroup";
        private const string PortfolioAllocationBtn = "portfolioAllocation";
        private const string PortfolioContributorBtn = "portfolioContributor";
        private const string AnalyticsGroup = "analyticsGroup";
        private const string TestTab = "TestTab";
        private const string PortfolioAnalyzerBtn = "portfolioAnalyzer";
        private const string ReportingBox = "reportingBox";
        private const string PortfolioPerformanceBtn = "portfolioPerformance";

        protected override void CreateFluentRibbon(IRibbonBuilder builder)
        {
            builder.CustomUi.Ribbon.Tabs(c =>
            {
                c.AddTab("test").SetId(TestTab)
                    .Groups(g =>
                    {
                        g.AddGroup("reporting").SetId(ReportingGroup)
                            .Items(d =>
                            {
                                d.AddBouton("Allocation")
                                    .SetId(PortfolioAllocationBtn)
                                    .LargeSize()
                                    .ImageMso("HappyFace");
                                d.AddBox().SetId(ReportingBox)
                                    .HorizontalDisplay().AddItems(i =>
                                    {
                                        i.AddBouton("Performance")
                                            .SetId(PortfolioPerformanceBtn)
                                            .NormalSize()
                                            .ImageMso("HappyFace");
                                        i.AddBouton("Contributor").SetId(PortfolioContributorBtn)
                                            .NormalSize().NoImage().ShowLabel()
                                            .Supertip("Portfolio best contributor")
                                            .Screentip(
                                                "Display the top / bottom X contributor to the portfolio performance.");

                                    });
                            });
                        g.AddGroup("Analytic").SetId(AnalyticsGroup)
                            .Items(i => i.AddBouton("Portfolio Analysis").SetId(PortfolioAnalyzerBtn).NormalSize()
                                .NoImage().ShowLabel());
                    });
            });
        }

        protected override void CreateRibbonCommand(IRibbonCommands cmds)
        {
            cmds.AddButtonCommand(PortfolioAnalyzerBtn).IsEnabled(() => AddinContext.ExcelApp.Worksheets.Count() > 1)
                .Action(() => MessageBox.Show("Analyzer button clicked"));
            cmds.AddButtonCommand(PortfolioContributorBtn)
                .Action(() => MessageBox.Show("Portfolio contributors button clicked"));
            cmds.AddButtonCommand(PortfolioAllocationBtn)
                .Action(() => MessageBox.Show("Portfolio allocation button clicked"));
            cmds.AddBoxCommand(ReportingBox).IsVisible(() => AddinContext.ExcelApp.Worksheets.Count() > 1);
        }

        public override void OnClosing()
        {
            AddinContext.ExcelApp.SheetActivateEvent -= (e) => RefreshRibbon();
            AddinContext.ExcelApp.SheetChangeEvent -= (a, e) => RefreshRibbon();

            AddinContext.ExcelApp.DisposeChildInstances(true);
            AddinContext.ExcelApp = null;
        }

        public override void OnOpening()
        {
            AddinContext.ExcelApp.SheetActivateEvent += (e) => RefreshRibbon();
            AddinContext.ExcelApp.SheetChangeEvent += (a, e) => RefreshRibbon();
        }

        private void RefreshRibbon()
        {
            Ribbon?.Invalidate();
        }
    }
}
