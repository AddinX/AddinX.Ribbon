using System;

namespace AddinX.Ribbon.Contract.Command {
    public interface ICheckBoxCommand : ICommand {
        ICheckBoxCommand OnChecked(Action<bool> act);

        ICheckBoxCommand GetVisible(Func<bool> condition);

        ICheckBoxCommand GetEnabled(Func<bool> condition);

        /// <summary>
        /// determined whether the check-box is checked or not when the application is launched.
        /// </summary>
        /// <param name="defaultValue">a boolean value</param>
        /// <returns>Fluent Builder</returns>
        ICheckBoxCommand GetPressed(Func<bool> defaultValue);
    }
}