using SorterExpress.Controllers;

namespace SorterExpress.Classes.Actions.DuplicateActions
{
    public class DuplicateAction : Action
    {
        protected DuplicatesFormController controller;

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
