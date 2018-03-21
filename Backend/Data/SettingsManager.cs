using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using NHibernate;
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

        public static byte[] GetSettingRaw(string id)
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

            return setting.Data;
        }

        public static void SaveSetting(StoredSetting setting)
        {
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

        public static void SaveSetting<T>(string id, T value)
        {
            byte[] finalValue = null;

            if (typeof(T) == typeof(string))
            {
                //Handle strings differently
                finalValue = Encoding.UTF8.GetBytes(Convert.ToString(value));
            }
            else
            {
                var br = new BinaryFormatter();
                using (var ms = new MemoryStream())
                {
                    br.Serialize(ms, value);
                    finalValue = ms.ToArray();
                }
            }

            SaveSetting(new StoredSetting
            {
                Id = id,
                Data = finalValue
            });
        }

        public static T GetSetting<T>(string id)
        {
            var finalObject = default(T);
            if (typeof(T) == typeof(string))
            {
                //Handle strings differently
                return (T) Convert.ChangeType(Encoding.UTF8.GetString(GetSettingRaw(id)), typeof(T));
            }

            var br = new BinaryFormatter();
            using (var ms = new MemoryStream(GetSettingRaw(id)))
            {
                finalObject = (T) br.Deserialize(ms);
            }

            return finalObject;
        }

        #region Properties

        public static DataFactory DataFactory { get; set; }
        public static ISessionFactory SessionFactory { get; set; }

        #endregion
    }
}