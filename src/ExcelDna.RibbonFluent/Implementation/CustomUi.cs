using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Ribbon;
using AddinX.Ribbon.Implementation.Control;

namespace AddinX.Ribbon.Implementation {
    public class CustomUi : AddInElement, ICustomUi {
        private readonly IDictionary<string, string> _privateNamespaces;
        private readonly string _defaultNamespace;

        public IRibbon Ribbon { get; }

        public CustomUi(string defaultNamespace) : base("customUI") {
            _defaultNamespace = defaultNamespace;
            _privateNamespaces = new Dictionary<string, string>();
            Ribbon = new Ribbon.Ribbon();
        }

        protected internal override void SetRegister(ICallbackRigister register) {
            base.SetRegister(register);
            ((AddInElement) Ribbon).SetRegister(register);
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
        public ICustomUi AddNamespace(string letter, string privateNamespace) {
            _privateNamespaces.Add(letter, privateNamespace);
            return this;
        }

        protected internal override XElement ToXml(XNamespace ns) {
            return new XElement(ns + ElementName
                , new XAttribute("onLoad", "OnLoad")
                , new XAttribute("loadImage", "OnLoadImage")
                , new XAttribute("xmlns", _defaultNamespace)
                , _privateNamespaces.Select(
                    x => new XAttribute(XNamespace.Xmlns + x.Key, x.Value))
                , ((AddInElement) Ribbon).ToXml(ns)
            );
        }
    }
}