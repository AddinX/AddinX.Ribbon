﻿using System;
using System.Xml.Linq;
using AddinX.Core.Contract.Control.Box;
using AddinX.Core.Contract.Enums;
using AddinX.Core.Implementation.Ribbon;

namespace AddinX.Core.Implementation.Control
{
    public class BoxUi : ControlUi, IBoxUi
    {
        private readonly IBoxControlsUi items;
        private BoxStyle style;

        public BoxUi()
        {
            items = new ControlsUi();
            ElementName = "box";
            Id = new ElementId();
        }

        public IBoxStyle SetId(string name)
        {
            Id.SetId(name);
            return this;
        }

        public IBoxStyle SetIdQ(string ns, string name)
        {
            Id.SetNamespaceId(ns, name);
            return this;
        }

        public IBoxItems HorizontalDisplay()
        {
            style = BoxStyle.horizontal;
            return this;
        }

        public IBoxItems VerticalDisplay()
        {
            style = BoxStyle.vertical;
            return this;
        }

        public void AddItems(Action<IBoxControlsUi> items)
        {
            items.Invoke(this.items);
        }

        protected internal override XElement ToXml(XNamespace ns)
        {
            var tmpId = (ElementId) Id;
            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                , new XAttribute("getVisible", "GetVisible")
                , new XAttribute("boxStyle", style.ToString())
                );

            if (((AddInList) items)?.ToXml(ns) != null)
            {
                element.Add(((AddInList) items).ToXml(ns));
            }
            return element;
        }
    }
}