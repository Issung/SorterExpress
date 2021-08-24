using SorterExpress.Controllers;
using SorterExpress.Model.Duplicates;

namespace SorterExpress.Classes.Actions.DuplicateActions
{
    /// <summary>
    /// The genius for undoing a delete (user "jams"): https://stackoverflow.com/a/6025331/8306962
    /// </summary>
    class Skip : DuplicateAction
    {
        const string LOADING_TITLE = "Undeleting File...";

        const string LOADING_DESCRIPTION = "To undelete a file the recycle bin must be searched to find it. " +
            "If this is taking a long time, consider emptying your recycle bin to make it faster to search through.";

        Duplicate duplicate;

        int duplicateIndex;

        public Skip(DuplicatesFormController controller, Duplicate duplicate, int matchIndex) : base(controller)
        {
            this.duplicate = duplicate;
            this.duplicateIndex = matchIndex;
        }

        public override void Do()
        {
            controller.model.Duplicates.RemoveAt(duplicateIndex);
            Successful = true;
            base.Do();
        }

        public override void Undo()
        {
            controller.model.Duplicates.Insert(duplicateIndex, duplicate);
            controller.form.matchesDataGridView.CurrentCell = controller.form.matchesDataGridView.Rows[duplicateIndex].Cells[0];
            controller.MatchSelectionChanged();
            Successful = true;
            base.Undo();
        }
    }
}
