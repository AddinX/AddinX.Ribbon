using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Implementation.Control;

namespace AddinX.Ribbon.Implementation {
    public class RibbonBuilder : IRibbonBuilder {
        private readonly XNamespace _ns;
        private const string CustomUiNamespace = "http://schemas.microsoft.com/office/2009/07/customui";

        public RibbonBuilder() : this(CustomUiNamespace) {
        }

        public RibbonBuilder(string customUiNamespace) {
            CustomUi = new CustomUi(customUiNamespace);
            _ns = XNamespace.Get(customUiNamespace);
        }

        public ICustomUi CustomUi { get; }

        public string GetXmlString() {
            if (CallbackRigister == null) {
                CallbackRigister = new RibbonCommands();
            }

            ((AddInElement) CustomUi).SetRegister(CallbackRigister);
            var doc = new XDocument(new XDeclaration("1.0", "utf-8", null));
            doc.Add(((AddInElement) CustomUi).ToXml(_ns));
            return doc.ToString();
        }

        #region Implementation of ICallbackRigister

        public ICallbackRigister CallbackRigister { get; set; }

        #endregion
    }

    internal static class RibbonXmlBuilderExtensions {
        public static void AddAttribute<T>(this XElement owner, XName attrName, T value, T defaultValue) {
            if (Equals(value, defaultValue)) {
                return;
            }

            owner.Add(new XAttribute(attrName, value));
        }

        public static void AddImageAttribute(this XElement owner, bool imageVisible, string imagePath,
            string imageMso) {
            if (imageVisible) {
                owner.AddAttribute("image", imagePath);
                owner.AddAttribute("imageMso", imageMso);
            } else {
                owner.AddAttribute("showImage", false);
            }
        }

        public static void AddAttribute(this XElement owner, XName attrName, string value) {
            if (string.IsNullOrEmpty(value)) {
                return;
            }

            owner.Add(new XAttribute(attrName, value));
        }

        public static void AddAttribute(this XElement owner, XName attrName, object value) {
            if (value == null) {
                return;
            }

            owner.Add(new XAttribute(attrName, value));
        }

        public static void AddAttribute<T>(this XElement owner, XName attrName, T value) {
            if (value == null || Equals(value, default(T))) {
                return;
            }

            owner.Add(new XAttribute(attrName, value));
        }

        private static void AddAttribute(this XElement owner, XName attrName, string value, object condition) {
            if (condition == null) {
                return;
            }

            owner.Add(new XAttribute(attrName, value));
        }

        public static void AddCallbackAttribute(this XElement owner, string attrName, object condition) {
            var callbackFuncName = Char.ToUpper(attrName[0]) + attrName.Substring(1);
            owner.AddAttribute(attrName, callbackFuncName, condition);
        }

        public static void AddCallbackAttribute(this XElement owner, string attrName, string callbackFuncName,
            object condition) {
            owner.AddAttribute(attrName, callbackFuncName, condition);
        }
    }
}