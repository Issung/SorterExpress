using Microsoft.EntityFrameworkCore;

namespace SorterExpress.Data.Model
{
    /// <summary>
    /// Data about a given file location at <see cref="Path"/>.
    /// Use to store expensive-to-computate data such as hashes, machine-learning weights, dimensions.
    /// </summary>
    [PrimaryKey(nameof(Path))]
    public class FileData
    {
        public string Path { get; set; }

        public AutoClassificationWeights? AutoClassificationWeights { get; set; }

        public FileData(string path)
        {
            Path = path;
        }
    }
}
