using System;
using System.IO;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Enums;
using AddinX.Ribbon.Implementation;
using NUnit.Framework;

namespace ExcelDna.RibbonFluent.Tests
{
    [TestFixture]
    public class FluentRibbonBuilderTest
    {
        private IRibbonBuilder builder;
       
        [SetUp]
        public void SetUp()
        {   
            builder = new RibbonBuilder();
        }

        private string LoadXml(string path) {
            var basePath = typeof(FluentRibbonBuilderTest).Assembly.Location;
            var fullPath = Path.Combine(Path.GetDirectoryName(basePath), path);
            return XDocument.Load(fullPath).ToString();
        }

        private void AssertXml(string expectedFile, IRibbonBuilder builder) {
            var expected = LoadXml(expectedFile);
            // Act
            var str = builder.GetXmlString();
            Console.WriteLine(str);

            Assert.True(ValidateHelper.Validate(str));
            // Assert
            //Assert.AreEqual(expected, str);
        }

        [Test]
        public void GroupWithButtons()
        {
            // Prepare
            var expected = "Sample/GroupWithButtons.xml";
            
            builder.CustomUi.Ribbon.Tabs(c =>
            {
                c.AddTab("test").Id("tab1")
                    .Groups(g=>
                    {
                        g.AddGroup("reporting").Id("reportingGroup")
                            .Items(i =>
                            {
                                i.AddButton("Allocation").Id("portfolioAllocation").LargeSize().ImageMso("HappyFace");
                                i.AddButton("Contributor").Id("Contributor").NormalSize()
                                    .NoImage().ShowLabel().Supertip("Portfolio best contributor")
                                    .Screentip("Display the top / bottom X contributor to the portfolio performance.");
                                
                            });
                        g.AddGroup("Analytic").Id("AnalyticGroup")
                            .Items(i => i.AddButton("Portfolio Analysis").Id("portfolioAnalyser").NormalSize()
                            .NoImage().ShowLabel());
                    });
            });

           AssertXml(expected,builder);
        }

        [Test]
        public void GroupWithBoxLauncher() {
            // Prepare
            var expected = "Sample/GroupWithDialogBoxLauncher.xml";

            builder.CustomUi.Ribbon.Tabs(c => {
                c.AddTab("test").Id("tab1")
                    .Groups(g => {
                        g.AddGroup("reporting").Id("reportingGroup")
                            .Items(i => {
                                i.AddButton("Allocation").Id("portfolioAllocation").LargeSize()
                                    .ImageMso("HappyFace");
                                i.AddButton("Contributor").Id("Contributor").NormalSize()
                                    .NoImage().ShowLabel().Supertip("Portfolio best contributor")
                                    .Screentip("Display the top / bottom X contributor to the portfolio performance.");

                            }).DialogBoxLauncher(o => o.AddDialogBoxLauncher().Id("ReportingConfig")
                                .Supertip("Allocation Configuration")
                                .Screentip("Configuration panel for the Allocation group"));
                    });
            });

            AssertXml(expected, builder);
        }

        [Test]
        public void ContextualTabWithButtons() {
            // Prepare
            var expected = "Sample/ContextualTabWithBoxes.xml";

            builder.CustomUi.Ribbon.ContextualTabs(ct => ct.AddTabSet(ts => {
                ts.IdMso(TabSetId.TabSetPivotTableTools)
                    .Tabs(
                        c => {
                            c.AddTab("Portfolio").Id("tab1")
                                .Groups(g => {
                                    g.AddGroup("reporting").Id("reportingGroup")
                                        .Items(i => {
                                            i.AddButton("Allocation")
                                                .Id("portfolioAllocation")
                                                .LargeSize()
                                                .ImageMso("HappyFace");
                                            i.AddButton("Contributor").Id("Contributor").NormalSize()
                                                .NoImage().ShowLabel().Supertip("Portfolio best contributor")
                                                .Screentip(
                                                    "Display the top / bottom X contributor to the portfolio performance.");

                                        });
                                    g.AddGroup("Analytic").Id("AnalyticGroup")
                                        .Items(
                                            i =>
                                                i.AddButton("Portfolio Analysis")
                                                    .Id("portfolioAnalyser")
                                                    .NormalSize()
                                                    .NoImage().ShowLabel());
                                });
                        });
            }));


            AssertXml(expected, builder);
        }

