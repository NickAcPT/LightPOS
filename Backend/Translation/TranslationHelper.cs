//
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Resources;
using System.Windows.Forms;

namespace NickAc.LightPOS.Backend.Translation
{
    [ProvideProperty("TranslationLocation", typeof(Control))]
    public class TranslationHelper : Component, IExtenderProvider
    {
        public static Language CurrentLanguage { get; set; } = Language.English;

        public enum Language
        {
            English,
        }
        private class TranslationProvider
        {
            public string TranslationLocation;

            public TranslationProvider()
            {
                TranslationLocation = "";
            }
        }

        private Dictionary<object, TranslationProvider> translations = new Dictionary<object, TranslationProvider>();

        private TranslationProvider EnsureProviderExists(object key)
        {
            TranslationProvider p;

            if (!translations.ContainsKey(key)) {
                p = new TranslationProvider();
                translations.Add(key, p);
            }
            else {
                p = translations[key];
            }

            return p;
        }

        [Description("Translation location of this control")]
        [Category("Appearance")]
        public string GetTranslationLocation(object c)
        {
            return EnsureProviderExists(c).TranslationLocation;
        }

        public void SetTranslationLocation(object c, string value)
        {
            EnsureProviderExists(c).TranslationLocation = value;
        }

        public bool CanExtend(object extendee)
        {
            var control = extendee as Control;
            return control != null;
        }

        public void Translate(Form c)
        {
            TranslateControl(c);
            c.Controls.Cast<Control>().All((p) => {
                TranslateControl(p);
                return true;
            });
        }

        public void TranslateControl(Control c)
        {
            var lang = GetLanguage(CurrentLanguage);
            if (lang != null) {
                string loc = GetTranslationLocation(c);
                if (!loc.Equals(string.Empty)) {
                    c.Text = GetTranslation(lang, loc);
                    c.Refresh();
                }
            }
            if (c is Panel panel) {
                panel.Controls.Cast<Control>().All(cc => {
                    TranslateControl(cc);
                    return true;
                });
            }
        }

        private string GetTranslation(ResourceManager lang, string loc)
        {
            string final = "";
            string original = lang.GetString(loc);
            if (original.Contains(' ')) {
                var split = original.Split(' ');
                split.All((s) => {
                    if (s.StartsWith("$", StringComparison.Ordinal)) {
                        final += GetTranslation(lang, s.TrimStart('$')) + " ";
                    }
                    else {
                        final += s + " ";
                    }
                    return true;
                });
            }
            if (final == string.Empty)
                final = original;
            return final.Trim();
        }

        public System.Resources.ResourceManager GetLanguage(Language lang)
        {
            switch (lang) {
                case Language.English:
                    return Translation_EN.ResourceManager;
            }
            return null;
        }
    }
}