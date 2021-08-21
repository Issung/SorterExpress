using GChan.Controls;
using SorterExpress.Classes.Actions.DuplicateActions;
using SorterExpress.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SorterExpress.Models
{
    public class DuplicatesFormModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            Console.WriteLine($"NotifyPropertyChanged! propertyName: {propertyName}");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public enum FormState { NoDirectoryOpen, DirectoryOpen, Searching, Sorting };

        public FormState State { get { return FindState(); } }

        private FormState FindState()
        {
            if (String.IsNullOrWhiteSpace(directory))
            {
                //Console.WriteLine("FindState returns NoDirectoryOpen.");
                return FormState.NoDirectoryOpen;
            }

            // A directory is open from this point down.

            if (searching)
            {
                //Console.WriteLine("FindState returns Searching.");
                return FormState.Searching;
            }

            if (Duplicates.Count > 0)
            {
                //Console.WriteLine("FindState returns Sorting.");
                return FormState.Sorting;
            }

            //Console.WriteLine("FindState returns DirectoryOpen.");
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

        private string directory;
        public string Directory { get { return directory; } set { directory = value; /*NotifyPropertyChanged();*/ UpdateVisibilityAndEnabledProperties(); } }

        public Stack<DuplicateAction> DoneActions { get; set; } = new Stack<DuplicateAction>();

        public bool EnableUndoButton { get { return DoneActions.Count > 0; } }//{ get { return DoneActions != null ? DoneActions.Count > 0 : false; } }

        public Stack<DuplicateAction> UndoneActions { get; set; } = new Stack<DuplicateAction>();

        public bool EnableRedoButton { get { return UndoneActions.Count > 0; } }//{ get { return UndoneActions != null ? UndoneActions.Count > 0 : false; } }

        private bool searching = false;

        public bool Searching { get { return searching; } set { searching = value; NotifyPropertyChanged(); UpdateVisibilityAndEnabledProperties(); } }

        public List<string> Files = new List<string>();

        //public SortableBindingList<Duplicate> Duplicates { get; set; } = new SortableBindingList<Duplicate>();
        public BindingList<Duplicate> Duplicates { get; set; } = new BindingList<Duplicate>();

        public enum SearchScope
        {
            [Description("Immediate Directory Only")] ImmediateOnly,
            [Description("Subdirectories Only")] SubdirsOnly,
            [Description("Between Immediate and Subdirectories")] BetweenImmediateAndSubdirs,
            [Description("Search All Files")] All
        }

        private SearchScope searchScopeSelectedValue = SearchScope.ImmediateOnly;
        private bool searchImages = Settings.Default.DuplicatesSearchImages;
        private bool searchVideos = Settings.Default.DuplicatesSearchVideos;
        private bool onlyMatchSameFileTypes = Settings.Default.DuplicatesOnlyMatchSameFileTypes;
        private bool cropLeftAndRight = Settings.Default.DuplicatesCropLeftRightSides;
        private bool cropTopAndBottom = Settings.Default.DuplicatesCropTopBottomSides;
        private int threadCount = Settings.Default.DuplicatesSearchThreadCount == 0 ? Environment.ProcessorCount : Settings.Default.DuplicatesSearchThreadCount;
        private int similarity = Settings.Default.DuplicatesSearchSimilarityPercentage;
        private bool mergeFileTags = Settings.Default.DuplicatesMergeFileTags;
        private bool onlyKeepTagsThatAreInLibrary = Settings.Default.DuplicatesOnlyKeepTagsInLibrary;

        #region View Variables

        public int FileCount => Files == null ? 0 : Files.Count;

        public string FileAndMatchesCountText => $"Files: {(Files?.Count ?? 0)} Matches: {(Duplicates?.Count ?? 0)}";

        public bool EnableOnlyKeepTagsInLibraryButton => StateDirectoryOpenOrSorting && MergeFileTags;

        public bool EnableMatchFileTypesCheckBox => StateDirectoryOpenOrSorting && SearchVideos && SearchImages;

        #endregion

        //User options in form
        public SearchScope SearchScopeSelectedValue { get { return searchScopeSelectedValue; } set { searchScopeSelectedValue = value; NotifyPropertyChanged(); } }
        public bool SearchImages { get { return searchImages; } set { searchImages = value; NotifyPropertyChanged(); } }
        public bool SearchVideos { get { return searchVideos; } set { searchVideos = value; NotifyPropertyChanged(); } }
        public bool OnlyMatchSameFileTypes { get { return onlyMatchSameFileTypes; } set { onlyMatchSameFileTypes = value; NotifyPropertyChanged(); } }
        public bool CropLeftAndRight { get { return cropLeftAndRight; } set { cropLeftAndRight = value; NotifyPropertyChanged(); } }
        public bool CropTopAndBottom { get { return cropTopAndBottom; } set { cropTopAndBottom = value; NotifyPropertyChanged(); } }
        public int ThreadCount { get { return threadCount; } set { threadCount = value; NotifyPropertyChanged(); } }
        public int Similarity { get { return similarity; } set { similarity = value; NotifyPropertyChanged(); } }
        public bool MergeFileTags { get { return mergeFileTags; } set { mergeFileTags = value; NotifyPropertyChanged(); NotifyPropertyChanged(nameof(EnableOnlyKeepTagsInLibraryButton)); } }
        public bool OnlyKeepTagsThatAreInLibrary { get { return onlyKeepTagsThatAreInLibrary; } set { onlyKeepTagsThatAreInLibrary = value; NotifyPropertyChanged(); } }

        public DuplicatesFormModel()
        {
            Duplicates.RaiseListChangedEvents = true;
            Duplicates.ListChanged += Duplicates_ListChanged;
            Duplicates.AddingNew += Duplicates_AddingNew;
        }

        private void Duplicates_AddingNew(object sender, AddingNewEventArgs e)
        {
            Console.WriteLine($"Duplicates_AddingNew: Count: {Duplicates?.Count ?? 0}");
            NotifyPropertyChanged(nameof(FileAndMatchesCountText));
        }

        private void Duplicates_ListChanged(object sender, ListChangedEventArgs e)
        {
            Console.WriteLine($"Duplicates_ListChanged: Count: {Duplicates?.Count ?? 0}");
            NotifyPropertyChanged(nameof(FileAndMatchesCountText));
        }
    }
}
