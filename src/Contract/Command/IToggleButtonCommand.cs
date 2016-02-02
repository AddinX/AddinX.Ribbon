using System;

namespace AddinX.Core.Contract.Command
{
    public interface IToggleButtonCommand : ICommand
    {
        IToggleButtonCommand Action(Action act);

        IToggleButtonCommand Action(Action act, Func<bool> canExecute);

        IToggleButtonCommand IsVisible(Func<bool> condition);

        IToggleButtonCommand IsEnabled(Func<bool> condition);

        /// <summary>
        /// determined whether the toggle button is checked or not when the application is launched.
        /// </summary>
        /// <param name="defaultValue">a boolean value</param>
        /// <returns>Fluent Builder</returns>
        IToggleButtonCommand GetPressed(Func<bool> defaultValue);
    }
}