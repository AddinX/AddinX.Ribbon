using System;

namespace AddinX.Ribbon.Contract.Command.Field {
    public interface IImageField {

        Func<object> getImage { get; }
    }
}