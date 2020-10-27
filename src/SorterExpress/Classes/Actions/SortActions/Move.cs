using SorterExpress.Controllers;
using System.IO;

namespace SorterExpress.Classes.Actions.SortActions
{
    class Move : SortAction
    {
        /// <summary>
        /// The full filepath (directory and filename).
        /// </summary>
        string originalFilepath;

        /// <summary>
        /// The original filename.
        /// </summary>
        string originalFilename => Path.GetFileName(originalFilepath);

        /// <summary>
        /// The directory to move the file to.
        /// </summary>
        string toFilepath;

        /// <summary>
        /// The full filepath (directory and filename) the file was moved to.
        /// </summary>
        string movedFilepath;

        /// <summary>
        /// Enabled tags.
        /// </summary>
        public string[] tags { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        string note;

        /// <summary>
        /// The index of the file when the operation was performed.
        /// </summary>
        int fileIndex;

        public Move(SortController controller, string originalFilepath, string toFilepath, string[] tags, string note, int fileIndex) : base(controller)
        {
            this.originalFilepath = originalFilepath;
            this.toFilepath = toFilepath;
            this.tags = tags;
            this.note = note;
            this.fileIndex = fileIndex;
        }

        public override void Do()
        {
            controller.RemoveFile(fileIndex);

            movedFilepath = Utilities.MoveFile(
                originalFilepath, 
                Path.Combine(toFilepath, Utilities.GenerateFilename(originalFilename, tags, note, true)));

            Successful = true;

            base.Do();
        }

        public override void Undo()
        {
            File.Move(movedFilepath, originalFilepath);

            controller.ReloadFile(originalFilename, fileIndex, tags, note);

            Successful = true;

            base.Undo();
        }
    }
}
