using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Control;
using AddinX.Ribbon.Contract.Enums;
using AddinX.Ribbon.Implementation.Command;

namespace AddinX.Ribbon.Implementation.Control {
    public abstract class Control : AddInElement {
        protected IElementId Id { get; }

        private ICommand _command;

        protected Control(string elementName) : base(elementName) {
            Id = new ElementId();
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
        /// 增加 命令回调属性
        /// </summary>
        /// <param name="element"></param>
        private void AddCallbackAttributes(XElement element) {
            if (_command != null) {
                _command.WriteCallbackXml(element);
                if (_command is AbstractCommand absCmd) {
                    absCmd.ControlId = this.Id.Value;
                }

                Register?.Add(Id, _command);
            }
        }

        protected internal override XElement ToXml(XNamespace ns) {
            var element = base.ToXml(ns, new XAttribute(Id.Type.ToString(), Id.Value));
            AddCallbackAttributes(element);
            return element;
        }
    }


    public abstract class ControlContainer<TElement, TContainer> : Control<TElement>
        where TContainer : AddInList, new() {
        private const string tag_itemSize = "itemSize";

        protected ControlContainer(string elementName) : base(elementName) {
            InnerItems = new TContainer();
        }

        protected TContainer InnerItems { get; }

        protected internal override void SetRegister(ICallbackRigister register) {
            base.SetRegister(register);
            InnerItems.SetRegister(register);
        }

        public TElement ItemNormalSize() {
            base.SetAttribute(tag_itemSize, ControlSize.normal);
            return this.Interface;
        }

        public TElement ItemLargeSize() {
            base.SetAttribute(tag_itemSize, ControlSize.large);
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

    public abstract class Control<TElement> : Control {
        private const string tag_size = "size";
        private const string tag_getSize = "getSize";
        private const string tag_onAction = "onAction";
        private const string tag_enabled = "enabled";
        private const string tag_getEnabled = "getEnabled";
        private const string tag_description = "description";
        private const string tag_getDescription = "getDescription";
        private const string tag_image = "image";
        private const string tag_imageMso = "imageMso";
        private const string tag_getImage = "getImage";
        private const string tag_id = "id";
        private const string tag_idQ = "idQ";
        private const string tag_tag = "tag";
        private const string tag_idMso = "idMso";
        private const string tag_screentip = "screentip";
        private const string tag_getScreentip = "getScreentip";
        private const string tag_supertip = "supertip";
        private const string tag_getSupertip = "getSupertip";
        private const string tag_label = "label";
        private const string tag_getLabel = "getLabel";
        private const string tag_insertAfterMso = "insertAfterMso";
        private const string tag_insertBeforeMso = "insertBeforeMso";
        private const string tag_insertAfterQ = "insertAfterQ";
        private const string tag_insertBeforeQ = "insertBeforeQ";
        private const string tag_visible = "visible";
        private const string tag_getVisible = "getVisible";
        private const string tag_keytip = "keytip";
        private const string tag_getKeytip = "getKeytip";
        private const string tag_showLabel = "showLabel";
        private const string tag_getShowLabel = "getShowLabel";
        private const string tag_showImage = "showImage";
        private const string tag_getShowImage = "getShowImage";
        private const string tag_showItemLabel = "showItemLabel";
        private const string tag_showItemImage = "showItemImage";
        private const string tag_invalidateContentOnDrop = "invalidateContentOnDrop";
        private const string tag_columns = "columns";
        private const string tag_rows = "rows";
        private const string tag_itemWidth = "itemWidth";
        private const string tag_itemHeight = "itemHeight";
        private const string tag_getItemWidth = "getItemWidth";
        private const string tag_getItemHeight = "getItemHeight";
        private const string tag_showInRibbon = "showInRibbon";
        private const string tag_getItemCount = "getItemCount";
        private const string tag_getItemLabel = "getItemLabel";
        private const string tag_getItemScreentip = "getItemScreentip";
        private const string tag_getItemSupertip = "getItemSupertip";
        private const string tag_getItemImage = "getItemImage";
        private const string tag_getItemID = "getItemID";
        private const string tag_sizeString = "sizeString";
        private const string tag_getSelectedItemID = "getSelectedItemID";
        private const string tag_getSelectedItemIndex = "getSelectedItemIndex";

        private const string tag_maxLength = "maxLength";
        private const string tag_getText = "getText";
        private const string tag_onChange = "onChange";


        protected Control(string elementName) : base(elementName) {
        }

        protected abstract TElement Interface { get; }


        public TElement SetIdMso(string name) {
            Id.SetMicrosoftId(name);
            return Interface;
        }

        public TElement SetIdQ(string ns, string name) {
            Id.SetNamespaceId(ns, name);
            return Interface;
        }

        public TElement SetId(string name) {
            Id.SetId(name);
            return Interface;
        }


        public TElement ImageMso(string name) {
            //_imageVisible = !string.IsNullOrEmpty(name);
            //_imageMso = name;
            //this.SetAttribute(tag_showImage, true);
            this.SetAttribute(tag_imageMso, name);
            return Interface;
        }

        public TElement ImagePath(string path) {
            //this.SetAttribute(tag_showImage, true);
            this.SetAttribute(tag_image, path);
            //_imageVisible = !string.IsNullOrEmpty(path);;
            //_imagePath = path;
            return Interface;
        }

        public TElement NoImage() {
            //this.SetAttribute(tag_showImage, false);
            //this.RemoveAttribute(tag_showImage);
            this.RemoveAttribute(tag_image);
            this.RemoveAttribute(tag_imageMso);
            return Interface;
        }

        public TElement Description(string description) {
            this.SetAttribute(tag_description, description);
            //_description = description;
            return Interface;
        }

        public TElement Keytip(string keytip) {
            this.SetAttribute(tag_keytip, keytip);
            //_keytip = keytip;
            return Interface;
        }

        public TElement Supertip(string supertip) {
            this.SetAttribute(tag_supertip, supertip);
            //_supertip = supertip;
            return Interface;
        }

        public TElement Screentip(string screentip) {
            this.SetAttribute(tag_screentip, screentip);
            //_screentip = screentip;
            return Interface;
        }

        public TElement LargeSize() {
            this.SetAttribute(tag_size, ControlSize.large);
            //_size = ControlSize.large;
            return Interface;
        }

        public TElement NormalSize() {
            this.SetAttribute(tag_size, ControlSize.normal);
            //_size = ControlSize.normal;
            return Interface;
        }

        public TElement ShowLabel() {
            this.SetAttribute(tag_showLabel, true);
            //_showLabel = true;
            return Interface;
        }

        public TElement HideLabel() {
            this.SetAttribute(tag_showLabel, false);
            //_showLabel = false;
            return Interface;
        }

        public TElement ShowItemLabel() {
            this.SetAttribute(tag_showItemLabel, true);
            return Interface;
        }

        public TElement HideItemLabel() {
            this.SetAttribute(tag_showItemLabel, true);
            return Interface;
        }


        public TElement ShowItemImage() {
            this.SetAttribute(tag_showItemImage, true);
            return Interface;
        }

        public TElement HideItemImage() {
            this.SetAttribute(tag_showItemImage, false);
            return Interface;
        }


        public TElement SizeString(int size) {
            //this.SetAttribute(tag_size, size);
            this.SetAttribute(tag_sizeString, new string('W', size));
            return this.Interface;
        }

        public TElement ItemHeight(int height) {
            this.SetAttribute(tag_itemHeight, height);
            return this.Interface;
        }

        public TElement ItemWidth(int width) {
            this.SetAttribute(tag_itemWidth, width);
            return this.Interface;
        }

        public TElement NumberRows(int rows) {
            this.SetAttribute(tag_rows, rows);
            return this.Interface;
        }

        public TElement NumberColumns(int cols) {
            this.SetAttribute(tag_columns, cols);
            return this.Interface;
        }


        public TElement MaxLength(int maxLength) {
            SetAttribute(tag_maxLength, maxLength);
            return this.Interface;
        }
    }
}