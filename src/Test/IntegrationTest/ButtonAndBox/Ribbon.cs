using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.ExcelDna;
using AddinX.Ribbon.Implementation;

namespace AddinX.Ribbon.IntegrationTest.ButtonAndBox {
    [ComVisible(true)]
    public class Ribbon : RibbonFluent {
        private const string DataGroupId = "DataGroupId";
        private const string PortfolioAllocationBtn = "portfolioAllocation";
        private const string PortfolioContributorBtn = "portfolioContributor";
        private const string AnalyticsGroup = "analyticsGroup";
        private const string MyTabId = "MyTabId";
        private const string PortfolioAnalyzerBtn = "portfolioAnalyzer";
        private const string ReportingBox = "reportingBox";
        private const string PortfolioPerformanceBtn = "portfolioPerformance";
        private readonly RibbonCommands _commands = new RibbonCommands();

        protected override void CreateFluentRibbon(IRibbonBuilder builder) {
            builder.CustomUi.AddNamespace("acme", "acme.addin.sync").Ribbon.Tabs(c => {
                c.AddTab("My Tab").IdQ("acme", MyTabId)
                    .Groups(g => {
                        g.AddGroup("Data").IdQ("acme", DataGroupId)
                            .Items(d => {
                                d.AddButton("Allocation")
                                    .Id(PortfolioAllocationBtn)
                                    .LargeSize()
                                    .ImageMso("HappyFace")
                                    .Callback((IButtonCommand)_commands.Find(PortfolioAllocationBtn));

                                d.AddBox().Id(ReportingBox)
                                    .HorizontalDisplay().Items(i => {
                                        i.AddButton("Performance")
                                            .Id(PortfolioPerformanceBtn)
                                            .NormalSize()
                                            .ImageMso("HappyFace")
                                            .Callback((IButtonCommand)_commands.Find(PortfolioPerformanceBtn));

                                        i.AddButton("Contributor").Id(PortfolioContributorBtn)
                                            .NormalSize().NoImage().ShowLabel()
                                            .Supertip("Portfolio best contributor")
                                            .Screentip("Display the top / bottom X contributor to the portfolio performance.")
                                            .Callback((IButtonCommand)_commands.Find(PortfolioContributorBtn));
                                    }).Callback((IBoxCommand)_commands.Find(ReportingBox));
                            });
                        g.AddGroup("Analytic").Id(AnalyticsGroup)
                            .Items(i => i.AddButton("Portfolio Analysis").Id(PortfolioAnalyzerBtn).NormalSize()
                                .NoImage().ShowLabel()
                            .Callback((IButtonCommand)_commands.Find(PortfolioAnalyzerBtn))
                            );
                    });
            });
        }

        protected void CreateRibbonCommand(IRibbonCommands cmds) {
            cmds.AddButtonCommand(PortfolioAnalyzerBtn).GetEnabled(() => AddinContext.ExcelApp.Worksheets.Count() > 1)
                .OnAction(() => MessageBox.Show("Analyzer button clicked"));
            cmds.AddButtonCommand(PortfolioContributorBtn)
                .OnAction(() => MessageBox.Show("Portfolio contributors button clicked"));
            cmds.AddButtonCommand(PortfolioAllocationBtn)
                .OnAction(() => MessageBox.Show("Portfolio allocation button clicked"));
            cmds.AddBoxCommand(ReportingBox).GetVisible(() => AddinContext.ExcelApp.Worksheets.Count() > 1);
        }

        public override void OnClosing() {
            AddinContext.ExcelApp.SheetActivateEvent -= (e) => RefreshRibbon();
            AddinContext.ExcelApp.SheetChangeEvent -= (a, e) => RefreshRibbon();

            AddinContext.ExcelApp.DisposeChildInstances(true);
            AddinContext.ExcelApp = null;
        }

        public override void OnOpening() {
            AddinContext.ExcelApp.SheetActivateEvent += (e) => RefreshRibbon();
            AddinContext.ExcelApp.SheetChangeEvent += (a, e) => RefreshRibbon();
            CreateRibbonCommand(_commands);
        }

        private void RefreshRibbon() {
            Ribbon?.Invalidate();
        }
    }
}