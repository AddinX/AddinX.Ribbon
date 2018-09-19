using System;

namespace AddinX.Ribbon.Contract.Command.Field
{
    public interface IDropDownField
    {  
        Func<int> SelectedItemIndex { get; }
        
        Action<int> OnActionField { get; }
    }
}