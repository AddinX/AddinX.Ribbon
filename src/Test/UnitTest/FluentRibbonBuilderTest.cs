using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Enums;
using AddinX.Ribbon.Implementation;
using NUnit.Framework;

namespace AddinX.Ribbon.UnitTest
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

        [Test]
        public void GroupWithButtons()
        {
            // Prepare
            var fullpath = $"{AppDomain.CurrentDomain.BaseDirectory}Sample/GroupWithButtons.xml";
            var expected = XDocument.Load(fullpath).ToString();

            builder.CustomUi.Ribbon.Tabs(c =>
            {
                c.AddTab("test").SetId("tab1")
                    .Groups(g =>
                    {
                        g.AddGroup("reporting").SetId("reportingGroup")
                            .Items(i =>
                            {
                                i.AddButton("Allocation").SetId("portfolioAllocation").LargeSize().ImageMso("HappyFace");
                                i.AddButton("Contributor").SetId("Contributor").NormalSize()
                                    .NoImage().ShowLabel().Supertip("Portfolio best contributor")
                                    .Screentip("Display the top / bottom X contributor to the portfolio performance.");

                            });
                        g.AddGroup("Analytic").SetId("AnalyticGroup")
                            .Items(i => i.AddButton("Portfolio Analysis").SetId("portfolioAnalyser").NormalSize()
                            .NoImage().ShowLabel());
                    });
            });

            // Act
            var str = builder.GetXmlString();

            // Assert
            Assert.AreEqual(expected, str);
        }

        [Test]
        public void GroupWithBoxLauncher()
        {
            // Prepare
            var fullpath = $"{AppDomain.CurrentDomain.BaseDirectory}Sample/GroupWithDialogBoxLauncher.xml";
            var expected = XDocument.Load(fullpath).ToString();

            builder.CustomUi.Ribbon.Tabs(c =>
            {
                c.AddTab("test").SetId("tab1")
                    .Groups(g =>
                    {
                        g.AddGroup("reporting").SetId("reportingGroup")
                            .Items(i =>
                            {
                                i.AddButton("Allocation").SetId("portfolioAllocation").LargeSize().ImageMso("HappyFace");
                                i.AddButton("Contributor").SetId("Contributor").NormalSize()
                                    .NoImage().ShowLabel().Supertip("Portfolio best contributor")
                                    .Screentip("Display the top / bottom X contributor to the portfolio performance.");

                            }).DialogBoxLauncher(o => o.AddDialogBoxLauncher().SetId("ReportingConfig")
                                .Supertip("Allocation Configuration").Screentip("Configuration panel for the Allocation group"));

                    });
            });

            // Act
            var str = builder.GetXmlString();

            // Assert
            Assert.AreEqual(expected, str);
        }

        [Test]
        public void ContextualTabWithButtons()
        {
            // Prepare
            var fullpath = $"{AppDomain.CurrentDomain.BaseDirectory}Sample/ContextualTabWithBoxes.xml";
            var expected = XDocument.Load(fullpath).ToString();

            builder.CustomUi.Ribbon.ContextualTabs(ct => ct.AddTabSet(ts =>
            {
                ts.SetIdMso(TabSetId.TabSetPivotTableTools)
                    .Tabs(
                        c =>
                        {
                            c.AddTab("Portfolio").SetId("tab1")
                                .Groups(g =>
                                {
                                    g.AddGroup("reporting").SetId("reportingGroup")
                                        .Items(i =>
                                        {
                                            i.AddButton("Allocation")
                                                .SetId("portfolioAllocation")
                                                .LargeSize()
                                                .ImageMso("HappyFace");
                                            i.AddButton("Contributor").SetId("Contributor").NormalSize()
                                                .NoImage().ShowLabel().Supertip("Portfolio best contributor")
                                                .Screentip(
                                                    "Display the top / bottom X contributor to the portfolio performance.");

                                        });
                                    g.AddGroup("Analytic").SetId("AnalyticGroup")
                                        .Items(
                                            i =>
                                                i.AddButton("Portfolio Analysis")
                                                    .SetId("portfolioAnalyser")
                                                    .NormalSize()
                                                    .NoImage().ShowLabel());
                                });
                        });
            }));


            // Act
            var str = builder.GetXmlString();

            // Assert
            Assert.AreEqual(expected, str);
        }

        [Test]
        public void GroupWithBoxes()
        {
            // Prepare
            var fullpath = $"{AppDomain.CurrentDomain.BaseDirectory}Sample/GroupWithBoxes.xml";
            var expected = XDocument.Load(fullpath).ToString();

            builder.CustomUi.Ribbon.Tabs(c =>
            {
                c.AddTab("test").SetId("tab1")
                    .Groups(g =>
                    {
                        g.AddGroup("reporting").SetId("reportingGroup")
                            .Items(i =>
                            {
                                i.AddBox().SetId("ButtonsVertical").VerticalDisplay().AddItems(b =>
                                {
                                    b.AddButton("Allocation")
                                        .SetId("portfolioAllocation")
                                        .LargeSize()
                                        .ImageMso("HappyFace");
                                    b.AddButton("Contributor").SetId("Contributor").LargeSize()
                                        .NoImage().ShowLabel().Supertip("Portfolio best contributor")
                                        .Screentip("Display the top / bottom X contributor to the portfolio performance.");
                                });
                                i.AddBox().SetId("ButtonsHorizontal").HorizontalDisplay().AddItems(b =>
                                {
                                    b.AddButton("Portfolio Analysis")
                                        .SetId("portfolioAnalyser").NormalSize()
                                        .NoImage().ShowLabel();
                                    b.AddButton("Return Analysis")
                                        .SetId("ReturnAnalyser").NormalSize()
                                        .NoImage()
                                        .ShowLabel()
                                        .Description("Analyze the returns of your sample portfolio");
                                });
                            });
                    });
            });

            // Act
            var str = builder.GetXmlString();

            // Assert
            Assert.AreEqual(expected, str);
        }

        [Test]
        public void GroupWithCheckBoxAndLabel()
        {
            // Prepare
            var fullpath = $"{AppDomain.CurrentDomain.BaseDirectory}Sample/GroupWithCheckboxAndLabel.xml";
            var expected = XDocument.Load(fullpath).ToString();

            builder.CustomUi.Ribbon.ContextualTabs(ct => ct.AddTabSet(ts =>
            {
                ts.SetIdMso(TabSetId.TabSetPivotTableTools)
                    .Tabs(
                        c =>
                        {
                            c.AddTab("Internal").SetId("tab1")
                                .Groups(g =>
                                {
                                    g.AddGroup("Print settings").SetId("printSettingsGroup")
                                        .Items(i =>
                                        {
                                            i.AddCheckbox("Center Horizontal").SetId("centerHorizontal")
                                                .Screentip("Center Content Horizontally");
                                            i.AddCheckbox("Center Vertical").SetId("centerVertical")
                                                .Screentip("Center Content Vertically");
                                            i.AddSeparator().SetId("separatorOne");
                                            i.AddCheckbox("Fit To 1 Page Width").SetId("FitToPage")
                                                .Screentip("Fit Content to the page width");
                                            i.AddLabelControl().SetId("printZoomLabel");
                                            i.AddEditbox("Zoom").SetId("printZoomValue").NoImage()
                                                .Screentip("Zooming percentage for printing")
                                                .MaxLength(5).SizeString(5);
                                        });
                                });
                        });
            }));


            // Act
            var str = builder.GetXmlString();

            // Assert
            Assert.AreEqual(expected, str);
        }

        [Test]
        public void GroupWithComboBox()
        {
            // Prepare
            var fullpath = $"{AppDomain.CurrentDomain.BaseDirectory}Sample/GroupWithComboBox.xml";
            var expected = XDocument.Load(fullpath).ToString();


            builder.CustomUi.Ribbon.ContextualTabs(ct => ct.AddTabSet(ts =>
            {
                ts.SetIdMso(TabSetId.TabSetPivotTableTools)
                    .Tabs(
                        c =>
                        {
                            c.AddTab("Internal").SetId("tab1")
                                .Groups(g =>
                                {
                                    g.AddGroup("Extra settings").SetId("extraSettingsGroup")
                                        .Items(i =>
                                        {
                                            i.AddComboBox("Colors").SetId("colorsPicking")
                                                .ShowLabel().NoImage()
                                                .AddItems(o =>
                                                {
                                                    o.AddItem("Green").SetId("greenColor");
                                                    o.AddItem("Red").SetId("redColor").NoImage();
                                                    o.AddItem("Blue").SetId("blueColor").NoImage();
                                                }).Supertip("Color Picking")
                                                .MaxLength(15).SizeString(15);

                                        });

                                    g.AddGroup("Time zone settings").SetId("timeZoneSettingsGroup")
                                        .Items(i =>
                                        {
                                            i.AddComboBox("Country").SetId("countryPicking")
                                                .ShowLabel().NoImage()
                                                .DynamicItems().Supertip("Country Picking")
                                                .Supertip("Pick a country to know its current time")
                                                ;

                                        });
                                });
                        });
            }));


            // Act
            var str = builder.GetXmlString();

            // Assert
            Assert.AreEqual(expected, str);
        }

        [Test]
        public void GroupWithToggleButton()
        {
            // Prepare
            var fullpath = $"{AppDomain.CurrentDomain.BaseDirectory}Sample/GroupWithToggleButton.xml";
            var expected = XDocument.Load(fullpath).ToString();


            builder.CustomUi.Ribbon.Tabs(
                c =>
                {
                    c.AddTab("Internal").SetId("tab1")
                        .Groups(g =>
                        {
                            g.AddGroup("Extra settings").SetId("extraSettingsGroup")
                                .Items(i =>
                                {
                                    i.AddToggleButton("Hide View Tab").SetId("HideViewTab")
                                        .ShowLabel().Large().NoImage().Supertip("Hide View Tab");

                                });
                        });
                });



            // Act
            var str = builder.GetXmlString();

            // Assert
            Assert.AreEqual(expected, str);
        }

        [Test]
        public void GroupWithDropDown()
        {
            // Prepare
            var fullpath = $"{AppDomain.CurrentDomain.BaseDirectory}Sample/GroupWithDropDown.xml";
            var expected = XDocument.Load(fullpath).ToString();


            builder.CustomUi.Ribbon.Tabs(c =>
            {
                c.AddTab("Internal").SetId("tab1")
                    .Groups(g =>
                    {
                        g.AddGroup("Extra settings").SetId("extraSettingsGroup")
                            .Items(i =>
                            {
                                i.AddDropDown("Colors").SetId("ColorsSelection")
                                    .ShowLabel().NoImage().ShowItemLabel()
                                    .HideItemImage()
                                    .AddItems(o =>
                                    {
                                        o.AddItem("Green").SetId("greenColor");
                                        o.AddItem("Red").SetId("redColor").NoImage();
                                        o.AddItem("Blue").SetId("blueColor").NoImage();
                                    }).Supertip("Color Picking");

                            });

                        g.AddGroup("Units Settings").SetId("UnitsSettingsGroup")
                            .Items(i =>
                            {
                                i.AddDropDown("Unit To:").SetId("centimeter2Unit")
                                    .ShowLabel().NoImage().ShowItemLabel().HideItemImage()
                                    .DynamicItems().Supertip("Centimeter Conversion")
                                    .Supertip("Convert centimeters to others units")
                                    ;

                            });
                    });

            });


            // Act
            var str = builder.GetXmlString();

            // Assert
            Assert.AreEqual(expected, str);
        }

        [Test]
        public void GroupWithGallery()
        {
            // Prepare
            var fullpath = $"{AppDomain.CurrentDomain.BaseDirectory}Sample/GroupWithGallery.xml";
            var expected = XDocument.Load(fullpath).ToString();


            builder.CustomUi.Ribbon.Tabs(c =>
            {
                c.AddTab("Internal").SetId("tab1")
                    .Groups(g =>
                    {
                        g.AddGroup("Extra settings").SetId("extraSettingsGroup")
                            .Items(i =>
                            {
                                i.AddGallery("Colors").SetId("ColorsSelection")
                                    .ShowLabel().NormalSize().NoImage().ShowItemLabel()
                                    .HideItemImage()
                                    .AddItems(o =>
                                    {
                                        o.AddItem("Green").SetId("greenColor");
                                        o.AddItem("Red").SetId("redColor").NoImage();
                                        o.AddItem("Blue").SetId("blueColor").NoImage();
                                    }).AddButtons(o =>
                                        o.AddButton("Extra Colors").SetId("ExtraColors")
                                        .ImageMso("HappyFace").ShowLabel()
                                    ).Supertip("Color Picking");

                            });

                        g.AddGroup("Units Settings").SetId("UnitsSettingsGroup")
                            .Items(i =>
                            {
                                i.AddGallery("Unit To:").SetId("centimeter2Unit")
                                    .ShowLabel().NormalSize().NoImage().ShowItemLabel().HideItemImage()
                                    .DynamicItems().Supertip("Centimeter Conversion")
                                    .Supertip("Convert centimeters to others units");
                            });
                    });

            });


            // Act
            var str = builder.GetXmlString();

            // Assert
            Assert.AreEqual(expected, str);
        }

        [Test]
        public void GroupWithMenu()
        {
            // Prepare
            var fullpath = $"{AppDomain.CurrentDomain.BaseDirectory}Sample/GroupWithMenu.xml";
            var expected = XDocument.Load(fullpath).ToString();


            builder.CustomUi.Ribbon.Tabs(c =>
            {
                c.AddTab("Internal").SetId("tab1")
                    .Groups(g =>
                    {
                        g.AddGroup("Extra settings").SetId("extraSettingsGroup")
                            .Items(i =>
                            {
                                i.AddMenu("Options").SetId("optionMenu")
                                    .ShowLabel().NoImage().LargeSize().ItemLargeSize()
                                    .AddItems(l =>
                                    {
                                        l.AddCheckbox("Option 1").SetId("optionsOne")
                                            .Screentip("CheckBox Option");
                                        l.AddButton("Option 2")
                                            .SetId("BoutonOption")
                                            .ImageMso("HappyFace");
                                        l.AddButton("Option 3")
                                            .SetId("BoutonOptionTwo")
                                            .ImageMso("HappyFace");

                                        l.AddSeparator("separatorMenu");
                                        l.AddGallery("Colors").SetId("ColorsSelection")
                                            .ShowLabel().NoImage().ShowItemLabel()
                                            .HideItemImage()
                                            .AddItems(o =>
                                            {
                                                o.AddItem("Green").SetId("greenColor");
                                                o.AddItem("Red").SetId("redColor").NoImage();
                                                o.AddItem("Blue").SetId("blueColor").NoImage();
                                            }).AddButtons(o =>
                                                o.AddButton("Extra Colors").SetId("ExtraColors")
                                                    .NoImage().ShowLabel()
                                            ).Supertip("Color Picking");
                                    });

                            });
                    });

            });


            // Act
            var str = builder.GetXmlString();

            // Assert
            Assert.AreEqual(expected, str);
        }
    }
}
