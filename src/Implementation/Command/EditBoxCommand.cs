using System;
using AddinX.Core.Contract.Command;
using AddinX.Core.Contract.Command.Field;

namespace AddinX.Core.Implementation.Command
{
    class EditBoxCommand: IEditBoxCommand, IVisibleField, IEnabledField, ITextField
    {
        public EditBoxCommand()
        {
            IsVisibleField = () => true;
            IsEnabledField = () => true;
            TextField = () => string.Empty;
        }

        public IEditBoxCommand IsVisible(Func<bool> condition)
        {
            IsVisibleField = condition;
            return this;
        }

        public IEditBoxCommand IsEnabled(Func<bool> condition)
        {
            IsEnabledField = condition;
            return this;
        }

        public IEditBoxCommand GetText(Func<string> defaultValue)
        {
            TextField = defaultValue;
            return this;
        }

        public IEditBoxCommand OnChange(Action<string> newText)
        {
            OnChangeFieldAction = newText;
            return this;
        }
        
        public Func<bool> IsVisibleField { get; private set; }
        public Func<bool> IsEnabledField { get; private set; }
        public Func<string> TextField { get; private set; }
        public Action<string> OnChangeFieldAction { get; private set; }
    }
}