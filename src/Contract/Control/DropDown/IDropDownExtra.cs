using System;

namespace AddinX.Ribbon.Contract.Control.DropDown
{
    public interface IDropDownExtra
    {
        IDropDownExtra AddButtons(Action<IDropDownControls> items);

        IDropDownExtra SizeString(int size);

        IDropDownExtra Supertip(string supertip);

        IDropDownExtra Keytip(string keytip);

        IDropDownExtra Screentip(string screentip);
    }
}