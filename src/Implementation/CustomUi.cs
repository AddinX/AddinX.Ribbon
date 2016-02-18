using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AddinX.Core.Contract;
using AddinX.Core.Contract.Ribbon;
using AddinX.Core.Implementation.Control;

namespace AddinX.Core.Implementation
{
    public class CustomUi : AddInElement, ICustomUi
    {
        private readonly IDictionary<string, string> privateNamespaces;
        public IRibbon Ribbon { get; }

        public CustomUi()
        {
            ElementName = "customUI";
            privateNamespaces = new Dictionary<string, string>();
            Ribbon = new Ribbon.Ribbon();
        }

        /// <summary>
        /// Adding a private name-space can help you to share the same groups or tab between two or more distinct add-ins
        /// </summary>
        /// <param name="letter">letter that will identify the name-space</param>
        /// <param name="privateNamespace">the name-space that will be used </param>
        /// <returns>this object</returns>
        /// <example>
        /// Define the following name-space: <code>x="myNameSpace"</code>
        /// Then it will be possible to use it when defining the idQ of the tab or group 
        /// <code><group idQ="x:Contoso" label="Contoso"/></code>
        /// </example>
        public ICustomUi AddNamespace(string letter, string privateNamespace)
        {
            privateNamespaces.Add(letter, privateNamespace);
            return this;
        }

        protected internal override XElement ToXml(XNamespace ns)
        {
            return new XElement(ns + ElementName
                 , new XAttribute("onLoad", "OnLoad")
                 , new XAttribute("loadImage", "OnLoadImage")
                 , new XAttribute("xmlns", RibbonBuilder.CustomUiNamespace)
                 , privateNamespaces.Select(
                       x => new XAttribute(XNamespace.Xmlns + x.Key, x.Value))
                 , ((AddInElement)Ribbon).ToXml(ns)
                );
        }
    }
}