namespace SorterExpress.Controls
{
    class SubfolderButton : System.Windows.Forms.Button
    {
        public SubfolderInfo subfolderInfo;

        public SubfolderButton() : base()
        {
            subfolderInfo = new SubfolderInfo();
        }

        public SubfolderButton(string name, string directory, bool custom) : base()
        {
            subfolderInfo = new SubfolderInfo(name, directory, custom);
        }
    }
}
