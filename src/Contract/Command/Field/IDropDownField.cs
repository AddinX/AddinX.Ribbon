using System;

namespace AddinX.Core.Contract.Command.Field
{
    public interface IDropDownField
    {  
        Func<int> SelectedItemIndex { get; }
        
        Action<int> OnActionField { get; }
    }
}