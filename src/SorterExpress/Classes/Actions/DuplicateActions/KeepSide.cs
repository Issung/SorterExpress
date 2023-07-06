using Microsoft.VisualBasic.FileIO;
using Shell32;
using SorterExpress.Classes.SettingsData;
using SorterExpress.Controllers;
using SorterExpress.Model.Duplicates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SorterExpress.Classes.Actions.DuplicateActions
{
    /// <summary>
    /// The genius for undoing a delete (user "jams"): https://stackoverflow.com/a/6025331/8306962
    /// </summary>
    class KeepSide : DuplicateAction
    {
        const string LOADING_TITLE = "Undeleting File...";

        const string LOADING_DESCRIPTION = "To undelete a file the recycle bin must be searched to find it. " +
            "If this is taking a long time, consider emptying your recycle bin to make it faster to search through.";

        readonly Duplicate duplicate;
        readonly int duplicateIndex;
        readonly Side keptSide;

        string keptFileFilepath => keptSide == Side.Left ? duplicate.fileprint1.Filepath : duplicate.fileprint2.Filepath; 

        string keptFileNewName;

        string deletedFileFilepath => keptSide == Side.Left ? duplicate.fileprint2.Filepath : duplicate.fileprint1.Filepath;

        /// <summary>
        /// A list of all duplicates removed that contained the removed file, including the originally removed duplicate.
        /// </summary>
        List<RemovedDuplicate> allDuplicatesWithFile;

        public KeepSide(DuplicatesFormController controller, Duplicate duplicate, int matchIndex, Side keptSide) : base(controller)
        {
            this.duplicate = duplicate;
            this.duplicateIndex = matchIndex;
            this.keptSide = keptSide;
        }

        public override void Do()
        {
            //controller.model.Duplicates.RemoveAt(duplicateIndex);

            allDuplicatesWithFile = new();

            for (int i = 0; i < controller.model.Duplicates.Count; i++)
            {
                if (controller.model.Duplicates[i].File1Path == deletedFileFilepath || controller.model.Duplicates[i].File2Path == deletedFileFilepath)
                {
                    allDuplicatesWithFile.Add(new RemovedDuplicate(i, controller.model.Duplicates[i]));
                }
            }

            //If this duplicate is the one currently being viewed unload media for appropriate side
            if (duplicate == controller.inspectingDuplicate)
            { 
                (keptSide == Side.Left ? controller.form.mediaViewerRight : controller.form.mediaViewerLeft).UnloadMedia(true);
            }

            //Remove all duplicates from duplicates list (possibly raises issues).
            for (int i = 0; i < allDuplicatesWithFile.Count; i++)
            {
                controller.model.Duplicates.Remove(allDuplicatesWithFile[i].Duplicate);
            }

            controller.model.Files.Remove(deletedFileFilepath);
            FileSystem.DeleteFile(deletedFileFilepath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);

            //TODO: Decide if we want to get these properties from Settings or from the model...
            //if (Settings.Default.DuplicatesMergeFileTags) 
            if (controller.model.MergeFileTags)
            {
                FileDetails details = Utilities.GetFileDetails(keptFileFilepath);
                details.Combine(Utilities.GetFileDetails(deletedFileFilepath));

                //if (Settings.Default.DuplicatesOnlyKeepTagsInLibrary)
                if (controller.model.OnlyKeepTagsThatAreInLibrary)
                { 
                    details.RemoveTagsNotInCollection(Settings.Default.Tags);   //This should be fine because duplicates form doesnt mess with the tag collection.
                }

                keptFileNewName = details.GenerateFilename();
                File.Move(keptFileFilepath, Path.Combine(Path.GetDirectoryName(keptFileFilepath), keptFileNewName));
            }

            Successful = true;
            base.Do();
        }

        public override void Undo()
        {
            var fileRecovered = false;
            var shell = new Shell();
            var recycler = shell.NameSpace(10);
            var items = recycler.Items();
            var count = items.Count;

            Parallel.For(0, count,
                (i, state) =>
                {
                    var folderItem = items.Item(i);

                    var itemFilename = recycler.GetDetailsOf(folderItem, 0);
                    if (Path.GetExtension(itemFilename) == "")
                    {
                        itemFilename += Path.GetExtension(folderItem.Path);     // Necessary for systems with hidden file extensions.
                    }

                    var itemPath = recycler.GetDetailsOf(folderItem, 1);

                    if (deletedFileFilepath == Path.Combine(itemPath, itemFilename))
                    {
                        DoVerb(folderItem, "ESTORE");
                        controller.model.Files.Add(deletedFileFilepath);
                        fileRecovered = true;
                        state.Break();
                    }
                });

            if (fileRecovered)
            {
                // File should be recovered by this point.

                // If the kept file was renamed change its name back to what it was.
                if (!string.IsNullOrWhiteSpace(keptFileNewName))
                { 
                    File.Move(Path.Combine(Path.GetDirectoryName(keptFileFilepath), keptFileNewName), keptFileFilepath);
                }

                // Reinsert all duplicate entries that had that the recovered file.
                for (int i = 0; i < allDuplicatesWithFile.Count; i++)
                {
                    var index = Utilities.Clamp(allDuplicatesWithFile[i].Index, 0, controller.model.Duplicates.Count);
                    controller.model.Duplicates.Insert(index, allDuplicatesWithFile[i].Duplicate);
                }

                controller.form.matchesDataGridView.CurrentCell = controller.form.matchesDataGridView.Rows[duplicateIndex].Cells[0];
                controller.MatchSelectionChanged();
                Successful = true;
            }
            else
            {
                MessageBox.Show(
                    "The deleted file could be found in the recycling bin and thus could not be undeleted. " +
                    "You can attempt to search for the files yourself.",
                    "Delete Undo Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Successful = false;
            }

            base.Undo();
        }

        private bool DoVerb(FolderItem item, string verb)
        {
            foreach (FolderItemVerb FIVerb in item.Verbs())
            {
                if (FIVerb.Name.ToUpper().Contains(verb.ToUpper()))
                {
                    FIVerb.DoIt();
                    return true;
                }
            }

            return false;
        }
    }
}
