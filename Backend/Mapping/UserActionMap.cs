using FluentNHibernate.Mapping;
using NHibernate;
using NHibernate.Type;
using NickAc.LightPOS.Backend.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NickAc.LightPOS.Backend.Mapping
{
    public class UserActionMap : ClassMap<UserAction>
    {
        public UserActionMap()
        {
            Table("UserActions");
            Id(x => x.ID).GeneratedBy.Native();
            Map(x => x.Event);
            Map(x => x.Description);
            Map(x => x.Time).CustomType<LocalDateTimeType>();
        }
    }
}
