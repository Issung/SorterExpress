namespace SorterExpress.Classes.SettingsData
{
    public class SorterExpressSettings
    {
        public bool MoveSortedFiles { get; set; }

        public int TagSearchStart { get; set; }

        public bool DisplayAllTags { get; set; }

        public string[] Tags { get; set; }

        public string LastUsedDirectory { get; set; }

        public Subfolder[] Subfolders { get; set; } = new Subfolder[0];

        public bool FastResizing { get; set; } = false;

        public bool AutoResetTagSearchBox { get; set; } = true;

        public bool AutoResetSubfolderSearchBox { get; set; } = true;

        public VideoSettings Video { get; set; } = new();

        public DuplicateSearchSettings DuplicateSearch { get; set; } = new();
    }
}
