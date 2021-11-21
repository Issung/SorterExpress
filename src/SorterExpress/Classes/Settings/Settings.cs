using System;
using System.IO;
using System.Text.Json;

namespace SorterExpress.Classes.SettingsData
{
    public class Settings
    {
        public const string SettingsFilename = "settings.json";
        public static string SettingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, SettingsFilename);

        public static SorterExpressSettings Default 
        {
            get
            {
                if (_default == null)
                {
                    Load();
                }

                return _default;
            }
        }

        public static void Load()
        {
            if (File.Exists(SettingsPath))
            {
                string text = File.ReadAllText(SettingsPath);
                var loadedSettings = JsonSerializer.Deserialize<SorterExpressSettings>(text);
                _default = loadedSettings;
            }
            else
            {
                _default = new();
            }
        }

        public static void Save()
        {
            string text = JsonSerializer.Serialize(_default);
            File.WriteAllText(SettingsPath, text);
        }

        private static SorterExpressSettings _default;
    }
}
