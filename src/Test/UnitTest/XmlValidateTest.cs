using System;
using System.IO;
using System.Xml.Linq;
using System.Xml.Schema;
using AddinX.Ribbon.Implementation;
using NUnit.Framework;

namespace AddinX.Ribbon.UnitTest {
    public class XmlValidateTest {
        public const string NamespaceCustomUI2010 = "http://schemas.microsoft.com/office/2009/07/customui";
        public const string NamespaceCustomUI2007 = "http://schemas.microsoft.com/office/2006/01/customui";


        private XmlSchema GetSchema2007() {
            using (var reader = File.OpenRead("Schemas\\CustomUI_2006.xsd")) {
                return XmlSchema.Read(reader, (s, e) => {
                    Console.WriteLine(e);
                });
            }
        }
        private XmlSchema GetSchema2010() {
            using (var reader = File.OpenRead("Schemas\\CustomUI14.xsd")) {
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
                c.AddTab("My Tab").IdQ("acme", MyTabId)
                    .Groups(g => {
                        g.AddGroup("Data").IdQ("acme", DataGroupId)
                            .Items(d => {
                                d.AddButton("My Save").IdMso("FileSave")
                                    .NormalSize().ImageMso("FileSave");
                                d.AddButton("Button").Id("buttonOne");
                                d.AddComboBox("numbers")
                                    .Id(BookmarksComboId)
                                    .ShowLabel().NoImage()
                                    .DynamicItems();

                                d.AddDropDown("With Image")
                                    .Id(BookmarksDropDownId)
                                    .ShowLabel().NoImage()
                                    .ShowItemLabel().ShowItemImage().DynamicItems()
                                    .Buttons(b => b.AddButton("Button...").Id(ButtonMore));
                                d.AddToggleButton("Toggle Button")
                                    .Id(ToggleButtonId);
                            });

                    });
            });
        }
    }
}