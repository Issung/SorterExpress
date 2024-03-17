using NsfwSpyNS;
using SorterExpress.Classes.SettingsData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;

#nullable enable

namespace SorterExpress.Models
{
    public class NsfwSortModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            Console.WriteLine($"NotifyPropertyChanged! propertyName: {propertyName}");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public enum FormState { NoDirectoryOpen, DirectoryOpen, Searching, Sorting };

        public FormState State { get { return FindState(); } }

        private FormState FindState()
        {
            if (string.IsNullOrWhiteSpace(directory))
            {
                //Debug.WriteLine("FindState returns NoDirectoryOpen.");
                return FormState.NoDirectoryOpen;
            }

            if (searching)
            {
                //Debug.WriteLine("FindState returns Searching.");
                return FormState.Searching;
            }

            if (Results.Count > 0)
            {
                //Debug.WriteLine("FindState returns Sorting.");
                return FormState.Sorting;
            }

            //Debug.WriteLine("FindState returns DirectoryOpen.");
            return FormState.DirectoryOpen;
        }

        private void UpdateVisibilityAndEnabledProperties()
        {
            string[] propertyNames = {
                nameof(StateDirectoryOpen),
                nameof(StateSearching),
                nameof(StateNotSearching),
                nameof(StateSorting),
                nameof(StateDirectoryOpenOrSorting),
                nameof(EnableOnlyKeepTagsInLibraryButton)
            };

            for (int i = 0; i < propertyNames.Length; i++)
            {
                NotifyPropertyChanged(propertyNames[i]);
            }
        }

        public bool StateDirectoryOpen { get { return State == FormState.DirectoryOpen; } }

        public bool StateDirectoryOpenOrSorting { get { return State == FormState.DirectoryOpen || State == FormState.Sorting; } }

        public bool StateSearching { get { return State == FormState.Searching; } }

        public bool StateNotSearching { get { return State != FormState.Searching; } }

        public bool StateSorting { get { return State == FormState.Sorting; } }

        public bool StateViewing => FilteredResults.Count > 0;

        private string? directory;
        public string? Directory { get { return directory; } set { directory = value; UpdateVisibilityAndEnabledProperties(); } }

        //public Stack<DuplicateAction> DoneActions { get; set; } = new Stack<DuplicateAction>();
        //public Stack<DuplicateAction> UndoneActions { get; set; } = new Stack<DuplicateAction>();
        //public bool EnableUndoButton { get { return DoneActions.Count > 0; } }
        //public bool EnableRedoButton { get { return UndoneActions.Count > 0; } }

        private bool searching = false;

        public bool Searching { get { return searching; } set { searching = value; NotifyPropertyChanged(); UpdateVisibilityAndEnabledProperties(); } }

        public List<string> Files = [];

        /// <summary>
        /// Results for code management.
        /// </summary>
        public List<NsfwSortFileResult> Results { get; set; } = [];
        
        /// <summary>
        /// Results to be displayed/bound to in the UI.
        /// </summary>
        public BindingList<NsfwSortFileResult> FilteredResults { get { return filteredResults; } set { filteredResults = value; NotifyPropertyChanged(); } }

        private BindingList<NsfwSortFileResult> filteredResults = [];
        private SearchScope searchScope = SearchScope.ImmediateOnly;
        private bool searchImages = Settings.Default.DuplicateSearch.SearchImages;
        private bool searchVideos = Settings.Default.DuplicateSearch.SearchVideos;
        private int threadCount = Settings.Default.DuplicateSearch.SearchThreadCount < 1 ? Environment.ProcessorCount : Settings.Default.DuplicateSearch.SearchThreadCount;
        private Classification resultsFilter = Classification.All;

        #region View Variables

        public int FileCount => Files == null ? 0 : Files.Count;

        public string FileAndMatchesCountText => $"{Results.Count}/{Files?.Count ?? 0}";

        public bool EnableOnlyKeepTagsInLibraryButton => StateDirectoryOpenOrSorting;

