// 
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using FluentNHibernate.Mapping;
using NickAc.LightPOS.Backend.Data;

namespace NickAc.LightPOS.Backend.Mapping
{
    public class BaseClassMap<T> : ClassMap<T> where T : BaseDbItem
    {
        public BaseClassMap()
        {
            Id(x => x.Id).GeneratedBy.Increment();
            Map(x => x.Deleted).Not.Nullable();
        }
    }
}