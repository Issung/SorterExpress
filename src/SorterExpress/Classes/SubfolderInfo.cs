namespace SorterExpress
{
    public class SubfolderInfo
    {
        /// <summary>
        /// UI Display name.
        /// </summary>
        public string Name;

        /// <summary>
        /// Folder path.
        /// </summary>
        public string Directory;
        
        /// <summary>
        /// Is or is not a folder folder added by the user.
        /// </summary>
        public bool Custom;

        public SubfolderInfo()
        {
            Name = null;
            Directory = null;
            Custom = false;
        }

        public SubfolderInfo(string name, string directory, bool custom)
        {
            this.Name = name;
            this.Directory = directory;
            this.Custom = custom;
        }

        public override string ToString()
        {
            return $"{{SubfolderInfo: Name: {Name}, Directory: {Directory}, Custom: {Custom}}}";
        }
    }
}
