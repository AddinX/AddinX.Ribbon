using System.Collections.Generic;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;
using AddinX.Ribbon.Contract.Control;

namespace AddinX.Ribbon.Implementation.Control {
    public abstract class Control : AddInElement {
       
        protected IElementId Id { get; set; }
        protected string Label { get; private set; }

        protected ICallbackRigister Register { get; }

        private ICommand _command;


        protected Control(ICallbackRigister register,string elementName) :base(elementName) {
            Id = new ElementId();
            Label = string.Empty;
            Register = register;
        }

        protected internal void SetLabel(string label) {
            Label = label;
        }

        protected TCmd GetCommand<TCmd>() where TCmd : ICommand, new() {
            if (_command == null) {
                _command = new TCmd();
            }

            return (TCmd) _command;
        }
        
        private void ToCallbackXml(XElement element) {
            if (_command != null) {
                _command.WriteCallbackXml(element);
                Register.Add(Id,_command);
            }
        }
        
        protected internal override XElement ToXml(XNamespace ns) {
            var element = base.ToXml(ns);
            element.Add(((ElementId)Id).ToXml());
            element.AddAttribute("label", Label,string.Empty);

            ToCallbackXml(element);
            return element;
        }
    }
   

    internal class CallbackRegister {

        private IDictionary<string, IActionField> _actionFields;
        private IDictionary<string, IActionPressedField> _actionPressedFields;
        private IDictionary<string, IDropDownField> _dropDownFields;
        private IDictionary<string, IDynamicItemsField> _dynamicItemsFields;
        private IDictionary<string, IEnabledField> _enabledFields;
        private IDictionary<string, ILabelField> _labelFields;
        private IDictionary<string, IVisibleField> _visibleFields;
        private IDictionary<string, ITextField> _textFields;
        private IDictionary<string, IPressedField> _pressedFields;

        public void Regist(string name, IActionField action) {
            if (_actionFields == null) {
                _actionFields = new Dictionary<string,IActionField>();
            }
            _actionFields.Add(name,action);
        }

        public void Regist(string name, IActionPressedField action) {
            if (_actionPressedFields == null) {
                _actionPressedFields = new Dictionary<string, IActionPressedField>();
            }
            _actionPressedFields.Add(name, action);
        }

        public void Regist(string name, IDropDownField dropDownField) {
            if (_dropDownFields == null) {
                _dropDownFields = new Dictionary<string, IDropDownField>();
            }
            _dropDownFields.Add(name,dropDownField);
        }

        public void Regist(string name, IDynamicItemsField field) {
            if (_dynamicItemsFields == null) {
                _dynamicItemsFields = new Dictionary<string, IDynamicItemsField>();
            }
            _dynamicItemsFields.Add(name,field);
        }

        public void Regist(string name, IEnabledField enabledField) {
            if (_enabledFields == null) {
                _enabledFields = new Dictionary<string, IEnabledField>();
            }
            _enabledFields.Add(name,enabledField);
        }

        public void Regist(string name, ILabelField field) {
            if (_labelFields == null) {
                _labelFields = new Dictionary<string, ILabelField>();
            }
            _labelFields.Add(name,field);
        }

        public void Regist(string name, IPressedField field) {
            if (_pressedFields == null) {
                _pressedFields = new Dictionary<string, IPressedField>();
            }
            _pressedFields.Add(name, field);
        }

        public void Regist(string name, ITextField field) {
            if (_textFields == null) {
                _textFields = new Dictionary<string, ITextField>();
            }
            _textFields.Add(name, field);
        }
        public void Regist(string name, IVisibleField field) {
            if (_visibleFields == null) {
                _visibleFields = new Dictionary<string, IVisibleField>();
            }
            _visibleFields.Add(name, field);
        }

    }

}