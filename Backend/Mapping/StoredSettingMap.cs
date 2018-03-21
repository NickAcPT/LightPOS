using FluentNHibernate.Mapping;
using NickAc.LightPOS.Backend.Objects;

namespace NickAc.LightPOS.Backend.Mapping
{
    public class StoredSettingMap : ClassMap<StoredSetting>
    {
        public StoredSettingMap()
        {
            Id(x => x.Id).Unique();
            Map(x => x.Data);
        }
    }
}