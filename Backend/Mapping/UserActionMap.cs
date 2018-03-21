//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using FluentNHibernate.Mapping;
using NHibernate.Type;
using NickAc.LightPOS.Backend.Objects;

namespace NickAc.LightPOS.Backend.Mapping
{
    public class UserActionMap : ClassMap<UserAction>
    {
        public UserActionMap()
        {
            Table("UserActions");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Event);
            Map(x => x.Description);
            Map(x => x.Time).CustomType<LocalDateTimeType>();
        }
    }
}