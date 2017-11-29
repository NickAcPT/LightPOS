using FluentNHibernate.Mapping;
using NickAc.LightPOS.Backend.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
