using System;
using System.Collections.Generic;
using System.Linq;
using SorterExpress;

namespace SorterExpress.Classes
{
    public class FileDetails
    {
        public string[] Tags;
        public string Note;

        /// <summary>
        /// File extension including dot.
        /// </summary>
        public string FileExtension;
        public FileType FileType;

        /// <summary>
        /// Merge the tags and note of another file details into these details.
        /// Tags will remove duplicates and be ordered alphabetically once again.
        /// Notes will be seperated by a hyphen and 2 spaces (" - ") if there is a note in both objects.
        /// File extension and type of will remain from THIS object.
        /// </summary>
        public void Combine(FileDetails moreDetails)
        {
            Tags = Tags.Concat(moreDetails.Tags).Distinct().OrderBy(t => t).ToArray();

            List<string> notes = new List<string>();
            if (!string.IsNullOrWhiteSpace(Note))
                notes.Add(Note);
            if (!string.IsNullOrWhiteSpace(moreDetails.Note))
                notes.Add(moreDetails.Note);

            Note = string.Join(" - ", notes);
        }

        public string GenerateFilename()
        {
            string ret = "";

            ret += string.Join(" ", Tags);

            ret += !string.IsNullOrWhiteSpace(Note) ? $" ({Note})" : "";

            ret += FileExtension;

            return ret;
        }

        public int RemoveTagsNotInCollection(IEnumerable<string> collection)
        {
            var templist = Tags.ToList();
            int removedCount = templist.RemoveAll(t => !collection.Contains(t));
            Tags = templist.ToArray();
            return removedCount;
        }
    }
}
