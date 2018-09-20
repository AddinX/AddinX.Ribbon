using System;

namespace AddinX.Ribbon.Implementation.Field
{
    public interface ITextField
    {
        Func<string> TextField { get; }

        Action<string> OnChangeFieldAction{ get; } 
    }
}