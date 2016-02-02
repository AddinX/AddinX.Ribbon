using System.Xml.Linq;
using AddinX.Core.Contract;
using AddinX.Core.Implementation.Control;

namespace AddinX.Core.Implementation
{
    public class RibbonBuilder : IRibbonBuilder
    {
        private readonly XNamespace ns;
        protected internal const string CustomUiNamespace = "http://schemas.microsoft.com/office/2009/07/customui";

        public RibbonBuilder()
        {
            CustomUi = new CustomUi();
            ns = XNamespace.Get(CustomUiNamespace);
        }

        public ICustomUi CustomUi { get; }

        public string GetXmlString()
        {
            var doc = new XDocument(new XDeclaration("1.0", "utf-8", null));
            doc.Add(((AddInElement)CustomUi).ToXml(ns));
            return doc.ToString();
        }
    }
}