        public bool EnableMatchFileTypesCheckBox => StateDirectoryOpenOrSorting && SearchVideos && SearchImages;

        #endregion

        //User options in form
        public SearchScope SearchScope { get { return searchScope; } set { searchScope = value; NotifyPropertyChanged(); } }
        public bool SearchImages { get { return searchImages; } set { searchImages = value; NotifyPropertyChanged(); } }
        public bool SearchVideos { get { return searchVideos; } set { searchVideos = value; NotifyPropertyChanged(); } }
        public int ThreadCount { get { return threadCount; } set { threadCount = value; NotifyPropertyChanged(); } }
        public Classification ResultsFilter { get { return resultsFilter; } set { resultsFilter = value; NotifyPropertyChanged(); } }

        public NsfwSortModel()
        {
            FilteredResults.RaiseListChangedEvents = true;
            FilteredResults.ListChanged += Results_ListChanged;
            FilteredResults.AddingNew += Results_AddingNew;
        }

        private void Results_AddingNew(object? sender, AddingNewEventArgs e)
        {
            Console.WriteLine($"Results_AddingNew: Count: {Results.Count}");
            NotifyPropertyChanged(nameof(FileAndMatchesCountText));
        }

        public void Results_ListChanged(object? sender, ListChangedEventArgs e)
        {
            Console.WriteLine($"Results_ListChanged: Count: {Results.Count}");
            NotifyPropertyChanged(nameof(StateViewing));
            NotifyPropertyChanged(nameof(FileAndMatchesCountText));
        }

        private readonly object resultsLock = new();

        public void ResultsAdd(NsfwSortFileResult result)
        {
            lock (resultsLock)
            {
                Results.Add(result);

                if (ResultsFilter == Classification.All || ResultsFilter == result.Classification)
                { 
                    FilteredResults.Add(result);
                }
            }
        }

        public void ResultsRemove(NsfwSortFileResult result)
        {
            lock (resultsLock)
            {
                Results.Remove(result);
                FilteredResults.Remove(result);
            }
        }

        public void ResultsClear()
        {
            lock (resultsLock)
            {
                Results.Clear();
                FilteredResults.Clear();
            }
        }

        public void SetFilteredResults(List<NsfwSortFileResult> results)
        {
            lock (resultsLock)
            {
                FilteredResults.Clear();
                foreach (var result in results)
                {
                    FilteredResults.Add(result);
                }
            }
        }

        public void ClassificationOfResultChanged(NsfwSortFileResult result)
        {
            if (ResultsFilter == Classification.All)
            {
                return;
            }

            if (result.Classification != ResultsFilter)
            {
                lock (resultsLock)
                {
                    FilteredResults.Remove(result);
                }
            }
        }
    }

    /// <summary>
    /// File classification types.<br/>
    /// </summary>
    public enum Classification
    {
        /// <summary>Only exists for UI filtering. No file can be classified as "All".</summary>
        All,
        Neutral,
        Sexy,
        Hentai,
        Pornography,
    }

    public class NsfwSortFileResult : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public string Path { get; set; }

        public Image Thumb { get; set; }

        /// <summary>
        /// Classification weights found by NsfwSpy.
        /// </summary>
        public NsfwSpyResult ClassificationWeights { get; set; }

        /// <summary>
        /// A manual classification override set by the user.
        /// </summary>
        public Classification? ClassificationOverride
        {
            get => classificationOverride;
            set
            { 
                classificationOverride = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ClassificationOverride)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ClassificationViewString)));
            }
        }

        public Classification Classification => ClassificationOverride ?? Enum.Parse<Classification>(ClassificationWeights.ToDictionary().MaxBy(kvp => kvp.Value).Key);

        /// <summary>
        /// Bound to in UI for result column display.<br/>
        /// If Neutral then return empty string so UI is easier to use at a glance.
        /// </summary>
        public string ClassificationViewString => Classification == Classification.Neutral ? string.Empty : Classification.ToString();

        private Classification? classificationOverride = null;
    }
}
