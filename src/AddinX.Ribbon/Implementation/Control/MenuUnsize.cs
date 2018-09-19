﻿using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Control.MenuUnsize;
using AddinX.Ribbon.Contract.Enums;
using AddinX.Ribbon.Implementation.Ribbon;

namespace AddinX.Ribbon.Implementation.Control {
    public class MenuUnsize : Control, IMenuUnsize {
        private string _imageMso;
        private string _imagePath;
        private bool _imageVisible;
        private string _supertip;
        private string _screentip;
        private string _keytip;
        private string _description;
        private bool _showLabel = true;
        private ControlSize _itemSize = ControlSize.normal;

        private readonly IMenuUnsizeControls _controls;

        public MenuUnsize() {
            ElementName = "menu";
            Id = new ElementId();
            _controls = new Controls();
            _imageVisible = false;
        }

        public IMenuUnsize Description(string description) {
            this._description = description;
            return this;
        }

        public IMenuUnsize Supertip(string supertip) {
            this._supertip = supertip;
            return this;
        }

        public IMenuUnsize Keytip(string keytip) {
            this._keytip = keytip;
            return this;
        }

        public IMenuUnsize Screentip(string screentip) {
            this._screentip = screentip;
            return this;
        }

        public IMenuUnsize SetId(string name) {
            Id.SetId(name);
            return this;
        }

        public IMenuUnsize SetIdMso(string name) {
            Id.SetMicrosoftId(name);
            return this;
        }

        public IMenuUnsize SetIdQ(string ns, string name) {
            Id.SetNamespaceId(ns, name);
            return this;
        }

        public IMenuUnsize ImageMso(string name) {
            _imageVisible = true;
            _imageMso = name;
            return this;
        }

        public IMenuUnsize ImagePath(string name) {
            _imageVisible = true;
            _imagePath = name;
            return this;
        }

        public IMenuUnsize NoImage() {
            _imageVisible = false;
            return this;
        }

        public IMenuUnsize ItemNormalSize() {
            _itemSize = ControlSize.normal;
            return this;
        }

        public IMenuUnsize ItemLargeSize() {
            _itemSize = ControlSize.large;
            return this;
        }

        public IMenuUnsize ShowLabel() {
            _showLabel = true;
            return this;
        }

        public IMenuUnsize HideLabel() {
            _showLabel = false;
            return this;
        }

        public IMenuUnsize AddItems(Action<IMenuUnsizeControls> items) {
            items.Invoke(_controls);
            return this;
        }

        protected internal override XElement ToXml(XNamespace ns) {
            var tmpId = (ElementId) Id;

            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                , new XAttribute("label", Label)
                , new XAttribute("showLabel", _showLabel)
                , new XAttribute("itemSize", _itemSize.ToString())
                , _imageVisible
                    ? string.IsNullOrEmpty(_imageMso)
                        ? new XAttribute("image", _imagePath)
                        : new XAttribute("imageMso", _imageMso)
                    : new XAttribute("showImage", "false")
                , new XAttribute("getEnabled", "GetEnabled")
                , new XAttribute("getVisible", "GetVisible")
                , new XAttribute("tag", tmpId.Value)
            );

            if (!string.IsNullOrEmpty(_screentip)) {
                element.Add(new XAttribute("screentip", _screentip));
            }

            if (!string.IsNullOrEmpty(_supertip)) {
                element.Add(new XAttribute("supertip", _supertip));
            }

            if (!string.IsNullOrEmpty(_keytip)) {
                element.Add(new XAttribute("keytip", _keytip));
            }

            if (!string.IsNullOrEmpty(_description)) {
                element.Add(new XAttribute("description", _description));
            }

            if (((AddInList) _controls)?.ToXml(ns) != null) {
                element.Add(((AddInList) _controls).ToXml(ns));
            }

            return element;
        }
    }
}