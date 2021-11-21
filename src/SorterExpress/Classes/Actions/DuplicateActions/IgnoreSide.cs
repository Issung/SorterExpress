using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SorterExpress.Classes.SettingsData;
using SorterExpress.Controllers;
using SorterExpress.Model.Duplicates;

namespace SorterExpress.Classes.Actions.DuplicateActions
{
    /// <summary>
    /// Ignore a file.
    /// (Add to ignore settings.)
    /// </summary>
    class IgnoreSide : DuplicateAction
    {
        readonly Duplicate duplicate;
        readonly IgnoreType ignoreType;
        readonly Side ignoreSide;
        readonly int duplicateIndexInList;

        /// <summary>
        /// Path to be ignored, if <see cref="ignoreType"/> is Directory then this will be the directory of the given file, if not then it will be the full path to the individual file.
        /// </summary>
        readonly string ignorePath;

        /// <summary>
        /// Ignore settings list to modify.
        /// </summary>
        List<String> settings => (ignoreType == IgnoreType.Directory) ? Settings.Default.DuplicateSearch.IgnoreDirectories : Settings.Default.DuplicateSearch.IgnoreFiles;

        /// <summary>
        /// A list of all duplicates removed that contained the ignored file(s).
        /// </summary>
        List<RemovedDuplicate> removedDuplicates;

        public IgnoreSide(DuplicatesFormController controller, Duplicate duplicate, IgnoreType ignoreType, Side ignoreSide) : base(controller)
        {
            this.duplicate = duplicate;
            this.ignoreType = ignoreType;
            this.ignoreSide = ignoreSide;
            this.duplicateIndexInList = controller.model.Duplicates.IndexOf(duplicate);

            string file = ignoreSide == Side.Left ? duplicate.File1Path : duplicate.File2Path;
            this.ignorePath = ignoreType == IgnoreType.Directory ? Path.GetDirectoryName(file) : file;
        }

        bool ShouldBeRemoved(Duplicate duplicate)
        {
            var paths = new[] { duplicate.File1Path, duplicate.File2Path };

            if (ignoreType == IgnoreType.Directory)
            {
                return paths.Any(t => t.StartsWith(ignorePath));
            }
            else
            {
                return paths.Any(t => t == ignorePath);
            }
        }

        public override void Do()
        {
            // Add path to ignore settings.
            settings.Add(ignorePath);

            // Find all duplicates that are going to be removed.
            removedDuplicates = new();

            for (int i = 0; i < controller.model.Duplicates.Count; i++)
            {
                Duplicate duplicate = controller.model.Duplicates[i];

                if (ShouldBeRemoved(duplicate))
                {
                    removedDuplicates.Add(new RemovedDuplicate(i, duplicate));

                    // Remove and step back an index because of the removal.
                    controller.model.Duplicates.RemoveAt(i);
                    i--;
                }
            }

            Successful = true;
            base.Do();
        }

        public override void Undo()
        {
            // Remove path from ignore settings.
            settings.Remove(ignorePath);

            // Reinsert all removed duplicate entries.
            for (int i = 0; i < removedDuplicates.Count; i++)
            {
                controller.model.Duplicates.Insert(removedDuplicates[i].Index, removedDuplicates[i].Duplicate);
            }

            // Re-select the originally removed duplicate.
            controller.form.matchesDataGridView.CurrentCell = controller.form.matchesDataGridView.Rows[duplicateIndexInList].Cells[0];
            controller.MatchSelectionChanged();
            Successful = true;

            base.Undo();
        }
    }
}
