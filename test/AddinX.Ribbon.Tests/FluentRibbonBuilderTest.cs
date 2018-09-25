using System;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Enums;
using AddinX.Ribbon.Implementation;
using AddinX.Ribbon.Implementation.Control;
using AddinX.Ribbon.Tests;
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
                c.AddTab("test").SetId("tab1")
                    .Groups(g=>
                    {
                        g.AddGroup("reporting").SetId("reportingGroup")
                            .AddItems(i =>
                            {
                                i.AddButton("Allocation").SetId("portfolioAllocation").LargeSize().ImageMso("HappyFace");
                                i.AddButton("Contributor").SetId("Contributor").NormalSize()
                                    .NoImage().ShowLabel().Supertip("Portfolio best contributor")
                                    .Screentip("Display the top / bottom X contributor to the portfolio performance.");
                                
                            });
                        g.AddGroup("Analytic").SetId("AnalyticGroup")
                            .AddItems(i => i.AddButton("Portfolio Analysis").SetId("portfolioAnalyser").NormalSize()
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
                c.AddTab("test").SetId("tab1")
                    .Groups(g => {
                        g.AddGroup("reporting").SetId("reportingGroup")
                            .AddItems(i => {
                                i.AddButton("Allocation").SetId("portfolioAllocation").LargeSize()
                                    .ImageMso("HappyFace");
                                i.AddButton("Contributor").SetId("Contributor").NormalSize()
                                    .NoImage().ShowLabel().Supertip("Portfolio best contributor")
                                    .Screentip("Display the top / bottom X contributor to the portfolio performance.");

                            }).DialogBoxLauncher(o => o.AddDialogBoxLauncher().SetId("ReportingConfig")
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
                ts.SetIdMso(TabSetId.TabSetPivotTableTools)
                    .Tabs(
                        c => {
                            c.AddTab("Portfolio").SetId("tab1")
                                .Groups(g => {
                                    g.AddGroup("reporting").SetId("reportingGroup")
                                        .AddItems(i => {
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
                                        .AddItems(
                                            i =>
                                                i.AddButton("Portfolio Analysis")
                                                    .SetId("portfolioAnalyser")
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
                c.AddTab("test").SetId("tab1")
                    .Groups(g => {
                        g.AddGroup("reporting").SetId("reportingGroup")
                            .AddItems(i => {
                                i.AddBox().SetId("ButtonsVertical").VerticalDisplay().AddItems(b => {
                                    b.AddButton("Allocation")
                                        .SetId("portfolioAllocation")
                                        .LargeSize()
                                        .ImageMso("HappyFace");
                                    b.AddButton("Contributor").SetId("Contributor").LargeSize()
                                        .NoImage().ShowLabel().Supertip("Portfolio best contributor")
                                        .Screentip(
                                            "Display the top / bottom X contributor to the portfolio performance.");
                                });
                                i.AddBox().SetId("ButtonsHorizontal").HorizontalDisplay().AddItems(b => {
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

            AssertXml(expected, builder);
        }

        [Test]
        public void GroupWithCheckBoxAndLabel() {
            // Prepare
            var expected = "Sample/GroupWithCheckboxAndLabel.xml";

            builder.CustomUi.Ribbon.ContextualTabs(ct => ct.AddTabSet(ts => {
                ts.SetIdMso(TabSetId.TabSetPivotTableTools)
                    .Tabs(
                        c => {
                            c.AddTab("Internal").SetId("tab1")
                                .Groups(g => {
                                    g.AddGroup("Print settings").SetId("printSettingsGroup")
                                        .AddItems(i => {
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


            AssertXml(expected, builder);
        }

        [Test]
        public void GroupWithComboBox() {
            // Prepare
            var expected = "Sample/GroupWithComboBox.xml";

            builder.CustomUi.Ribbon.ContextualTabs(ct => ct.AddTabSet(ts => {
                ts.SetIdMso(TabSetId.TabSetPivotTableTools)
                    .Tabs(
                        c => {
                            c.AddTab("Internal").SetId("tab1")
                                .Groups(g => {
                                    g.AddGroup("Extra settings").SetId("extraSettingsGroup")
                                        .AddItems(i => {
                                            i.AddComboBox("Colors").SetId("colorsPicking")
                                                .ShowLabel().NoImage()
                                                .AddItems(o => {
                                                    o.AddItem("Green").SetId("greenColor");
                                                    o.AddItem("Red").SetId("redColor").NoImage();
                                                    o.AddItem("Blue").SetId("blueColor").NoImage();
                                                }).Supertip("Color Picking")
                                                .MaxLength(15).SizeString(15);
                                        });

                                    g.AddGroup("Time zone settings").SetId("timeZoneSettingsGroup")
                                        .AddItems(i => {
                                            i.AddComboBox("Country").SetId("countryPicking")
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
                    c.AddTab("Internal").SetId("tab1")
                        .Groups(g => {
                            g.AddGroup("Extra settings").SetId("extraSettingsGroup")
                                .AddItems(i => {
                                    i.AddToggleButton("Hide View Tab").SetId("HideViewTab")
                                        .ShowLabel().LargeSize()
                                        .NoImage().Supertip("Hide View Tab")
                                        .Callback(cmd => {
                                            cmd.onActionPressed = Console.WriteLine;
                                            cmd.getPressed = () => true;
                                        });
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
                c.AddTab("Internal").SetId("tab1")
                    .Groups(g => {
                        g.AddGroup("Extra settings").SetId("extraSettingsGroup")
                            .AddItems(i => {
                                i.AddDropDown("Colors").SetId("ColorsSelection")
                                    .ShowLabel().NoImage().ShowItemLabel()
                                    .HideItemImage()
                                    .AddItems(o => {
                                        o.AddItem("Green").SetId("greenColor");
                                        o.AddItem("Red").SetId("redColor").NoImage();
                                        o.AddItem("Blue").SetId("blueColor").NoImage();
                                    }).Supertip("Color Picking");
                            });

                        g.AddGroup("Units Settings").SetId("UnitsSettingsGroup")
                            .AddItems(i => {
                                i.AddDropDown("Unit To:").SetId("centimeter2Unit")
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
                c.AddTab("Internal").SetId("tab1")
                    .Groups(g => {
                        g.AddGroup("Extra settings").SetId("extraSettingsGroup")
                            .AddItems(i => {
                                i.AddGallery("Colors").SetId("ColorsSelection")
                                    .ShowLabel().NormalSize().NoImage().ShowItemLabel()
                                    .HideItemImage()
                                    .AddItems(o => {
                                        o.AddItem("Green").SetId("greenColor");
                                        o.AddItem("Red").SetId("redColor").NoImage();
                                        o.AddItem("Blue").SetId("blueColor").NoImage();
                                    }).AddButtons(o =>
                                        o.AddButton("Extra Colors").SetId("ExtraColors")
                                            .ImageMso("HappyFace").ShowLabel()
                                    ).Supertip("Color Picking");
                            });

                        g.AddGroup("Units Settings").SetId("UnitsSettingsGroup")
                            .AddItems(i => {
                                i.AddGallery("Unit To:").SetId("centimeter2Unit")
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
                c.AddTab("Internal").SetId("tab1")
                    .Groups(g => {
                        g.AddGroup("Extra settings").SetId("extraSettingsGroup")
                            .AddItems(i => {
                                i.AddMenu("Options").SetId("optionMenu")
                                    .ShowLabel().NoImage().LargeSize().ItemLargeSize()
                                    .AddItems(l => {
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
                                            .AddItems(o => {
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

            AssertXml(expected, builder);
        }

    }

    public class XmlValidateTest {
        public const string NamespaceCustomUI2010 = "http://schemas.microsoft.com/office/2009/07/customui";
        public const string NamespaceCustomUI2007 = "http://schemas.microsoft.com/office/2006/01/customui";

        private string GetFullPath(string path) {
            var basePath = typeof(FluentRibbonBuilderTest).Assembly.Location;
            return Path.Combine(Path.GetDirectoryName(basePath), path);
        }

        private XmlSchema GetSchema2007() {
            using (var reader = File.OpenRead(GetFullPath("Schemas\\CustomUI_2006.xsd"))) {
                return XmlSchema.Read(reader, (s, e) => {
                    Console.WriteLine(e);
                });
            }
        }
        private XmlSchema GetSchema2010() {
            using (var reader = File.OpenRead(GetFullPath("Schemas\\CustomUI14.xsd"))) {
                return XmlSchema.Read(reader, (s, e) => {
                    Console.WriteLine(e);
                });
            }
        }

        [Test]
        public void Validate2010() {
            var builder = new RibbonBuilder(NamespaceCustomUI2010);
            BuildUi(builder);
            var xdoc = XDocument.Parse(builder.GetXmlString());
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add(GetSchema2010());
            xdoc.Validate(schemas, (s, e) => {
                Console.WriteLine(e);
            } );
        }

        [Test]
        public void Validate2007() {
            var builder = new RibbonBuilder(NamespaceCustomUI2007);
            BuildUi(builder);
            var xdoc = XDocument.Parse(builder.GetXmlString());
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add(GetSchema2007());
            xdoc.Validate(schemas, (s, e) => {
                Console.WriteLine(e);
            });
            Console.WriteLine(xdoc.ToString(SaveOptions.OmitDuplicateNamespaces));

            Assert.IsTrue(ValidateHelper.Validate2007(builder.GetXmlString()));
        }

        private const string BookmarksComboId = "bookmarksCombo";
        private const string BookmarksDropDownId = "BookmarksDropDownId";
        private const string MyTabId = "MyTabId";
        private const string DataGroupId = "DataGroupId";
        private const string ButtonMore = "buttonMore";
        private const string ToggleButtonId = "ToggleButtonId";

        private void BuildUi(RibbonBuilder builder) {
            builder.CustomUi.AddNamespace("acme", "acme.addin.sync").Ribbon.Tabs(c => {
                c.AddTab("My Tab").SetIdQ("acme", MyTabId)
                    .Groups(g => {
                        g.AddGroup("Data").SetIdQ("acme", DataGroupId)
                            .AddItems(d => {
                                d.AddButton("My Save").SetIdMso("FileSave")
                                    .NormalSize().ImageMso("FileSave");
                                d.AddButton("Button").SetId("buttonOne");
                                d.AddComboBox("numbers")
                                    .SetId(BookmarksComboId)
                                    .ShowLabel().NoImage()
                                    .DynamicItems();

                                d.AddDropDown("With Image")
                                    .SetId(BookmarksDropDownId)
                                    .ShowLabel().NoImage()
                                    .ShowItemLabel().ShowItemImage().DynamicItems()
                                    .AddButtons(b => b.AddButton("Button...").SetId(ButtonMore));
                                d.AddToggleButton("Toggle Button")
                                    .SetId(ToggleButtonId);
                            });

                    });
            });
        }
    }
}
