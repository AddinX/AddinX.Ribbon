using System;
using AddinX.Ribbon.Contract.Enums;

namespace AddinX.Ribbon.Contract.Command {
    public interface IMenuCommand : IControlCommand<IMenuCommand> {

        /// <summary>
        /// add getSize Callback
        /// </summary>
        /// <param name="sizeFunc"></param>
        /// <returns></returns>
        IMenuCommand GetSize(Func<ControlSize> sizeFunc);
    }
}