        [Test]
        public void GroupWithBoxes() {
            // Prepare
            var expected = "Sample/GroupWithBoxes.xml";

            builder.CustomUi.Ribbon.Tabs(c => {
                c.AddTab("test").Id("tab1")
                    .Groups(g => {
                        g.AddGroup("reporting").Id("reportingGroup")
                            .Items(i => {
                                i.AddBox().Id("ButtonsVertical").VerticalDisplay().Items(b => {
                                    b.AddButton("Allocation")
                                        .Id("portfolioAllocation")
                                        .LargeSize()
                                        .ImageMso("HappyFace");
                                    b.AddButton("Contributor").Id("Contributor").LargeSize()
                                        .NoImage().ShowLabel().Supertip("Portfolio best contributor")
                                        .Screentip(
                                            "Display the top / bottom X contributor to the portfolio performance.");
                                });
                                i.AddBox().Id("ButtonsHorizontal").HorizontalDisplay().Items(b => {
                                    b.AddButton("Portfolio Analysis")
                                        .Id("portfolioAnalyser").NormalSize()
                                        .NoImage().ShowLabel();
                                    b.AddButton("Return Analysis")
                                        .Id("ReturnAnalyser").NormalSize()
                                        .NoImage()
                                        .ShowLabel()
                                        .Description("Analyze the returns of your sample portfolio");
                                });
                            });
                    });
            });

            AssertXml(expected, builder);
        }

        [Test]
        public void GroupWithCheckBoxAndLabel() {
            // Prepare
            var expected = "Sample/GroupWithCheckboxAndLabel.xml";

            builder.CustomUi.Ribbon.ContextualTabs(ct => ct.AddTabSet(ts => {
                ts.IdMso(TabSetId.TabSetPivotTableTools)
                    .Tabs(
                        c => {
                            c.AddTab("Internal").Id("tab1")
                                .Groups(g => {
                                    g.AddGroup("Print settings").Id("printSettingsGroup")
                                        .Items(i => {
                                            i.AddCheckbox("Center Horizontal").Id("centerHorizontal")
                                                .Screentip("Center Content Horizontally");
                                            i.AddCheckbox("Center Vertical").Id("centerVertical")
                                                .Screentip("Center Content Vertically");
                                            i.AddSeparator().Id("separatorOne");
                                            i.AddCheckbox("Fit To 1 Page Width").Id("FitToPage")
                                                .Screentip("Fit Content to the page width");
                                            i.AddLabelControl().Id("printZoomLabel");
                                            i.AddEditbox("Zoom").Id("printZoomValue").NoImage()
                                                .Screentip("Zooming percentage for printing")
                                                .MaxLength(5).SizeString(5);
                                        });
                                });
                        });
            }));


            AssertXml(expected, builder);
        }

        [Test]
        public void GroupWithComboBox() {
            // Prepare
            var expected = "Sample/GroupWithComboBox.xml";

            builder.CustomUi.Ribbon.ContextualTabs(ct => ct.AddTabSet(ts => {
                ts.IdMso(TabSetId.TabSetPivotTableTools)
                    .Tabs(
                        c => {
                            c.AddTab("Internal").Id("tab1")
                                .Groups(g => {
                                    g.AddGroup("Extra settings").Id("extraSettingsGroup")
                                        .Items(i => {
                                            i.AddComboBox("Colors").Id("colorsPicking")
                                                .ShowLabel().NoImage()
                                                .Items(o => {
                                                    o.AddItem("Green").Id("greenColor");
                                                    o.AddItem("Red").Id("redColor").NoImage();
                                                    o.AddItem("Blue").Id("blueColor").NoImage();
                                                }).Supertip("Color Picking")
                                                .MaxLength(15).SizeString(15);
                                        });

                                    g.AddGroup("Time zone settings").Id("timeZoneSettingsGroup")
                                        .Items(i => {
                                            i.AddComboBox("Country").Id("countryPicking")
                                                .ShowLabel().NoImage()
                                                .DynamicItems().Supertip("Country Picking")
                                                .Supertip("Pick a country to know its current time")
                                                ;
                                        });
                                });
                        });
            }));


            AssertXml(expected, builder);
        }

        [Test]
        public void GroupWithToggleButton() {
            // Prepare
            var expected = "Sample/GroupWithToggleButton.xml";

            builder.CustomUi.Ribbon.Tabs(
                c => {
                    c.AddTab("Internal").Id("tab1")
                        .Groups(g => {
                            g.AddGroup("Extra settings").Id("extraSettingsGroup")
                                .Items(i => {
                                    i.AddToggleButton("Hide View Tab").Id("HideViewTab")
                                        .ShowLabel().LargeSize()
                                        .NoImage().Supertip("Hide View Tab")
                                        .Callback(cmd =>cmd.OnPressed(Console.WriteLine)
                                            .GetPressed(() => true));
                                });
                        });
                });



            AssertXml(expected, builder);
        }

