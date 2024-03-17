using SorterExpress;
using SorterExpress.Classes;
using SorterExpress.Classes.SettingsData;
using SorterExpress.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

public class FilePrint
{
    public const int THUMB_SIZE = 60;

    /// <summary>
    /// File sizes are lazy-loaded, this property will tell you if Size has been loaded yet for this file without actually loading Size.
    /// </summary>
    public bool SizeLoaded => size != null;

    /// <summary>
    /// Obtain full-dimensions of this file.<br/>
    /// This performs hard drive read operations if not yet loaded.
    /// </summary>
    public Size Size 
    {
        get 
        {
            if (size == null)
            {
                size = GetSize();
                return size.Value;
            }
            else
            {
                return size.Value;
            }
        }
    }

    public string Directory;
    public string Filepath;
    public FileType FileType;
    public float Average;
    public string Print;
    public string ThumbPath;

    /// <summary>
    /// Lazily-loaded full dimensions of the file.<br/>
    /// If this print was created from an *Image* that was not already cached then size will be set.<br/>
    /// If a video is loaded by a video player then this can be set efficiently with <see cref="SetVideoSize"/>.
    /// </summary>
    private Size? size = null;

    /// <summary>
    /// Create a "file print" for a multi-media file. First this detects the file type (image or video) and then creates a small thumbnail for it and caches it in 
    /// SorterExpress's thumbnail store.
    /// </summary>
    /// <exception cref="Exception">Can throw any manner of exceptions because of constantly manipulating files.</exception>
    public FilePrint(string filePath)
    {
        this.Filepath = filePath;
        Bitmap thumbImage;
        Directory = Path.GetDirectoryName(filePath);
        FileType = Utilities.GetFileType(Filepath);

        ThumbPath = Path.Combine(Program.THUMBS_PATH, Utilities.MD5(filePath) + ".jpg");

        if (File.Exists(ThumbPath))
        {
            thumbImage = new Bitmap(ThumbPath);
        }
        else
        {
            if (FileType == FileType.Image)
            {
                var fullImage = new Bitmap(filePath);
                size = fullImage.Size;
                thumbImage = Utilities.Resize(fullImage, THUMB_SIZE, THUMB_SIZE);
                thumbImage.Save(ThumbPath);

                fullImage.Dispose();
            }
            else if (FileType == FileType.Video)
            {
                FFWorker.GetThumbnailWait(filePath, ThumbPath, THUMB_SIZE);

                // Should put a try catch around this, if file is corrupted or anything it leads to issues.
                thumbImage = new Bitmap(ThumbPath);
            }
            else
            {
                throw new InvalidOperationException("Creating FilePrint, file must be an Image or Video.");
            }
        }

        if (thumbImage == null)
        {
            throw new Exception("ThumbImage should have been loaded by this point in order to calculate image print");
        }

        CalculateImagePrint(thumbImage);

        thumbImage.Dispose();
    }

    private Size GetSize()
    {
        if (FileType == FileType.Image)
        {
            using (var imageStream = File.OpenRead(Filepath))
            {
                var decoder = BitmapDecoder.Create(imageStream, BitmapCreateOptions.IgnoreColorProfile, BitmapCacheOption.Default);
                var width = decoder.Frames[0].PixelWidth;
                var height = decoder.Frames[0].PixelHeight;
                return new Size(width, height);
            }
        }
        else if (FileType == FileType.Video)
        {
            return FFWorker.GetSizeWait(Filepath);
        }

        return new Size(-1, -1);
    }
    
    // TODO: Make sure this is being used properly (make sure `Size` is not being accessed before this is, making this optimisation useless).
    public void SetVideoSize(Size newSize)
    {
        if (FileType != FileType.Video)
        {
            throw new InvalidOperationException("This method should only be used when the video type is Video. It should be used by when the file size can be easily obtained from the video player.");
        }

        size = newSize;
    }

    static readonly float minColor = Color.FromArgb(18, 18, 18).GetBrightness();

    public void CalculateImagePrint(Bitmap img)
    {
        int leftBorder = 0,
            rightBorder = 0,
            topBorder = 0,
            bottomBorder = 0;

        if (Settings.Default.DuplicateSearch.CropLeftRightSides)
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

        if (Settings.Default.DuplicateSearch.CropTopBottomSides)
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

        if (Settings.Default.DuplicateSearch.CropLeftRightSides || Settings.Default.DuplicateSearch.CropTopBottomSides)
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

        Average = sum / (float)(8 * 8);

        Print = "";

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                col = img.GetPixel(i, j);
                if (((float)(col.R + col.G + col.B) / 3f) >= Average)
                    Print += "1";
                else
                    Print += "0";
            }
        }
    }

    /// <summary>
    /// Returns the difference count between two fileprints.
    /// </summary>
    public static int Compare(FilePrint fp1, FilePrint fp2)
    {
        int differenceCount = 0;

        for (int i = 0; i < fp1.Print.Length; i++)
        {
            if (fp1.Print[i] != fp2.Print[i])
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
            for (int i = 0; i < fp1.Print.Length; i++)
            {
                if (fp1.Print[i] != fp2.Print[i])
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