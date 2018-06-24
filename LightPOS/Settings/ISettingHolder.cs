// 
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.ComponentModel.Composition;

namespace NickAc.LightPOS.Frontend.Settings
{
    [InheritedExport(typeof(ISettingHolder))]
    public interface ISettingHolder
    {
    }
}