namespace SorterExpress
{
    public class Duplicate
    {
        public string File1 { get; private set; }
        public string File2 { get; private set; }

        /// <summary>
        /// 0 to 1 likely hood of match.
        /// </summary>
        public float Chance { get; private set; }

        public int DifferenceCount { get; private set; }

        public Duplicate(FilePrint fp1, FilePrint fp2)
        {
            this.File1 = fp1.file;
            this.File2 = fp2.file;

            DifferenceCount = 0;

            for (int i = 0; i < fp1.print.Length; i++)
            {
                if (fp1.print[i] != fp2.print[i])
                {
                    DifferenceCount++;
                }
            }

            Chance = 1 - ((float)DifferenceCount / (float)64);
        }

        public override string ToString()
        {
            return $"Chance: {Chance * 100}%";
        }
    }
}
