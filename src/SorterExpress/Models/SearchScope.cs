using System.ComponentModel;

namespace SorterExpress.Models
{
    public enum SearchScope
    {
        [Description("Immediate Directory Only")]
        ImmediateOnly,

        [Description("Subdirectories Only")]
        SubdirsOnly,

        [Description("Between Immediate and Subdirectories")]
        BetweenImmediateAndSubdirs,

        [Description("Search All Files")]
        All,
    }
}
