﻿using SorterExpress;
using SorterExpress.Classes;
using SorterExpress.Properties;
using System;
using System.Drawing;
using System.IO;

public class FilePrint
{
    const int THUMB_SIZE = 60;

    public string directory;
    public string filepath;
    public FileType fileType;
    public Size size = new Size(-1, -1);
    public float average;
    public string print;

    //string thumbPath = null;

    /// <summary>
    /// The path to the fileprint's thumbnail, if the fileprint is for an image
    /// then the path is just to the raw image (full sized). if the fileprint is
    /// for a video then the path is the the small jpg extracted by ffmpeg.
    /// </summary>
    /*public string ThumbPath { get {
            //if (Utilities.FileIsImage(file))
            //    return file;
            //else
            //    return thumbPath;
            return thumbPath;
        }

        set;
    }*/

    public string ThumbPath { get; set; }

    public FilePrint(string filePath)
    {
        this.filepath = filePath;
        directory = Path.GetDirectoryName(filePath);
        Bitmap img;
        fileType = Utilities.GetFileType(filepath);

        ThumbPath = Path.Combine(Program.THUMBS_PATH, Utilities.MD5(filePath) + ".jpg");

        if (Utilities.FileIsImage(filePath))
        {
            /*img = new Bitmap(filePath);
            this.size = img.Size;
            CalculatePicturePrint(img);

            ThumbPath = Path.Combine(Program.THUMBS_PATH, Utilities.MD5(filePath) + ".jpg");
            if (!File.Exists(ThumbPath))
                Utilities.Resize(new Bitmap(filePath), THUMB_SIZE, THUMB_SIZE).Save(ThumbPath);

            img.Dispose();*/

            if (File.Exists(ThumbPath))
            {
                img = new Bitmap(filePath);
                size = img.Size;
                img.Dispose();
                img = new Bitmap(ThumbPath);
                CalculatePicturePrint(img);
            }
            else
            {
                img = new Bitmap(filePath);
                size = img.Size;
                Utilities.Resize(img, THUMB_SIZE, THUMB_SIZE).Save(ThumbPath);
                img.Dispose();

                img = new Bitmap(ThumbPath);
                CalculatePicturePrint(img);
            }

            img.Dispose();
        }
        else if (Utilities.FileIsVideo(filePath))
        {
            //FFWorker.GetSizeAsync(filePath, (Size s) => { this.size = s; });

            if (!File.Exists(ThumbPath))
            {
                FFWorker.GetThumbnailWait(filePath, ThumbPath, THUMB_SIZE);
            }

            // Should put a try catch around this, if file is corrupted or anything it leads to issues.
            img = new Bitmap(ThumbPath);

            CalculatePicturePrint(img);

            img.Dispose();
        }
    }

    static readonly float minColor = Color.FromArgb(18, 18, 18).GetBrightness();

    public void CalculatePicturePrint(Bitmap img)
    {
        int leftBorder = 0,
            rightBorder = 0,
            topBorder = 0,
            bottomBorder = 0;

        if (Settings.Default.DuplicatesCropLeftRightSides)
        {
            //Get Left Border
            for (int i = 0; i < img.Size.Width; i++)
            {
                if (img.GetPixel(i, img.Size.Height / 2).GetBrightness() > minColor)
                {
                    leftBorder = i;
                    break;
                }
            }

            //Get Right Border
            for (int i = img.Size.Width - 1; i >= 0; i--)
            {
                if (img.GetPixel(i, img.Size.Height / 2).GetBrightness() > minColor)
                {
                    rightBorder = i;
                    break;
                }
            }

            //Console.WriteLine($"leftBorder: {leftBorder}, rightBorder: {rightBorder}");
        }

        if (Settings.Default.DuplicatesCropTopBottomSides)
        {
            //Get Top Border
            for (int i = 0; i < img.Size.Height; i++)
            {
                if (img.GetPixel(img.Size.Width / 2, i).GetBrightness() > minColor)
                {
                    topBorder = i;
                    break;
                }
            }

            //Get Bottom Border
            for (int i = img.Size.Height - 1; i >= 0; i--)
            {
                if (img.GetPixel(img.Size.Width / 2, i).GetBrightness() > minColor)
                {
                    bottomBorder = i;
                    break;
                }
            }

            //Console.WriteLine($"topBorder: {topBorder}, bottomBorder: {bottomBorder}");
        }

        if (Settings.Default.DuplicatesCropLeftRightSides || Settings.Default.DuplicatesCropTopBottomSides)
        {
            int width = (leftBorder == rightBorder) ? THUMB_SIZE : (rightBorder - leftBorder);
            int height = (topBorder == bottomBorder) ? THUMB_SIZE : (bottomBorder - topBorder);
            img = img.Clone(new Rectangle(leftBorder, topBorder, width, height), img.PixelFormat);
        }

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

        try
        {
            for (int i = 0; i < fp1.print.Length; i++)
            {
                if (fp1.print[i] != fp2.print[i])
                {
                    differenceCount++;
                }
            }

            return (1 - ((decimal)differenceCount / (decimal)64)) * 100;
        }
        catch (Exception e)
        {
            return 0;
        }
    }
}