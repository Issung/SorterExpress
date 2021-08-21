using Microsoft.VisualBasic.FileIO;
using Shell32;
using SorterExpress.Controllers;
using SorterExpress.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        DuplicatesFormController.Side keptSide;

        string keptFileFilepath { get { return keptSide == DuplicatesFormController.Side.Left ? duplicate.fileprint1.filepath : duplicate.fileprint2.filepath; } }

        string keptFileNewName;

        string deletedFileFilepath { get { return keptSide == DuplicatesFormController.Side.Left ? duplicate.fileprint2.filepath : duplicate.fileprint1.filepath;  } }

        Duplicate duplicate;

        int duplicateIndex;

        /// <summary>
        /// A list of all duplicates removed that contained the removed file, including the originally removed duplicate.
        /// </summary>
        List<Tuple<int, Duplicate>> allDuplicatesWithFile;

        public KeepSide(DuplicatesFormController controller, Duplicate duplicate, int matchIndex, DuplicatesFormController.Side keptSide) : base(controller)
        {
            this.duplicate = duplicate;
            this.duplicateIndex = matchIndex;
            this.keptSide = keptSide;
        }

        public override void Do()
        {
            //controller.model.Duplicates.RemoveAt(duplicateIndex);

            allDuplicatesWithFile = new List<Tuple<int, Duplicate>>();

            for (int i = 0; i < controller.model.Duplicates.Count; i++)
            {
                if (controller.model.Duplicates[i].File1Path == deletedFileFilepath || controller.model.Duplicates[i].File2Path == deletedFileFilepath)
                {
                    allDuplicatesWithFile.Add(new Tuple<int, Duplicate>(i, controller.model.Duplicates[i]));
                }
            }

            //If this duplicate is the one currently being viewed unload media for appropriate side
            if (duplicate == controller.inspectingDuplicate)
                (keptSide == DuplicatesFormController.Side.Left ? controller.form.mediaViewerRight : controller.form.mediaViewerLeft).UnloadMedia(true);

            //Remove all duplicates from duplicates list (possibly raises issues).
            for (int i = 0; i < allDuplicatesWithFile.Count; i++)
            {
                controller.model.Duplicates.Remove(allDuplicatesWithFile[i].Item2);
            }

            FileSystem.DeleteFile(deletedFileFilepath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);

            //TODO: Decide if we want to get these properties from Settings or from the model...
            //if (Settings.Default.DuplicatesMergeFileTags) 
            if (controller.model.MergeFileTags)
            {
                FileDetails details = Utilities.GetFileDetails(keptFileFilepath);
                details.Combine(Utilities.GetFileDetails(deletedFileFilepath));

                //if (Settings.Default.DuplicatesOnlyKeepTagsInLibrary)
                if (controller.model.OnlyKeepTagsThatAreInLibrary)
                    details.RemoveTagsNotInCollection(Settings.Default.Tags);   //This should be fine because duplicates form doesnt mess with the tag collection.

                keptFileNewName = details.GenerateFilename();
                File.Move(keptFileFilepath, Path.Combine(Path.GetDirectoryName(keptFileFilepath), keptFileNewName));
            }

            Successful = true;
            base.Do();
        }

        public override void Undo()
        {
            //TODO: Loading dialog for duplicates form.
            //controller.ShowLoading(LOADING_TITLE, LOADING_DESCRIPTION);

            bool fileRecovered = false;
            Shell shell = new Shell();
            Folder recycler = shell.NameSpace(10);
            FolderItems items = recycler.Items();
            int count = items.Count;

            Parallel.For(0, count,
                (i, state) =>
                {

                    FolderItem folderItem = items.Item(i);

                    string itemFilename = recycler.GetDetailsOf(folderItem, 0);
                    if (Path.GetExtension(itemFilename) == "")
                        itemFilename += Path.GetExtension(folderItem.Path);     //Necessary for systems with hidden file extensions.

                    string itemPath = recycler.GetDetailsOf(folderItem, 1);

                    if (deletedFileFilepath == Path.Combine(itemPath, itemFilename))
                    {
                        DoVerb(folderItem, "ESTORE");
                        fileRecovered = true;
                        state.Break();
                    }
                });


            if (fileRecovered)
            {
                //File should be recovered by this point.
                //controller.ReloadMatch(Path.GetFileName(leftFilepath), duplicateIndex);
                //controller.model.Duplicates.Insert(duplicateIndex, duplicate);

                //If the kept file was renamed change its name back to what it was.
                if (!string.IsNullOrWhiteSpace(keptFileNewName))
                    File.Move(Path.Combine(Path.GetDirectoryName(keptFileFilepath), keptFileNewName), keptFileFilepath);

                //Reinsert all duplicate entries that had that the recovered file.
                for (int i = 0; i < allDuplicatesWithFile.Count; i++)
                {
                    controller.model.Duplicates.Insert(allDuplicatesWithFile[i].Item1, allDuplicatesWithFile[i].Item2);
                }

                controller.form.matchesDataGridView.CurrentCell = controller.form.matchesDataGridView.Rows[duplicateIndex].Cells[0];
                controller.MatchSelectionChanged();
                Successful = true;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(
                    "The deleted file could be found in the recycling bin and thus could not be undeleted. " +
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
