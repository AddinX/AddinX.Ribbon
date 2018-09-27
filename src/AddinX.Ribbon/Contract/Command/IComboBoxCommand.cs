using System;
using System.Collections.Generic;

namespace AddinX.Ribbon.Contract.Command
{
    public interface IComboBoxCommand: ICommand
    {
        IComboBoxCommand IsVisible(Func<bool> condition);

        IComboBoxCommand IsEnabled(Func<bool> condition);

        /// <summary>
        /// determined what is the default text displayed in the combo-box when the application is launched.
        /// </summary>
        /// <param name="defaultValue">a string value</param>
        /// <returns>Fluent Builder</returns>
        IComboBoxCommand GetText(Func<string> defaultValue);

        IComboBoxCommand OnChange(Action<string> newText);

        IComboBoxCommand ItemCounts(Func<int> numberItems);

        IComboBoxCommand ItemsId(Func<int, string> itemsId);

        IComboBoxCommand ItemsLabel(Func<int, string> itemsLabel);

        IComboBoxCommand ItemsScreentip(Func<IList<string>> itemsScreentip);

        IComboBoxCommand ItemsSupertip(Func<IList<string>> itemsSupertip);
    }
}