        [Test]
        public void GroupWithDropDown() {
            // Prepare
            var expected = "Sample/GroupWithDropDown.xml";

            builder.CustomUi.Ribbon.Tabs(c => {
                c.AddTab("Internal").Id("tab1")
                    .Groups(g => {
                        g.AddGroup("Extra settings").Id("extraSettingsGroup")
                            .Items(i => {
                                i.AddDropDown("Colors").Id("ColorsSelection")
                                    .ShowLabel().NoImage().ShowItemLabel()
                                    .HideItemImage()
                                    .Items(o => {
                                        o.AddItem("Green").Id("greenColor");
                                        o.AddItem("Red").Id("redColor").NoImage();
                                        o.AddItem("Blue").Id("blueColor").NoImage();
                                    }).Supertip("Color Picking");
                            });

                        g.AddGroup("Units Settings").Id("UnitsSettingsGroup")
                            .Items(i => {
                                i.AddDropDown("Unit To:").Id("centimeter2Unit")
                                    .ShowLabel().NoImage().ShowItemLabel().HideItemImage()
                                    .DynamicItems().Supertip("Centimeter Conversion")
                                    .Supertip("Convert centimeters to others units")
                                    ;
                            });
                    });
            });


            AssertXml(expected, builder);
        }

        [Test]
        public void GroupWithGallery() {
            // Prepare
            var expected = "Sample/GroupWithGallery.xml";

            builder.CustomUi.Ribbon.Tabs(c => {
                c.AddTab("Internal").Id("tab1")
                    .Groups(g => {
                        g.AddGroup("Extra settings").Id("extraSettingsGroup")
                            .Items(i => {
                                i.AddGallery("Colors").Id("ColorsSelection")
                                    .ShowLabel().NormalSize().NoImage().ShowItemLabel()
                                    .HideItemImage()
                                    .Items(o => {
                                        o.AddItem("Green").Id("greenColor");
                                        o.AddItem("Red").Id("redColor").NoImage();
                                        o.AddItem("Blue").Id("blueColor").NoImage();
                                    }).Buttons(o =>
                                        o.AddButton("Extra Colors").Id("ExtraColors")
                                            .ImageMso("HappyFace").ShowLabel()
                                    ).Supertip("Color Picking");
                            });

                        g.AddGroup("Units Settings").Id("UnitsSettingsGroup")
                            .Items(i => {
                                i.AddGallery("Unit To:").Id("centimeter2Unit")
                                    .ShowLabel().NormalSize().NoImage().ShowItemLabel().HideItemImage()
                                    .DynamicItems().Supertip("Centimeter Conversion")
                                    .Supertip("Convert centimeters to others units");
                            });
                    });
            });


            AssertXml(expected, builder);
        }

        [Test]
        public void GroupWithMenu() {
            // Prepare
            var expected = "Sample/GroupWithMenu.xml";

            builder.CustomUi.Ribbon.Tabs(c => {
                c.AddTab("Internal").Id("tab1")
                    .Groups(g => {
                        g.AddGroup("Extra settings").Id("extraSettingsGroup")
                            .Items(i => {
                                i.AddMenu("Options").Id("optionMenu")
                                    .ShowLabel().NoImage().LargeSize().ItemLargeSize()
                                    .Items(l => {
                                        l.AddCheckbox("Option 1").Id("optionsOne")
                                            .Screentip("CheckBox Option");
                                        l.AddButton("Option 2")
                                            .Id("BoutonOption")
                                            .ImageMso("HappyFace");
                                        l.AddButton("Option 3")
                                            .Id("BoutonOptionTwo")
                                            .ImageMso("HappyFace");

                                        l.AddSeparator();
                                        l.AddGallery("Colors").Id("ColorsSelection")
                                            .ShowLabel().NoImage().ShowItemLabel()
                                            .HideItemImage()
                                            .Items(o => {
                                                o.AddItem("Green").Id("greenColor");
                                                o.AddItem("Red").Id("redColor").NoImage();
                                                o.AddItem("Blue").Id("blueColor").NoImage();
                                            }).Buttons(o =>
                                                o.AddButton("Extra Colors").Id("ExtraColors")
                                                    .NoImage().ShowLabel()
                                            ).Supertip("Color Picking");
                                    })
                                    .Callback(cmds=>cmds.GetSize(()=>ControlSize.large));
                            });
                    });
            });

            AssertXml(expected, builder);
        }

    }
}
