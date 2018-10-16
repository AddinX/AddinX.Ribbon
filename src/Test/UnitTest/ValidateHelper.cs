using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Office.CustomUI;
using DocumentFormat.OpenXml.Validation;

namespace AddinX.Ribbon.UnitTest {
    public static class ValidateHelper {

        public static bool Validate(string xmlStr) {
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

        public static bool Compare(this XDocument expresed, string target, TextWriter log) {
            var targetXml = XDocument.Parse(target);
            return expresed.Root.Compare(targetXml.Root, log);
        }

        public static bool Compare(this XElement expresed, XElement target,TextWriter log,int indent = 0) {
            var indentStr = new string(' ',indent*2);
            if (target == null) {
                log.WriteLine($"target Element is null,{expresed.Name}");
                return false;
            }
            if (expresed.Name != target.Name) {
                log.WriteLine($"Element Name Not equal,{expresed.Name}");
                return false;
            }
            log.WriteLine($"{indentStr}TAG:{expresed.Name.LocalName}");

            if (expresed.HasAttributes) {
                foreach (var att in expresed.Attributes()) {
                    var targetAttr = target.Attribute(att.Name);
                    if (targetAttr == null) {
                        log.WriteLine($"{indentStr}\tAttribute not existed,{att.Name}");
                        //return false;
                        continue;
                    }

                    if (att.Value != targetAttr.Value) {
                        log.WriteLine($"{indentStr}\tAttribute '{att.Name}' not equal,{att.Value}:{targetAttr.Value}");
                        //return false;
                    }
                }
            }

            if (expresed.HasElements) {
                foreach (var element in expresed.Elements()) {
                    var targetElement = target.Element(element.Name);
                    if (targetElement == null) {
                        log.WriteLine($"{indentStr}target Element {element.Name} not existed");
                        return false;
                    }

                    var result = element.Compare(targetElement,log,indent+1);
                    if (!result) {
                        //return false;
                    }
                }
            }

            return true;

        }
    }
}