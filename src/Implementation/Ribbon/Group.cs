using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Control;
using AddinX.Ribbon.Contract.Ribbon.Group;
using AddinX.Ribbon.Implementation.Control;

namespace AddinX.Ribbon.Implementation.Ribbon
{
    public class Group : AddInElement, IGroup
    {
        private IElementId id;
        private readonly IGroupControls controls;
        private IGroupDialogBox boxLauncher;

        private string label;
        private string supertip;
        private string screentip;
        private string keytip;


        public Group()
        {
            ElementName = "group";
            id = new ElementId();
            controls = new Controls();
        }

        protected internal Group SetLabel(string value)
        {
            label = value;
            return this;
        }

        public IGroupExtra Items(Action<IGroupControls> value)
        {
            value.Invoke(controls);
            return this;
        }


        protected internal override XElement ToXml(XNamespace ns)
        {
            var tmpId = (ElementId) id;

            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                , new XAttribute("label", label)
                , new XAttribute("getVisible", "GetVisible")
                );

            if (((AddInList) controls)?.ToXml(ns) != null)
            {
                element.Add(((AddInList) controls).ToXml(ns));
            }
            
            if (!string.IsNullOrEmpty(screentip))
            {
                element.Add(new XAttribute("screentip", screentip));
            }

            if (!string.IsNullOrEmpty(supertip))
            {
                element.Add(new XAttribute("supertip", supertip));
            }

            if (!string.IsNullOrEmpty(keytip))
            {
                element.Add(new XAttribute("keytip", keytip));
            }

            if (boxLauncher != null)
            {
                element.Add(
                    ((AddInList) boxLauncher).ToXml(ns));
            }

            return element;
        }

        public IGroupItems SetId(string name)
        {
            id = new ElementId().SetId(name);
            return this;
        }

        public IGroupItems SetIdMso(string name)
        {
            id = new ElementId().SetMicrosoftId(name);
            return this;
        }

        public IGroupItems SetIdQ(string ns, string name)
        {
            id = new ElementId().SetNamespaceId(ns, name);
            return this;
        }
        
        public IGroupExtra Supertip(string supertip)
        {
            this.supertip = supertip;
            return this;
        }

        public IGroupExtra Keytip(string keytip)
        {
            this.keytip = keytip;
            return this;
        }

        public IGroupExtra Screentip(string screentip)
        {
            this.screentip = screentip;
            return this;
        }

        public IGroupExtra DialogBoxLauncher(Action<IGroupDialogBox> dialogBox)
        {
            boxLauncher = new Controls();
            dialogBox.Invoke(boxLauncher);
            return this;
        }
    }
}