using System.ComponentModel.DataAnnotations.Schema;

namespace SorterExpress.Data.Model
{
    public class AutoClassificationWeights
    {
        public float Hentai { get; set; }

        public float Neutral { get; set; }

        public float Pornography { get; set; }

        public float Sexy { get; set; }

        public string PredictedLabel { get; set; }

        [NotMapped]
        public bool IsNsfw => (double)Neutral < 0.5;

        public Dictionary<string, float> ToDictionary()
        {
            return new Dictionary<string, float>
            {
                { "Hentai", Hentai },
                { "Neutral", Neutral },
                { "Pornography", Pornography },
                { "Sexy", Sexy }
            }.OrderByDescending((p) => p.Value).ToDictionary((x) => x.Key, (x) => x.Value);
        }
    }
}
