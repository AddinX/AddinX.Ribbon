using System;
using System.Drawing;

namespace AddinX.Ribbon.Contract.Command {
    public interface IToggleButtonCommand : IButtonRegularCommand<IToggleButtonCommand> {
        IToggleButtonCommand OnPressed(Action<bool> pressed);

        IToggleButtonCommand GetPressed(Func<bool> pressedFunc);

    }

    public interface IButtonRegularCommand<out T> : IControlCommand<T> where T:ICommand
        // IDescriptionField, IActionField, IEnabledField, IImageField,
        // IVisibleField ,ILabelField
    {
        T GetDescription(Func<string> descriptionFunc);

        T GetImage(Func<Image> imageFunc);
    }

    public interface IControlCommand<out T> :ICommand where T:ICommand{

        T GetVisible(Func<bool> visibleFunc);

        T GetLabel(Func<string> labelFunc);

        T GetEnabled(Func<bool> enabledFunc);
    }
}