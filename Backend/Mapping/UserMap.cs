//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//
using FluentNHibernate.Mapping;
using NickAc.LightPOS.Backend.Objects;

namespace NickAc.LightPOS.Backend.Mapping
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("Users");
            Id(x => x.UserID).GeneratedBy.Native().Unique();
            Map(x => x.UserName);
            Map(x => x.HashedPassword);
            Map(x => x.Salt);

            Map(x => x.Permissions).CustomType(typeof(UserPermission)).Not.Nullable();

            HasMany(x => x.Actions);
            HasMany(x => x.Sales).Not.LazyLoad();
        }
    }
}