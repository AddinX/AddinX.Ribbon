﻿namespace AddinX.Ribbon.Contract.Control.ButtonGroup
{
    public interface IButtonGroupId
    {
        IButtonGroupItems SetId(string name);

        IButtonGroupItems SetIdQ(string ns, string name);
    }
}