using Microsoft.VisualBasic.FileIO;
using Shell32;
using SorterExpress.Controllers;
using SorterExpress.Forms;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace SorterExpress.Classes.Actions.SortActions
{
    /// <summary>
    /// The genius for undoing (user "jams"): https://stackoverflow.com/a/6025331/8306962
    /// </summary>
    class Delete : SortAction
    {
        const string LOADING_TITLE = "Undeleting File...";
        
        const string LOADING_DESCRIPTION = "To undelete a file the recycle bin must be searched to find it. " +
            "If this is taking a long time, consider emptying your recycle bin to make it faster to search through.";

        string filepath;

        int fileIndex;

        public Delete(SortController controller, string filepath, int fileIndex) : base(controller)
        {
            this.filepath = filepath;
            this.fileIndex = fileIndex;
        }

        public override void Do()
        {
            controller.RemoveFile(fileIndex);
            FileSystem.DeleteFile(filepath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
            Successful = true;
            base.Do();
        }

        public override void Undo()
        {
            controller.ShowLoading(LOADING_TITLE, LOADING_DESCRIPTION);

            bool itemFound = false;
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
                        itemFilename += Path.GetExtension(folderItem.Path);

                    //Necessary for systems with hidden file extensions.
                    string itemPath = recycler.GetDetailsOf(folderItem, 1);
                    if (filepath == Path.Combine(itemPath, itemFilename))
                    {
                        DoVerb(folderItem, "ESTORE");
                        itemFound = true;
                        state.Break();  //break;
                    }
                });

            /*for (int i = 0; i < count; i++)
            {
                FolderItem folderItem = items.Item(i);

                string FileName = recycler.GetDetailsOf(folderItem, 0);
                if (Path.GetExtension(FileName) == "")
                    FileName += Path.GetExtension(folderItem.Path);

                //Necessary for systems with hidden file extensions.
                string FilePath = recycler.GetDetailsOf(folderItem, 1);
                if (filepath == Path.Combine(FilePath, FileName))
                {
                    DoVerb(folderItem, "ESTORE");
                    itemFound = true;
                    break;
                }
            }*/

            if (itemFound)
            {
                //File should be recovered by this point.
                controller.ReloadFile(Path.GetFileName(filepath), fileIndex);

                Successful = true;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(
                    "The file could not be found in the recycling bin and thus could not be undeleted. " + 
                    "You can attempt to search for it yourself.", 
                    "Delete Undo Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Successful = false;
            }

            controller.HideLoading();

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
