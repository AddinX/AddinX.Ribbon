using System;
using System.Collections.Generic;

namespace AddinX.Ribbon.Implementation.Field
{
    public interface IDynamicItemsField
    {
        Func<int> ItemCount { get; }

        Func<IList<object>> ItemId { get; }

        Func<IList<object>> ItemImage { get; }

        Func<IList<string>> ItemLabel { get; } 

        Func<IList<string>> ItemScreentip { get; }

        Func<IList<string>> ItemSupertip { get; }
    }
}