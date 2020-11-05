using Microsoft.VisualBasic.FileIO;
using Shell32;
using SorterExpress.Classes.Actions.SortActions;
using SorterExpress.Controllers;
using SorterExpress.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
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

        Duplicate duplicate;

        int duplicateIndex;

        /// <summary>
        /// A list of all duplicates removed that contained the removed file, including the originally removed duplicate.
        /// </summary>
        List<Tuple<int, Duplicate>> allDuplicatesWithFile;

        public DeleteBothSides(DuplicatesFormController controller, Duplicate duplicate, int matchIndex) : base(controller)
        {
            this.duplicate = duplicate;
            this.duplicateIndex = matchIndex;
        }

        public override void Do()
        {
            //controller.model.Duplicates.RemoveAt(duplicateIndex);

            allDuplicatesWithFile = new List<Tuple<int, Duplicate>>();

            for (int i = 0; i < controller.model.Duplicates.Count; i++)
            {
                if (controller.model.Duplicates[i].File1Path == duplicate.File1Path
                    || controller.model.Duplicates[i].File1Path == duplicate.File2Path
                    || controller.model.Duplicates[i].File2Path == duplicate.File1Path
                    || controller.model.Duplicates[i].File2Path == duplicate.File2Path)
                {
                    allDuplicatesWithFile.Add(new Tuple<int, Duplicate>(i, controller.model.Duplicates[i]));
                }
            }

            controller.form.mediaViewerLeft.UnloadMedia();
            controller.form.mediaViewerRight.UnloadMedia();

            //controller.IgnoreMatchSelectionChanged = allDuplicatesWithFile.Count;

            //Remove all duplicates from duplicates list (possibly raises issues).
            for (int i = 0; i < allDuplicatesWithFile.Count; i++)
            {
                //if (allDuplicatesWithFile[i].Item2 == duplicate)
                    //controller.IgnoreMatchSelectionChanged = 1;
                controller.model.Duplicates.Remove(allDuplicatesWithFile[i].Item2);
            }

            FileSystem.DeleteFile(duplicate.fileprint1.filepath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
            FileSystem.DeleteFile(duplicate.fileprint2.filepath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
            Successful = true;
            base.Do();
        }

        public override void Undo()
        {
            //TODO: Loading dialog for duplicates form.
            //controller.ShowLoading(LOADING_TITLE, LOADING_DESCRIPTION);

            bool leftItemFound = false,
                rightItemFound = false;
            Shell shell = new Shell();
            Folder recycler = shell.NameSpace(10);
            FolderItems items = recycler.Items();
            int count = items.Count;

            Parallel.For(0, count,
                (i, state) =>
                {
                    if (leftItemFound && rightItemFound)
                    {
                        state.Break();
                    }

                    FolderItem folderItem = items.Item(i);

                    string itemFilename = recycler.GetDetailsOf(folderItem, 0);
                    if (Path.GetExtension(itemFilename) == "")
                        itemFilename += Path.GetExtension(folderItem.Path);     //Necessary for systems with hidden file extensions.

                    string itemPath = recycler.GetDetailsOf(folderItem, 1);

                    if (!leftItemFound && duplicate.fileprint1.filepath == Path.Combine(itemPath, itemFilename))
                    {
                        DoVerb(folderItem, "ESTORE");
                        leftItemFound = true;
                    }
                    else if (!rightItemFound && duplicate.fileprint2.filepath == Path.Combine(itemPath, itemFilename))
                    {
                        DoVerb(folderItem, "ESTORE");
                        rightItemFound = true;
                    }
                });


            if (leftItemFound && rightItemFound)
            {
                //File should be recovered by this point.
                //controller.ReloadMatch(Path.GetFileName(leftFilepath), duplicateIndex);
                controller.model.Duplicates.Insert(duplicateIndex, duplicate);
                controller.form.matchesDataGridView.CurrentCell = controller.form.matchesDataGridView.Rows[duplicateIndex].Cells[0];
                controller.MatchSelectionChanged();
                Successful = true;
            }
            else if (leftItemFound || rightItemFound)
            {
                string side = leftItemFound ? "right" : "left";

                System.Windows.Forms.MessageBox.Show(
                    $"The {side} file could be found in the recycling bin and thus could not be undeleted. " +
                    "You can attempt to search for the file yourself.",
                    "Delete Undo Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Successful = true;
            }
            else //Neither found.
            {
                System.Windows.Forms.MessageBox.Show(
                    "Neither file could be found in the recycling bin and thus could not be undeleted. " +
                    "You can attempt to search for the files yourself.",
                    "Delete Undo Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Successful = false;
            }

            //controller.HideLoading();

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
