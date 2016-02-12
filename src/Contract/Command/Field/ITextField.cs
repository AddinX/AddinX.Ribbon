using System;

namespace AddinX.Core.Contract.Command.Field
{
    public interface ITextField
    {
        Func<string> TextField { get; }

        Action<string> OnChangeFieldAction{ get; } 
    }
}