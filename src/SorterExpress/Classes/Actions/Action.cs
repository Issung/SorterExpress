namespace SorterExpress.Classes.Actions
{
    public abstract class Action
    {
        /// <summary>
        /// Was the last undo/redo successful. Set to false if something goes wrong in the undo/redo process.
        /// </summary>
        public bool Successful { get; protected set; } = true;
    }
}
