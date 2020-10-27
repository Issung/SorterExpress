namespace SorterExpress
{
    public class SubfolderInfo
    {
        public string name;
        public string directory;
        public bool custom;

        public SubfolderInfo()
        {
            name = null;
            directory = null;
            custom = false;
        }

        public SubfolderInfo(string name, string directory, bool custom)
        {
            this.name = name;
            this.directory = directory;
            this.custom = custom;
        }

        public override string ToString()
        {
            return $"{{SubfolderInfo: Name: {name}, Directory: {directory}, Custom: {custom}}}";
        }
    }
}
