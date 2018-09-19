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
            var doc = new XDocument(new XDeclaration("1.0", "utf-8", null));
            doc.Add(((AddInElement) CustomUi).ToXml(_ns));
            return doc.ToString();
        }
    }

    internal static class RibbonXmlBuilderExtensions {

        public static void AddAttribute<T>(this XElement owner, XName attrName,T value,T defaultValue) {
            if (object.Equals(value,defaultValue)) {
                return;
            }
            owner.Add(new XAttribute(attrName,value));
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

        public static void AddAttribute(this XElement owner, XName attrName, string value, object condition) {
            if (condition == null) {
                return;
            }
            owner.Add(new XAttribute(attrName, value));
        }

        public static void AddCallbackAttribute(this XElement owner, string attrName, object condition) {
            var callbackFuncName = Char.ToUpper(attrName[0]) + attrName.Substring(1);
            owner.AddAttribute(attrName,callbackFuncName,condition);
        }
    }

    internal static class RibbonCallback {
        public const string OnAction = "onAction";

        public const string OnActionPressed = "onActionPressed";

        public const string OnChange = "onChange";
        public const string OnActionDropDown = "onActionDropDown";
        public const string GetEnabled = "getEnabled";
        public const string GetVisible = "getVisible";
        public const string GetPressed = "getPressed";
        public const string GetText = "getText";

        public const string GetItemImage = "getItemImage";
        public const string GetItemCount = "getItemCount";
        public const string GetItemId = "getItemId";

        public const string GetItemLabel = "getItemLabel";

        public const string GetItemScreentip = "getItemScreentip";

        public const string GetItemSupertip = "getItemSupertip";

        public const string GetLabel = "getLabel";

        public const string SelectedItemIndex = "selectedItemIndex";

    }
}