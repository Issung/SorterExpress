using System.Linq;
using System.Collections.Generic;

namespace SorterExpress
{
    public class Move
    {
        public string from;
        public string to;
        public string[] enabledTags;
        public string note;

        public Move(string from, string to, IEnumerable<string> tags, string note)
        {
            this.from = from;
            this.to = to;
            this.enabledTags = tags.ToArray();
            this.note = note;
        }
    }
}
