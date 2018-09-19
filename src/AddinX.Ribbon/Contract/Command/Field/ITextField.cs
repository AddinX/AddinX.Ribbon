using System;

namespace AddinX.Ribbon.Contract.Command.Field
{
    public interface ITextField
    {
        Func<string> TextField { get; }

        Action<string> OnChangeFieldAction{ get; } 
    }
}