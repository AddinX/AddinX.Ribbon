using System;
using System.CodeDom;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using NUnit.Framework;


namespace AddinX.Ribbon.Tests {
    public class RibbonXmlTests {

        private XmlSchema GetSchema2007() {
            var basePath = typeof(RibbonXmlTests).Assembly.Location;
            var path = Path.Combine(Path.GetDirectoryName(basePath), "Schemas\\CustomUI_2006.xsd");
            Console.WriteLine("Load Schema " + path);
            using (var reader = File.OpenRead(path)) {
                return XmlSchema.Read(reader, (s, e) => {
                    Console.WriteLine(e);
                });
            }
        }
        private XmlSchema GetSchema2010() {
            var path = Path.GetFullPath("Schemas\\CustomUI14.xsd");
            Console.WriteLine("Load Schema "+path);
            using (var reader = File.OpenRead(path)) {
                return XmlSchema.Read(reader, (s, e) => {
                    Console.WriteLine(e);
                });
            }
        }

        [Test]
        public void TestSchema() {
            var schema = GetSchema2007();
            var schemaSet = new XmlSchemaSet();
            schemaSet.Add(schema);
            schemaSet.Compile();

            //WriteXml(schemaSet.GlobalElements[new XmlQualifiedName("customUI", "http://schemas.microsoft.com/office/2009/07/customui")]);
            foreach (XmlSchemaObject gt in schemaSet.GlobalTypes.Values) {
                //Console.WriteLine(gt);
                   WriteXml(gt);
            }
        }

        private void WriteXml(XmlSchemaObject item) {
            var typeName = item.GetType().Name;
            switch (typeName) {
                case nameof(XmlSchemaAnnotation):
                    Console.WriteLine(item);
                    break;
                case nameof(XmlSchemaAttribute):
                    WriteXml((XmlSchemaAttribute)item);
                    break; 
                case nameof(XmlSchemaAttributeGroup):
                    Console.WriteLine("AttributeGroup " + ((XmlSchemaAttributeGroup) item).Name);
                    break;
                case nameof(XmlSchemaComplexType):
                    WriteXml((XmlSchemaComplexType) item);
                    break;
                case nameof(XmlSchemaSimpleType):
                    Console.WriteLine("SimpleType " + ((XmlSchemaSimpleType)item).Name);
                    break; 
                case nameof(XmlSchemaElement):
                    WriteXml((XmlSchemaElement)item);
                    break;
                case nameof(XmlSchemaGroup):
                    Console.WriteLine(((XmlSchemaGroup)item).Name);
                    break;
                case nameof(XmlSchemaNotation):
                    Console.WriteLine(((XmlSchemaNotation)item).Name);
                    break; 
                default:
                    Console.WriteLine("unknown item " + item);
                    break;
                }
        }

        private void WriteXml(XmlSchemaAttribute attribute) {
            Console.Write("Attribute {0} ", attribute.Name);
        }

        private void WriteXml(XmlSchemaElement element) {
            var spaces = new string(' ', deep);
            Console.Write("{1}Element {0} ", element.Name,spaces);
            WriteXml(element.ElementSchemaType);
        }

        private int deep = 0;
        private void WriteXml(XmlSchemaComplexType complex) {
            deep++;
            try {
                var spaces = new string(' ', deep);
                Console.Write("Comlex {0} ", complex.Name);
                foreach (XmlSchemaAttribute attr in complex.AttributeUses.Values) {
                    //Console.Write("\t" + attr.Name);
                }
                Console.WriteLine();

                if (deep > 10) {
                    return;
                }
                var localElements = GetLocalElements(complex);
                foreach (XmlSchemaObject item in localElements.Values) {
                    WriteXml(item);
                }
            } finally {
                deep--;
            }
        }

        private readonly PropertyInfo _localElementProperty = typeof(XmlSchemaComplexType)
            .GetProperty("LocalElements", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetProperty);

        private XmlSchemaObjectTable GetLocalElements(XmlSchemaComplexType complex) {
            var result = _localElementProperty.GetValue(complex, new object[0]);
            return (XmlSchemaObjectTable) result;
        }
        

        [Test]
        public void ValidateXmlTest() {

            var xdoc = XDocument.Load("Sample/GroupWithButtons.xml");

            

        }
    }
}
