using System;
using AddinX.Ribbon.Contract.Enums;

namespace AddinX.Ribbon.Contract.Command.Field {
    public interface ISizeField {

        Func<ControlSize> getSize { get; set; }
    }
}