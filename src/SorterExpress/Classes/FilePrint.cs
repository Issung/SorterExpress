﻿using SorterExpress;
using System.Drawing;
using System.IO;

public class FilePrint
{
    public static FFMPEG ffmpeg = null;
    public static FFProbe ffprobe = null;
    public string file;
    public Size size;
    public float average;
    public string print;

    public FilePrint(string filePath)
    {
        this.file = filePath;
        Bitmap img;

        if (Utilities.FileIsImage(filePath))
        {
            img = new Bitmap(filePath);
            this.size = img.Size;
            CalculatePicturePrint(img);
            img.Dispose();
        }
        else if (Utilities.FileIsVideo(filePath))
        {
            if (ffmpeg == null)
                ffmpeg = new FFMPEG();

            if (ffprobe == null)
                ffprobe = new FFProbe();

            string output = Program.VIDEO_THUMBS_PATH + "\\" + Utilities.MD5(Path.GetFileName(filePath)) + ".jpg";
            if (!File.Exists(output))
                ffmpeg.GetThumbnailWait(filePath, output, 60);

            this.size = new Size(0, 0);

            // Should put a try catch around this, if file is corrupted or anything it leads to issues.
            img = new Bitmap(output);

            CalculatePicturePrint(img);

            img.Dispose();
        }
    }

    public void CalculatePicturePrint(Bitmap img)
    {
        img = Utilities.Resize(img, 8, 8);
        img = Utilities.MakeGrayscale(img);

        float sum = 0;
        Color col;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                col = img.GetPixel(i, j);
                sum += (float)(col.R + col.G + col.B) / 3f;
            }
        }

        average = sum / (float)(8 * 8);

        print = "";

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                col = img.GetPixel(i, j);
                if (((float)(col.R + col.G + col.B) / 3f) >= average)
                    print += "1";
                else
                    print += "0";
            }
        }
    }

    /// <summary>
    /// Returns the difference count between two fileprints.
    /// </summary>
    public static int Compare(FilePrint fp1, FilePrint fp2)
    {
        int differenceCount = 0;

        for (int i = 0; i < fp1.print.Length; i++)
        {
            if (fp1.print[i] != fp2.print[i])
            {
                differenceCount++;
            }
        }

        return differenceCount;
    }

    /// <summary>
    /// Returns a decimal ranging from 0 to 100.
    /// </summary>
    public static decimal GetSimilarityPercentage(FilePrint fp1, FilePrint fp2)
    {
        int differenceCount = 0;

        for (int i = 0; i < fp1.print.Length; i++)
        {
            if (fp1.print[i] != fp2.print[i])
            {
                differenceCount++;
            }
        }

        return (1 - ((decimal)differenceCount / (decimal)64)) * 100;
    }
}