using System;
using System.Collections.Generic;

namespace SorterExpress.Classes.SettingsData
{
    public class DuplicateSearchSettings
    {
        public bool SearchImages { get; set; } = true;

        public bool SearchVideos { get; set; } = false;

        public int SearchSimilarityPercentage { get; set; } = 99;

        public int SearchThreadCount { get; set; } = Environment.ProcessorCount;

        public bool MergeFileTags { get; set; } = false;

        public bool OnlyKeepTagsInLibrary { get; set; } = false;

        public bool CropLeftRightSides { get; set; } = false;

        public bool CropTopBottomSides { get; set; } = false;

        public bool OnlyMatchSameFileTypes { get; set; } = true;

        public List<string> IgnoreDirectories { get; set; } = new();

        public List<string> IgnoreFiles { get; set; } = new();
    }
}
