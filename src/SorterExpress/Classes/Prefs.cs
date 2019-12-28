
/*namespace SorterExpress
{
    /// <summary>
    /// Only ever add to the end of this enum, reordering them will screw up loading people's prefs files.
    /// </summary>
    public enum Pref
    {
        MoveSortedFiles,
        TagSearchStart,
        AutoResetTagSearchBox,
        DisplayAllTags,
        Tags,
        LastUsedDirectory,
        VlcLocation,
        VideoVolume,
        VideoMute,
        SubfolderNames,
        SubfolderDirectories
    };

    class Prefs
    {
        const string PREFS_FILENAME = "prefs.conf";

        public static bool prefsInitialised = false;
        private static Dictionary<Pref, object> prefs = null;

        public static readonly Dictionary<Pref, object> prefDefaults = new Dictionary<Pref, object> {
            { Pref.MoveSortedFiles, false },
            { Pref.TagSearchStart, 2 },
            { Pref.AutoResetTagSearchBox, true },
            { Pref.DisplayAllTags, true },
            { Pref.Tags, "" },
            { Pref.VideoVolume, 10 },
            { Pref.VideoMute, true },
            { Pref.SubfolderNames, "" },
            { Pref.SubfolderDirectories, "" }
        };

        public static T PrefDefault<T>(Pref name)
        {
            if (prefDefaults.ContainsKey(name))
                return (T)prefDefaults[name];
            else
                return default;
        }

        public static void InitPrefs()
        {
            if (!prefsInitialised)
            {
                LoadPrefs();
                prefsInitialised = true;
            }
        }

        /// <summary>
        /// Call this on program load before trying to use any Prefs functionality!
        /// </summary>
        public static void LoadPrefs()
        {
            // Load prefs.
            if (File.Exists(PREFS_FILENAME) && File.ReadAllText(PREFS_FILENAME).Length > 0)
                prefs = JsonConvert.DeserializeObject<Dictionary<Pref, object>>(File.ReadAllText(PREFS_FILENAME));

            if (prefs == null)
                prefs = new Dictionary<Pref, object>();
        }

        /// <summary>
        /// Retrieve the given pref.
        /// If the pref is not loaded then checks the defaults dictionary and returns that.
        /// If the defaults dictionary does not have an entry, this will return the default value for the given generic type (T).
        /// </summary>
        public static T Get<T>(Pref name)
        {
            InitPrefs();

            if (prefs.ContainsKey(name))
                return (T)Convert.ChangeType(prefs[name], typeof(T));

            return PrefDefault<T>(name);
        }

        /// <summary>
        /// Retrieve the given pref.
        /// If the pref is not loaded the defaults dictionary will not be checked and the given defaultValue will be returned.
        /// </summary>
        public static T Get<T>(Pref name, T defaultValue)
        {
            InitPrefs();

            if (prefs.ContainsKey(name))
                return (T)Convert.ChangeType(prefs[name], typeof(T)); //return (T)prefs[name];

            return (T)defaultValue;
        }

        public static bool DoesPrefExist(Pref name)
        {
            InitPrefs();
            return prefs.ContainsKey(name);
        }

        public static void Set(Pref name, object value, bool save = true)
        {
            InitPrefs();

            if (prefs.ContainsKey(name))
                prefs[name] = value;
            else
                prefs.Add(name, value);

            if (save)
                SavePrefs();
        }

        public static void SavePrefs()
        {
            InitPrefs();
            File.WriteAllText(PREFS_FILENAME, JsonConvert.SerializeObject(prefs));
        }

        /// <summary>
        /// remove all prefs with a given id, make sure to save if you want to delete it from the 
        /// prefs.conf file.
        /// </summary>
        public static void RemovePref(Pref name)
        {
            InitPrefs();
            prefs.Remove(name);
        }
    }
}
*/