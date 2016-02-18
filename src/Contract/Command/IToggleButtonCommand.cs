using System;

namespace AddinX.Core.Contract.Command
{
    public interface IToggleButtonCommand : ICommand
    {
        IToggleButtonCommand Action(Action<bool> act);

        IToggleButtonCommand IsVisible(Func<bool> condition);

        IToggleButtonCommand IsEnabled(Func<bool> condition);

        /// <summary>
        /// determined whether the toggle button is checked or not when the application is launched.
        /// </summary>
        /// <param name="defaultValue">a boolean value</param>
        /// <returns>Fluent Builder</returns>
        IToggleButtonCommand Pressed(Func<bool> defaultValue);
    }
}