// 
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace NickAc.LightPOS.Frontend.Settings
{
    public class SettingsManager
    {
        public SettingsManager()
        {
            LoadCatalog();
        }

        private AssemblyCatalog Catalog { get; set; }

        private CompositionContainer Container { get; set; }

        [UsedImplicitly]
        [ImportMany(typeof(ISettingHolder))]
        public List<ISettingHolder> Settings { get; set; }

        private void LoadCatalog()
        {
            Catalog = new AssemblyCatalog(typeof(SettingsManager).Assembly);
            Container = new CompositionContainer(Catalog);
        }

        public void LoadSettings()
        {
            Container?.SatisfyImportsOnce(this);
            foreach (var holder in Settings)
            foreach (var prop in holder.GetType().GetProperties())
            {
                var setting = Backend.Data.SettingsManager.GetSettingRaw(prop.Name);
                if (setting == null) continue;
                var obj = JsonConvert.DeserializeObject(setting.Data, prop.PropertyType);
                prop.SetValue(holder, obj);
            }
        }

        public void SaveSettings()
        {
            foreach (var holder in Settings)
            {
                var props = holder.GetType().GetProperties();
                Backend.Data.SettingsManager.SaveSettings(props.Select(p =>
                    Backend.Data.SettingsManager.GetSettingObject(p.Name, p.GetValue(holder))));
            }
        }
    }
}