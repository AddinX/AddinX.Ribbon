using System;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Contract.Command
{
    public interface IToggleButtonCommand : IToggleRegularCommand{

    }

    public interface IToggleRegularCommand: ICommand, IDescriptionField, IEnabledField, IImageField, IPressedField,IActionPressedField{
         //getPressed
    }

    public interface IButtonRegularCommand : ICommand,IDescriptionField, IActionField, IEnabledField,IImageField,IVisibleField {

    }
}