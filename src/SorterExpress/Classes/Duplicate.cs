using System;
using System.Drawing;

namespace SorterExpress
{
    public class Duplicate
    {
        public FilePrint fileprint1, fileprint2;

        public string File1Path { get { return fileprint1.filepath; } }
        public string File1ThumbPath { get { return fileprint1.ThumbPath; } }

        private Image file1Thumb = null;
        public Image File1Thumb { 
            get 
            {
                if (file1Thumb == null)
                    file1Thumb = new Bitmap(new Bitmap(File1ThumbPath), 60, 60);

                return file1Thumb;
            } 
        }

        public string File2Path { get { return fileprint2.filepath; } }
        public string File2ThumbPath { get { return fileprint2.ThumbPath; } }

        private Image file2Thumb;
        public Image File2Thumb
        {
            get
            {
                if (file2Thumb == null)
                    file2Thumb = new Bitmap(new Bitmap(File2ThumbPath), 60, 60);

                return file2Thumb;
            }
        }

        /// <summary>
        /// 0 to 1 likelihood of match (1 = 100% chance (estimate))
        /// </summary>
        public float Chance { get; private set; }

        public string ChancePercentageText { get { return $"{Math.Round(Chance * 100)}%"; } }

        public int DifferenceCount { get; private set; }

        public Duplicate(FilePrint fp1, FilePrint fp2)
        {
            fileprint1 = fp1;
            //this.File1Path = fp1.filepath;
            //this.File1ThumbPath = fp1.ThumbPath;

            fileprint2 = fp2;
            //this.File2Path = fp2.filepath;
            //this.File2ThumbPath = fp2.ThumbPath;

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
