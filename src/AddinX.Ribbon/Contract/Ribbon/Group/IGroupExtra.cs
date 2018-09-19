using System;

namespace AddinX.Ribbon.Contract.Ribbon.Group
{
    public interface IGroupExtra
    {
        IGroupExtra Supertip(string supertip);

        IGroupExtra Keytip(string keytip);

        IGroupExtra Screentip(string screentip);

        IGroupExtra DialogBoxLauncher(Action<IGroupDialogBox> dialogBox);
    }
}