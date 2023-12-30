using SorterExpress.Model.Duplicates;

namespace SorterExpress.Classes.Actions.DuplicateActions
{
    internal class RemovedDuplicate
    {
        /// <summary>
        /// The index this duplicate was at in the duplicates list before being removed.
        /// </summary>
        public readonly int Index;
        public readonly Duplicate Duplicate;

        public RemovedDuplicate(int index, Duplicate duplicate)
        {
            this.Index = index;
            this.Duplicate = duplicate;
        }
    }
}
