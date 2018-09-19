using System;

namespace AddinX.Ribbon.Contract.Command
{
    public interface ICheckBoxCommand : ICommand
    {
        ICheckBoxCommand OnAction(Action<bool> act);

        ICheckBoxCommand IsVisible(Func<bool> condition);

        ICheckBoxCommand IsEnabled(Func<bool> condition);

        /// <summary>
        /// determined whether the check-box is checked or not when the application is launched.
        /// </summary>
        /// <param name="defaultValue">a boolean value</param>
        /// <returns>Fluent Builder</returns>
        ICheckBoxCommand Pressed(Func<bool> defaultValue);
    }
}