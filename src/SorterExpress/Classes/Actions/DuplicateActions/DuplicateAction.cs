using SorterExpress.Controllers;

namespace SorterExpress.Classes.Actions.DuplicateActions
{
    public abstract class DuplicateAction : Action
    {
        protected readonly DuplicatesFormController controller;

        public DuplicateAction(DuplicatesFormController controller)
        {
            this.controller = controller;
        }

        public virtual void Do()
        {

        }

        public virtual void Undo()
        {

        }
    }
}
