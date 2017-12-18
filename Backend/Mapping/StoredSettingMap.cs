using FluentNHibernate.Mapping;
using NickAc.LightPOS.Backend.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NickAc.LightPOS.Backend.Mapping
{
    public class StoredSettingMap : ClassMap<StoredSetting>
    {
        public StoredSettingMap()
        {
            Id(x => x.ID).Unique();
            Map(x => x.Data);
        }
    }
}
