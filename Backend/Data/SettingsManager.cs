using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Util;
using NickAc.LightPOS.Backend.Objects;

namespace NickAc.LightPOS.Backend.Data
{
    public static class SettingsManager
    {
        public static void Initialize()
        {
            DataFactory = DataManager.DataFactory;
            SessionFactory = DataManager.SessionFactory;
        }

        public static StoredSetting GetSettingRaw(string id)
        {
            StoredSetting setting;
            using (var sf = SessionFactory)
            {
                using (var session = sf.OpenSession())
                {
                    setting = session.QueryOver<StoredSetting>()
                        .Where(s => s.Id == id).List().FirstOrDefault();
                }
            }

            return setting;
        }

        public static void SaveSetting(StoredSetting setting)
        {
            setting.Data = JsonConvert.SerializeObject(setting.Value);
            using (var sf = SessionFactory)
            {
                using (var session = sf.OpenSession())
                {
                    using (var trans = session.BeginTransaction())
                    {
                        session.SaveOrUpdate(setting);
                        trans.Commit();
                    }
                }
            }
        }

        public static void SaveSettings(IEnumerable<StoredSetting> settings)
        {
            var storedSettings = settings as StoredSetting[] ?? settings.ToArray();
            storedSettings.ForEach(s => s.Data = JsonConvert.SerializeObject(s.Value));
            using (var sf = SessionFactory)
            {
                using (var session = sf.OpenSession())
                {
                    using (var trans = session.BeginTransaction())
                    {
                        storedSettings.ForEach(session.SaveOrUpdate);
                        trans.Commit();
                    }
                }
            }
        }


        public static void SaveSetting<T>(string id, T value)
        {
            SaveSetting(GetSettingObject(id, value));
        }

        public static StoredSetting GetSettingObject<T>(string id, T value)
        {
            return new StoredSetting
            {
                Id = id,
                Value = value
            };
        }

        public static T GetSetting<T>(string id)
        {
            var finalSetting = GetSettingRaw(id);
            return JsonConvert.DeserializeObject<T>(finalSetting.Data);
        }

        #region Properties

        public static DataFactory DataFactory { get; set; }

        public static ISessionFactory SessionFactory { get; set; }

        #endregion
    }
}