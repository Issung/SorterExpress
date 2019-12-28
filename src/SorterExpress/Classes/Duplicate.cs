namespace SorterExpress
{
    public class Duplicate
    {
        public string file1;
        public string file2;

        /// <summary>
        /// 0 to 1 likely hood of match.
        /// </summary>
        public float chance;

        public int differenceCount;

        public Duplicate(FilePrint fp1, FilePrint fp2)
        {
            this.file1 = fp1.file;
            this.file2 = fp2.file;

            differenceCount = 0;

            for (int i = 0; i < fp1.print.Length; i++)
            {
                if (fp1.print[i] != fp2.print[i])
                {
                    differenceCount++;
                }
            }

            chance = 1 - ((float)differenceCount / (float)64);
        }

        public override string ToString()
        {
            return $"Chance: {chance * 100}%";
        }
    }
}
