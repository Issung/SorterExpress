using Microsoft.VisualBasic.FileIO;
using Shell32;
using SorterExpress.Controllers;
using SorterExpress.Model.Duplicates;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SorterExpress.Classes.Actions.DuplicateActions
{
    /// <summary>
    /// The genius for undoing a delete (user "jams"): https://stackoverflow.com/a/6025331/8306962
    /// </summary>
    class DeleteBothSides : DuplicateAction
    {
        const string LOADING_TITLE = "Undeleting File...";

        const string LOADING_DESCRIPTION = "To undelete a file the recycle bin must be searched to find it. " +
            "If this is taking a long time, consider emptying your recycle bin to make it faster to search through.";

        readonly Duplicate duplicate;
        readonly int duplicateIndex;

        /// <summary>
        /// A list of all duplicates removed that contained the removed file, including the originally removed duplicate.
        /// </summary>
        List<RemovedDuplicate> allDuplicatesWithFile;

        public DeleteBothSides(DuplicatesFormController controller, Duplicate duplicate, int matchIndex) : base(controller)
        {
            this.duplicate = duplicate;
            this.duplicateIndex = matchIndex;
        }

        public override void Do()
        {
            //controller.model.Duplicates.RemoveAt(duplicateIndex);

            allDuplicatesWithFile = new();

            for (int i = 0; i < controller.model.Duplicates.Count; i++)
            {
                if (controller.model.Duplicates[i].File1Path == duplicate.File1Path
                    || controller.model.Duplicates[i].File1Path == duplicate.File2Path
                    || controller.model.Duplicates[i].File2Path == duplicate.File1Path
                    || controller.model.Duplicates[i].File2Path == duplicate.File2Path)
                {
                    allDuplicatesWithFile.Add(new RemovedDuplicate(i, controller.model.Duplicates[i]));
                }
            }

            // If this duplicate is the one currently being viewed unload media for both sides.
            if (duplicate == controller.inspectingDuplicate)
            { 
                controller.form.mediaViewerLeft.UnloadMedia(true);
                controller.form.mediaViewerRight.UnloadMedia(true);
            }

            //Remove all duplicates from duplicates list (possibly raises issues).
            for (int i = 0; i < allDuplicatesWithFile.Count; i++)
            {
                //if (allDuplicatesWithFile[i].Item2 == duplicate)
                    //controller.IgnoreMatchSelectionChanged = 1;
                controller.model.Duplicates.Remove(allDuplicatesWithFile[i].Duplicate);
            }

            controller.model.Files.Remove(duplicate.File1Path);
            controller.model.Files.Remove(duplicate.File2Path);
            FileSystem.DeleteFile(duplicate.fileprint1.Filepath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
            FileSystem.DeleteFile(duplicate.fileprint2.Filepath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
            Successful = true;
            base.Do();
        }

        public override void Undo()
        {
            var leftItemFound = false;
            var rightItemFound = false;
            var shell = new Shell();
            var recycler = shell.NameSpace(10);
            var items = recycler.Items();
            var count = items.Count;

            Parallel.For(0, count,
                (i, state) =>
                {
                    if (leftItemFound && rightItemFound)
                    {
                        state.Break();
                    }

                    var folderItem = items.Item(i);

                    var itemFilename = recycler.GetDetailsOf(folderItem, 0);
                    if (Path.GetExtension(itemFilename) == "")
                    {
                        itemFilename += Path.GetExtension(folderItem.Path);     // Necessary for systems with hidden file extensions.
                    }

                    var itemPath = recycler.GetDetailsOf(folderItem, 1);

                    if (!leftItemFound && duplicate.fileprint1.Filepath == Path.Combine(itemPath, itemFilename))
                    {
                        DoVerb(folderItem, "ESTORE");
                        controller.model.Files.Add(duplicate.File1Path);
                        leftItemFound = true;
                    }
                    else if (!rightItemFound && duplicate.fileprint2.Filepath == Path.Combine(itemPath, itemFilename))
                    {
                        DoVerb(folderItem, "ESTORE");
                        controller.model.Files.Add(duplicate.File2Path);
                        rightItemFound = true;
                    }
                });


            if (leftItemFound && rightItemFound)
            {
                // File should be recovered by this point.

                // Reinsert all duplicate entries that had that the recovered files.
                for (int i = 0; i < allDuplicatesWithFile.Count; i++)
                {
                    controller.model.Duplicates.Insert(allDuplicatesWithFile[i].Index, allDuplicatesWithFile[i].Duplicate);
                }

                controller.form.matchesDataGridView.CurrentCell = controller.form.matchesDataGridView.Rows[duplicateIndex].Cells[0];
                controller.MatchSelectionChanged();
                Successful = true;
            }
            else if (leftItemFound || rightItemFound)
            {
                string side = leftItemFound ? "right" : "left";

                MessageBox.Show(
                    $"The {side} file could not be found in the recycling bin and thus could not be undeleted. " +
                    "You can attempt to search for the file yourself.",
                    "Delete Undo Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Successful = true;
            }
            else // Neither found.
            {
                MessageBox.Show(
                    "Neither file could be found in the recycling bin and thus could not be undeleted. " +
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
