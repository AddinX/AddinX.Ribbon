using System;
using System.Linq;
using System.Xml.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Validation;

namespace ExcelDna.RibbonFluent.Tests {
    public static class ValidateHelper {

        public static bool Validate(string xmlStr) {
            var xml = XDocument.Parse(xmlStr);
            var validator = new OpenXmlValidator(FileFormatVersions.Office2010);
            var errors = validator.Validate(new DocumentFormat.OpenXml.Office2010.CustomUI.CustomUI(xmlStr));
            if (errors != null && errors.Any()) {
                foreach (var info in errors) {
                    Console.WriteLine($"{info.Id} {info.Description} {info.Node.OuterXml}  {info.ErrorType} \tPath:{info.Path?.XPath}");
                }
            }

            return !errors.Any();
        }

        public static bool Validate2010(string xmlStr) {
            var xml = XDocument.Parse(xmlStr);
            var validator = new OpenXmlValidator(FileFormatVersions.Office2010);
            var errors = validator.Validate(new DocumentFormat.OpenXml.Office2010.CustomUI.CustomUI(xmlStr));
            if (errors != null && errors.Any()) {
                foreach (var info in errors) {
                    Console.WriteLine(info);
                }
            }

            return !errors.Any();
        }

        public static bool Validate2007(string xmlStr) {
            var xml = XDocument.Parse(xmlStr);
            var validator = new OpenXmlValidator(FileFormatVersions.Office2007);
            var errors = validator.Validate(new DocumentFormat.OpenXml.Office.CustomUI.CustomUI(xmlStr));
            if (errors != null && errors.Any()) {
                foreach (var info in errors) {
                    Console.WriteLine(info);
                }
            }

            return !errors.Any();
        }
    }
}