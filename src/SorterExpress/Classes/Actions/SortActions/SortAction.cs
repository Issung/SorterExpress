using SorterExpress.Controllers;

namespace SorterExpress.Classes.Actions.SortActions
{
    abstract class SortAction : Action
    {
        protected SortController controller;

        public SortAction(SortController controller)
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
