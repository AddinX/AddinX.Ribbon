using System;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Implementation.Field
{
    public class DropDownField: IDropDownField
    {  
       public Func<int> SelectedItemIndex { get; }
        
       public Action<int> OnActionField { get; }
    }
}