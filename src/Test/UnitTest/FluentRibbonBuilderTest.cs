using System;
using System.Xml;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Enums;
using AddinX.Ribbon.Implementation;
using AddinX.Ribbon.Implementation.Control;
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
            var expected = XDocument.Load("Sample/GroupWithButtons.xml");
            
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

            // Act
            var str = builder.GetXmlString();
           
            Assert.True(expected.Compare(str,Console.Out));
            // Assert
            //Assert.AreEqual(expected,str);
        }

        [Test]
        public void GroupWithBoxLauncher()
        {
            // Prepare
            var expected = XDocument.Load("Sample/GroupWithDialogBoxLauncher.xml");

            builder.CustomUi.Ribbon.Tabs(c =>
            {
                c.AddTab("test").Id("tab1")
                    .Groups(g =>
                    {
                        g.AddGroup("reporting").Id("reportingGroup")
                            .Items(i =>
                            {
                                i.AddButton("Allocation").Id("portfolioAllocation").LargeSize().ImageMso("HappyFace");
                                i.AddButton("Contributor").Id("Contributor").NormalSize()
                                    .NoImage().ShowLabel().Supertip("Portfolio best contributor")
                                    .Screentip("Display the top / bottom X contributor to the portfolio performance.");
                                
                            }).DialogBoxLauncher(o=> o.AddDialogBoxLauncher().Id("ReportingConfig")
                                .Supertip("Allocation Configuration").Screentip("Configuration panel for the Allocation group"));
                        
                    });
            });

            // Act
            var str = builder.GetXmlString();
            Assert.True(expected.Compare(str, Console.Out));
            // Assert
            //Assert.AreEqual(expected, str);
        }

        [Test]
        public void ContextualTabWithButtons()
        {
            // Prepare
            var expected = XDocument.Load("Sample/ContextualTabWithBoxes.xml");

            builder.CustomUi.Ribbon.ContextualTabs(ct => ct.AddTabSet(ts =>
            {
                ts.IdMso(TabSetId.TabSetPivotTableTools)
                    .Tabs(
                        c =>
                        {
                            c.AddTab("Portfolio").Id("tab1")
                                .Groups(g =>
                                {
                                    g.AddGroup("reporting").Id("reportingGroup")
                                        .Items(i =>
                                        {
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


            // Act
            var str = builder.GetXmlString();
            Assert.True(expected.Compare(str, Console.Out));
            // Assert
            //Assert.AreEqual(expected, str);
        }

        [Test]
        public void GroupWithBoxes()
        {
            // Prepare
            var expected = XDocument.Load("Sample/GroupWithBoxes.xml");

            builder.CustomUi.Ribbon.Tabs(c =>
            {
                c.AddTab("test").Id("tab1")
                    .Groups(g =>
                    {
                        g.AddGroup("reporting").Id("reportingGroup")
                            .Items(i =>
                            {
                                i.AddBox().Id("ButtonsVertical").VerticalDisplay().Items(b =>
                                { 
                                    b.AddButton("Allocation")
                                        .Id("portfolioAllocation")
                                        .LargeSize()
                                        .ImageMso("HappyFace");
                                    b.AddButton("Contributor").Id("Contributor").LargeSize()
                                        .NoImage().ShowLabel().Supertip("Portfolio best contributor")
                                        .Screentip("Display the top / bottom X contributor to the portfolio performance.");
                                });
                                i.AddBox().Id("ButtonsHorizontal").HorizontalDisplay().Items(b =>
                                {
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

            // Act
            var str = builder.GetXmlString();
            Assert.True(expected.Compare(str, Console.Out));
            // Assert
            //Assert.AreEqual(expected, str);
        }

        [Test]
        public void GroupWithCheckBoxAndLabel()
        {
            // Prepare
            var expected = XDocument.Load("Sample/GroupWithCheckboxAndLabel.xml");

            builder.CustomUi.Ribbon.ContextualTabs(ct => ct.AddTabSet(ts =>
            {
                ts.IdMso(TabSetId.TabSetPivotTableTools)
                    .Tabs(
                        c =>
                        {
                            c.AddTab("Internal").Id("tab1")
                                .Groups(g =>
                                {
                                    g.AddGroup("Print settings").Id("printSettingsGroup")
                                        .Items(i =>
                                        {
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


            // Act
            var str = builder.GetXmlString();
            Assert.True(expected.Compare(str, Console.Out));
            // Assert
            //Assert.AreEqual(expected, str);
        }

        [Test]
        public void GroupWithComboBox()
        {
            // Prepare
            var expected = XDocument.Load("Sample/GroupWithComboBox.xml");

            builder.CustomUi.Ribbon.ContextualTabs(ct => ct.AddTabSet(ts =>
            {
                ts.IdMso(TabSetId.TabSetPivotTableTools)
                    .Tabs(
                        c =>
                        {
                            c.AddTab("Internal").Id("tab1")
                                .Groups(g =>
                                {
                                    g.AddGroup("Extra settings").Id("extraSettingsGroup")
                                        .Items(i =>
                                        {
                                            i.AddComboBox("Colors").Id("colorsPicking")
                                                .ShowLabel().NoImage()
                                                .Items(o =>
                                                {
                                                    o.AddItem("Green").Id("greenColor");
                                                    o.AddItem("Red").Id("redColor").NoImage();
                                                    o.AddItem("Blue").Id("blueColor").NoImage();
                                                }).Supertip("Color Picking")
                                                .MaxLength(15).SizeString(15);

                                        });

                                    g.AddGroup("Time zone settings").Id("timeZoneSettingsGroup")
                                        .Items(i =>
                                        {
                                            i.AddComboBox("Country").Id("countryPicking")
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
            Assert.True(expected.Compare(str, Console.Out));
            // Assert
            //Assert.AreEqual(expected, str);
        }

        [Test]
        public void GroupWithToggleButton()
        {
            // Prepare
            var expected = XDocument.Load("Sample/GroupWithToggleButton.xml");

            builder.CustomUi.Ribbon.Tabs(
                c =>
                {
                    c.AddTab("Internal").Id("tab1")
                        .Groups(g =>
                        {
                            g.AddGroup("Extra settings").Id("extraSettingsGroup")
                                .Items(i =>
                                {
                                    i.AddToggleButton("Hide View Tab").Id("HideViewTab")
                                        .ShowLabel().LargeSize().NoImage().Supertip("Hide View Tab");

                                });
                        });
                });
            


            // Act
            var str = builder.GetXmlString();
            Assert.True(expected.Compare(str, Console.Out));
            // Assert
            //Assert.AreEqual(expected, str);
        }

        [Test]
        public void GroupWithDropDown()
        {
            // Prepare
            var expected = XDocument.Load("Sample/GroupWithDropDown.xml");

            builder.CustomUi.Ribbon.Tabs(c =>
            {
                c.AddTab("Internal").Id("tab1")
                    .Groups(g =>
                    {
                        g.AddGroup("Extra settings").Id("extraSettingsGroup")
                            .Items(i =>
                            {
                                i.AddDropDown("Colors").Id("ColorsSelection")
                                    .ShowLabel().NoImage().ShowItemLabel()
                                    .HideItemImage()
                                    .Items(o =>
                                    {
                                        o.AddItem("Green").Id("greenColor");
                                        o.AddItem("Red").Id("redColor").NoImage();
                                        o.AddItem("Blue").Id("blueColor").NoImage();
                                    }).Supertip("Color Picking");

                            });

                        g.AddGroup("Units Settings").Id("UnitsSettingsGroup")
                            .Items(i =>
                            {
                                i.AddDropDown("Unit To:").Id("centimeter2Unit")
                                    .ShowLabel().NoImage().ShowItemLabel().HideItemImage()
                                    .DynamicItems().Supertip("Centimeter Conversion")
                                    .Supertip("Convert centimeters to others units")
                                    ;

                            });
                    });

            });


            // Act
            var str = builder.GetXmlString();
            Assert.True(expected.Compare(str, Console.Out));
            // Assert
            //Assert.AreEqual(expected, str);
        }

        [Test]
        public void GroupWithGallery()
        {
            // Prepare
            var expected = XDocument.Load("Sample/GroupWithGallery.xml");

            builder.CustomUi.Ribbon.Tabs(c =>
            {
                c.AddTab("Internal").Id("tab1")
                    .Groups(g =>
                    {
                        g.AddGroup("Extra settings").Id("extraSettingsGroup")
                            .Items(i =>
                            {
                                i.AddGallery("Colors").Id("ColorsSelection")
                                    .ShowLabel().NormalSize().NoImage().ShowItemLabel()
                                    .HideItemImage()
                                    .Items(o =>
                                    {
                                        o.AddItem("Green").Id("greenColor");
                                        o.AddItem("Red").Id("redColor").NoImage();
                                        o.AddItem("Blue").Id("blueColor").NoImage();
                                    }).Buttons(o=>
                                        o.AddButton("Extra Colors").Id("ExtraColors")
                                        .ImageMso("HappyFace") .ShowLabel()
                                    ).Supertip("Color Picking");

                            });

                        g.AddGroup("Units Settings").Id("UnitsSettingsGroup")
                            .Items(i =>
                            {
                                i.AddGallery("Unit To:").Id("centimeter2Unit")
                                    .ShowLabel().NormalSize().NoImage().ShowItemLabel().HideItemImage()
                                    .DynamicItems().Supertip("Centimeter Conversion")
                                    .Supertip("Convert centimeters to others units");
                            });
                    });

            });


            // Act
            var str = builder.GetXmlString();
            Assert.True(expected.Compare(str, Console.Out));
            // Assert
            //Assert.AreEqual(expected, str);
        }

        [Test]
        public void GroupWithMenu()
        {
            // Prepare
            var expected = XDocument.Load("Sample/GroupWithMenu.xml");

            builder.CustomUi.Ribbon.Tabs(c =>
            {
                c.AddTab("Internal").Id("tab1")
                    .Groups(g =>
                    {
                        g.AddGroup("Extra settings").Id("extraSettingsGroup")
                            .Items(i =>
                            {
                                i.AddMenu("Options").Id("optionMenu")
                                    .ShowLabel().NoImage().LargeSize().ItemLargeSize()
                                    .Items(l =>
                                    {
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
                                            .Items(o =>
                                            {
                                                o.AddItem("Green").Id("greenColor");
                                                o.AddItem("Red").Id("redColor").NoImage();
                                                o.AddItem("Blue").Id("blueColor").NoImage();
                                            }).Buttons(o =>
                                                o.AddButton("Extra Colors").Id("ExtraColors")
                                                    .NoImage().ShowLabel()
                                            ).Supertip("Color Picking");
                                    });

                            });
                    });

            });

            // Act
            var str = builder.GetXmlString();
            Assert.IsTrue(ValidateHelper.Validate(str));

            Assert.True(expected.Compare(str, Console.Out));
            // Assert
            //Assert.AreEqual(expected, str);
        }
    }
}
