﻿using System.Xml.Linq;
using AddinX.Ribbon.Contract.Control.Item;

namespace AddinX.Ribbon.Implementation.Control {
    public class Item : Control, IItem {
        private string _imageMso;
        private string _imagePath;
        private bool _imageVisible;
        private string _supertip;
        private string _screentip;

        public Item() {
            ElementName = "item";
            Id = new ElementId();
            _imageVisible = false;
        }

        protected internal override XElement ToXml(XNamespace ns) {
            var tmpId = (ElementId) Id;

            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                , new XAttribute("label", Label)
            );

            if (_imageVisible) {
                element.Add(string.IsNullOrEmpty(_imageMso)
                    ? new XAttribute("image", _imagePath)
                    : new XAttribute("imageMso", _imageMso));
            }

            if (!string.IsNullOrEmpty(_screentip)) {
                element.Add(new XAttribute("screentip", _screentip));
            }

            if (!string.IsNullOrEmpty(_supertip)) {
                element.Add(new XAttribute("supertip", _supertip));
            }

            return element;
        }

        public IItemImage SetId(string name) {
            Id.SetId(name);
            return this;
        }

        public IItemExtra ImageMso(string name) {
            _imageVisible = true;
            _imageMso = name;
            return this;
        }

        public IItemExtra ImagePath(string name) {
            _imageVisible = true;
            _imagePath = name;
            return this;
        }

        public IItemExtra NoImage() {
            _imageVisible = false;
            return this;
        }

        public IItemExtra Supertip(string supertip) {
            this._supertip = supertip;
            return this;
        }

        public IItemExtra Screentip(string screentip) {
            this._screentip = screentip;
            return this;
        }
    }
}