using NHibernate;
using NickAc.LightPOS.Backend.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace NickAc.LightPOS.Backend.Data
{
    public static class SettingsManager
    {
        #region Properties

        public static DataFactory DataFactory { get; set; }
        public static ISessionFactory SessionFactory { get; set; }

        #endregion

        public static void Initialize()
        {
            DataFactory = DataManager.DataFactory;
            SessionFactory = DataManager.SessionFactory;
        }

        public static byte[] GetSettingRaw(string id)
        {
            StoredSetting user;
            using (var sf = SessionFactory) {
                using (var session = sf.OpenSession()) {
                    user = session.QueryOver<StoredSetting>()
                    .Where(s => s.ID == id).List().FirstOrDefault();
                }
            }
            return user.Data;
        }

        public static void SaveSetting(StoredSetting setting)
        {
            using (var sf = SessionFactory) {
                using (var session = sf.OpenSession()) {
                    using (var trans = session.BeginTransaction()) {
                        session.SaveOrUpdate(setting);
                        trans.Commit();
                    }
                }
            }
        }

        public static void SaveSetting<T>(string id, T value)
        {
            byte[] finalValue = null;

            if (typeof(T) == typeof(string)) {
                //Handle strings differently
                finalValue = Encoding.UTF8.GetBytes(Convert.ToString(value));
            } else {
                BinaryFormatter br = new BinaryFormatter();
                using (var ms = new MemoryStream()) {
                    br.Serialize(ms, value);
                    finalValue = ms.ToArray();
                }
            }
            SaveSetting(new StoredSetting() {
                ID = id,
                Data = finalValue
            });

        }

        public static T GetSetting<T>(string id)
        {
            T finalObject = default(T);
            if (typeof(T) == typeof(string)) {
                //Handle strings differently
                return (T)Convert.ChangeType(Encoding.UTF8.GetString(GetSettingRaw(id)), typeof(T));
            } else {
                BinaryFormatter br = new BinaryFormatter();
                using (var ms = new MemoryStream(GetSettingRaw(id))) {
                    finalObject = (T)br.Deserialize(ms);
                }
            }
            return finalObject;
        }

    }
}
