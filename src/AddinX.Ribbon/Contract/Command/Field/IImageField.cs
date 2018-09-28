using System;
using System.Drawing;

namespace AddinX.Ribbon.Contract.Command.Field {
    public interface IImageField {
        /// <summary>
        /// getImage
        /// »Øµ÷
        /// VBA£ºSub GetImage(control As IRibbonControl, ByRef returnedBitmap)
        /// C#£ºBitmap GetImage(IRibbonControl control)
        /// </summary>
        Func<Image> getImage { get; }
    }
}