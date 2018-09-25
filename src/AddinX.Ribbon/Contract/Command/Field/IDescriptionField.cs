using System;

namespace AddinX.Ribbon.Contract.Command.Field {
    public interface IDescriptionField {

        Func<string> GetDescription { get; set; }
    }
}