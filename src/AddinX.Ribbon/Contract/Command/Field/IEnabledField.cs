﻿using System;

namespace AddinX.Ribbon.Contract.Command.Field
{
    public interface IEnabledField
    {
        Func<bool> IsEnabledField { get; }
    }
}