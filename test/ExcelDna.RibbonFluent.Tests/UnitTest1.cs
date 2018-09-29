using System;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using NUnit.Framework;

namespace ExcelDna.RibbonFluent.Tests {
    public class RibbonXmlTests {

        private string GetLocalPath(string path) {
            var basePath = typeof(RibbonXmlTests).Assembly.Location;
            return Path.Combine(Path.GetDirectoryName(basePath), path);
        }

        private XmlSchema GetSchema2007() {
            var path = GetLocalPath("Schemas\\CustomUI_2006.xsd");
            Console.WriteLine("Load Schema " + path);
            using (var reader = File.OpenRead(path)) {
                return XmlSchema.Read(reader, (s, e) => {
                    Console.WriteLine(e);
                });
            }
        }
        private XmlSchema GetSchema2010() {
            var path = GetLocalPath("Schemas\\CustomUI14.xsd");
            Console.WriteLine("Load Schema "+path);
            using (var reader = File.OpenRead(path)) {
                return XmlSchema.Read(reader, (s, e) => {
                    Console.WriteLine(e);
                });
            }
        }

        [Test]
        public void TestSchema() {
            var schema = GetSchema2010(); //GetSchema2007();
            var schemaSet = new XmlSchemaSet();
            schemaSet.Add(schema);
            schemaSet.Compile();

            //WriteXml(schemaSet.GlobalElements[new XmlQualifiedName("customUI", "http://schemas.microsoft.com/office/2009/07/customui")]);
            var ns = schema.Namespaces.ToArray()[0].Namespace;
           var ctbutton = schemaSet.GlobalTypes[new XmlQualifiedName("CT_LabelControl", ns)];

            WriteAttribute(schemaSet, ctbutton);
           
        }

        private void WriteAttribute(XmlSchemaSet schema, XmlSchemaObject target) {
            if (target is XmlSchemaComplexType complex) {
                Console.WriteLine("Complex " + complex.Name);
                if (complex.Parent != null && complex.Parent.Parent!=null) {
                    Console.WriteLine(" Parent " + complex.Parent);
                    return;
                }

                foreach (XmlSchemaAttribute item in complex.AttributeUses.Values) {
                    //Console.WriteLine($"\t{i++}:\t{item.Name}\t{GetAttribeType(schema,item.AttributeSchemaType)}\t{item.Use}\t{item.DefaultValue}");
                    if (item.Parent is XmlSchemaAttributeGroup group) {
                        Console.WriteLine($"\t//attrGroup: {group.Name} {item.AttributeSchemaType.Datatype}");
                    }
                    Console.WriteLine($"private const string tag_{item.Name}=\"{item.Name}\";");
                }
            }
        }

        private string GetAttribeType(XmlSchemaSet schema,XmlSchemaSimpleType simpleType) {
            if (simpleType == null) {
                return string.Empty;
            }
            switch (simpleType.TypeCode) {
                case XmlTypeCode.NCName:
                    return simpleType.QualifiedName.ToString(); //schema.GlobalTypes[simpleType.QualifiedName].ToString();
                default:
                    return simpleType.TypeCode.ToString();
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

        private void WriteXml(XmlSchemaType elementElementSchemaType) {
            throw new NotImplementedException();
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

        private void WriteXml(XmlSchemaObject elementElementSchemaType) {
            throw new NotImplementedException();
        }

        private readonly PropertyInfo _localElementProperty = typeof(XmlSchemaComplexType)
            .GetProperty("LocalElements", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetProperty);

        private XmlSchemaObjectTable GetLocalElements(XmlSchemaComplexType complex) {
            var result = _localElementProperty.GetValue(complex, new object[0]);
            return (XmlSchemaObjectTable) result;
        }
    }
}
