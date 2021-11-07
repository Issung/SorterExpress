namespace SorterExpress.Classes.SettingsData
{
    public class VideoSettings
    {
        /// <summary>
        /// Directory of VLC libraries.
        /// </summary>
        public string VlcLocation { get; set; }

        /// <summary>
        /// Video volume (ranging 1 - 100).
        /// </summary>
        public int Volume { get; set; }

        /// <summary>
        /// Should mute video players or not.
        /// True = mute.
        /// False = unmute.
        /// </summary>
        public bool Mute { get; set; }
    }
}
