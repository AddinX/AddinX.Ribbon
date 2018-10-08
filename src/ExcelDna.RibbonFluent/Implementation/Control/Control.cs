using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Control;
using AddinX.Ribbon.Contract.Enums;
using AddinX.Ribbon.Implementation.Command;

namespace AddinX.Ribbon.Implementation.Control {
    public abstract class Control : AddInElement {
        protected IElementId ControlId { get; }

        private ICommand _command;

        protected Control(string elementName) : base(elementName) {
            ControlId = new ElementId();
        }

        protected internal void SetLabel(string label) {
            base.SetAttribute("label", label);
        }

        protected TCmd GetCommand<TCmd>() where TCmd : ICommand, new() {
            if (_command == null) {
                _command = new TCmd();
            }

            return (TCmd) _command;
        }

        protected void SetCommand<TCmd>(TCmd command) where TCmd : ICommand {
            _command = command;
        }

        /// <summary>
        /// 控件是否包含Callback命令
        /// </summary>
        protected bool HasCallback => _command != null;

        /// <summary>
        /// 增加 命令回调属性
        /// </summary>
        /// <param name="element"></param>
        private void AddCallbackAttributes(XElement element) {
            if (_command is AbstractCommand cmd) {
                cmd.WriteXml(element);
                cmd.ControlId = ControlId.Value;
                Register?.Add(ControlId, _command);
            }
        }

        protected internal override XElement ToXml(XNamespace ns) {
            var element = base.ToXml(ns, new XAttribute(ControlId.Type.ToString(), ControlId.Value));
            AddCallbackAttributes(element);
            return element;
        }
    }


    public abstract class ControlContainer<TElement, TContainer> : Control<TElement>
        where TContainer : AddInList, new() {
        

        protected ControlContainer(string elementName) : base(elementName) {
            InnerItems = new TContainer();
        }

        protected TContainer InnerItems { get; }

        protected internal override void SetRegister(ICallbackRigister register) {
            base.SetRegister(register);
            InnerItems.SetRegister(register);
        }

        public TElement ItemNormalSize() {
            base.SetAttribute(AttrNames.itemSize, ControlSize.normal);
            return this.Interface;
        }

        public TElement ItemLargeSize() {
            base.SetAttribute(AttrNames.itemSize, ControlSize.large);
            return this.Interface;
        }

        protected internal override XElement ToXml(XNamespace ns) {
            var element = base.ToXml(ns);
            foreach (var childElement in InnerItems.ToXml(ns)) {
                element.Add(childElement);
            }

            return element;
        }
    }

    public abstract class Control<TElement, TCommand> : Control<TElement> where TCommand : ICommand {
        protected Control(string elementName) : base(elementName) {
        }

        public void Callback(TCommand command) {
            base.SetCommand<TCommand>(command);
        }

        protected TElement BuildCallback<TCmd>(Action<TCommand> builder) where TCmd : TCommand, new() {
            builder?.Invoke(base.GetCommand<TCmd>());
            return Interface;
        }
    }

    public abstract partial class Control<TElement> : Control {

        protected Control(string elementName) : base(elementName) {
        }

        protected abstract TElement Interface { get; }


        public TElement IdMso(string name) {
            ControlId.SetMicrosoftId(name);
            return Interface;
        }

        public TElement IdQ(string ns, string name) {
            ControlId.SetNamespaceId(ns, name);
            return Interface;
        }

        public TElement Id(string name) {
            ControlId.SetId(name);
            return Interface;
        }

        public TElement ImageMso(string name) {
            //_imageVisible = !string.IsNullOrEmpty(name);
            //_imageMso = name;
            //this.SetAttribute(tag_showImage, true);
            this.SetAttribute(AttrNames.imageMso, name);
            return Interface;
        }

        public TElement ImagePath(string path) {
            //this.SetAttribute(tag_showImage, true);
            this.SetAttribute(AttrNames.image, path);
            //_imageVisible = !string.IsNullOrEmpty(path);;
            //_imagePath = path;
            return Interface;
        }

        public TElement NoImage() {
            //this.SetAttribute(tag_showImage, false);
            //this.RemoveAttribute(tag_showImage);
            this.RemoveAttribute(AttrNames.image);
            this.RemoveAttribute(AttrNames.imageMso);
            return Interface;
        }

        public TElement Description(string description) {
            this.SetAttribute(AttrNames.description, description);
            //_description = description;
            return Interface;
        }

        public TElement Keytip(string keytip) {
            this.SetAttribute(AttrNames.keytip, keytip);
            //_keytip = keytip;
            return Interface;
        }

        public TElement Supertip(string supertip) {
            this.SetAttribute(AttrNames.supertip, supertip);
            //_supertip = supertip;
            return Interface;
        }

        public TElement Screentip(string screentip) {
            this.SetAttribute(AttrNames.screentip, screentip);
            //_screentip = screentip;
            return Interface;
        }

        public TElement LargeSize() {
            this.SetAttribute(AttrNames.size, ControlSize.large);
            //_size = ControlSize.large;
            return Interface;
        }

        public TElement NormalSize() {
            this.SetAttribute(AttrNames.size, ControlSize.normal);
            //_size = ControlSize.normal;
            return Interface;
        }

        public TElement ShowLabel() {
            this.SetAttribute(AttrNames.showLabel, true);
            //_showLabel = true;
            return Interface;
        }

        public TElement HideLabel() {
            this.SetAttribute(AttrNames.showLabel, false);
            //_showLabel = false;
            return Interface;
        }

        public TElement ShowItemLabel() {
            this.SetAttribute(AttrNames.showItemLabel, true);
            return Interface;
        }

        public TElement HideItemLabel() {
            this.SetAttribute(AttrNames.showItemLabel, true);
            return Interface;
        }


        public TElement ShowItemImage() {
            this.SetAttribute(AttrNames.showItemImage, true);
            return Interface;
        }

        public TElement HideItemImage() {
            this.SetAttribute(AttrNames.showItemImage, false);
            return Interface;
        }


        public TElement SizeString(int size) {
            //this.SetAttribute(size, size);
            this.SetAttribute(AttrNames.sizeString, new string('W', size));
            return this.Interface;
        }

        public TElement ItemHeight(int height) {
            this.SetAttribute(AttrNames.itemHeight, height);
            return this.Interface;
        }

        public TElement ItemWidth(int width) {
            this.SetAttribute(AttrNames.itemWidth, width);
            return this.Interface;
        }

        public TElement NumberRows(int rows) {
            this.SetAttribute(AttrNames.rows, rows);
            return this.Interface;
        }

        public TElement NumberColumns(int cols) {
            this.SetAttribute(AttrNames.columns, cols);
            return this.Interface;
        }


        public TElement MaxLength(int maxLength) {
            SetAttribute(AttrNames.maxLength, maxLength);
            return this.Interface;
        }
    }
}