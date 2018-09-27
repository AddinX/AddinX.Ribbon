using System;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Contract.Command
{
    public interface IButtonCommand : IButtonRegularCommand {
       /* IButtonCommand OnAction(Action act);

        IButtonCommand GetVisible(Func<bool> condition);

        IButtonCommand GetEnabled(Func<bool> condition);
        */
    }
}