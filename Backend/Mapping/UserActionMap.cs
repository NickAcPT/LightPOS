using FluentNHibernate.Mapping;
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
        }
    }
}
