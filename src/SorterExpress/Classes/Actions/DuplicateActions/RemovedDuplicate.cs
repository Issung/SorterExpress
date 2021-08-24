using SorterExpress.Model.Duplicates;

namespace SorterExpress.Classes.Actions.DuplicateActions
{
    internal class RemovedDuplicate
    {
        public readonly int Index;
        public readonly Duplicate Duplicate;

        public RemovedDuplicate(int index, Duplicate duplicate)
        {
            this.Index = index;
            this.Duplicate = duplicate;
        }
    }
}
