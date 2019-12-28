using Microsoft.WindowsAPICodePack.Dialogs;
using SorterExpress.Forms;
using SorterExpress.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Vlc.DotNet.Forms;

namespace SorterExpress
{
    public enum FileType { Image, Video, Other };

    class Utilities
    {
        //public static MD5 md5 = null;
        public static readonly string[] videoFileExtensions = { ".webm", ".avi", ".mp4", ".flv" };
        public static readonly string[] imageFileExtensions = { ".jpg", ".jpeg", ".jpg_large", ".png", ".bmp", ".gif" };

        public static FileType GetFileType(string filepath)
        {
            if (Utilities.FileIsImage(filepath))
                return FileType.Image;
            else if (Utilities.FileIsVideo(filepath))
                return FileType.Video;
            else
                return FileType.Other;
        }

        public static bool FileIsImage(string filepath)
        {
            return imageFileExtensions.Contains(Path.GetExtension(filepath).ToLower());
        }

        public static bool FileIsVideo(string filepath)
        {
            return videoFileExtensions.Contains(Path.GetExtension(filepath).ToLower());
        }

        /// <summary>
        /// Returns null if directory open is cancelled.
        /// </summary>
        public static DirectoryInfo OpenDirectory()
        {
            using (var dialog = new CommonOpenFileDialog())
            {
                dialog.IsFolderPicker = true;

                if (dialog.ShowDialog() == CommonFileDialogResult.Ok && !string.IsNullOrWhiteSpace(dialog.FileName))
                {
                    return new DirectoryInfo(dialog.FileName);
                }
            }

            return null;
        }

        public static void PrintExtensionCounts(IEnumerable<string> files)
        {
            var fileTypeCounts = files.GroupBy(t => Path.GetExtension(t))
                .Select(group => new {
                    Extension = group.Key,
                    Count = group.Count()
                }).OrderBy(x => x.Extension);

            foreach (var t in fileTypeCounts)
                Console.WriteLine("{0} {1}", t.Extension, t.Count);

            Console.WriteLine("Total: " + files.Count());
        }

        public static void VlcLibDirectoryNeeded(object sender, VlcLibDirectoryNeededEventArgs e)
        {
            var vlcControl = (VlcControl)sender;

            if (String.IsNullOrWhiteSpace(Settings.Default.VlcLocation))
            {
                string programFilesDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\VideoLAN\\VLC";
                string x86programFilesDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFilesX86) + "\\VideoLAN\\VLC";

                if (File.Exists(programFilesDirectory + "\\libvlc.dll"))
                {
                    Logs.Log(true, "Found libvlc.dll in Program Files so loading from there.");
                    FoundPath(programFilesDirectory);
                }
                else if (File.Exists(x86programFilesDirectory + "\\libvlc.dll"))
                {
                    Logs.Log(true, "Found libvlc.dll in Program Files (x86) so loading from there.");
                    FoundPath(x86programFilesDirectory);
                }
                else
                {
                    Logs.Log(true, "Cannot find VLC install in ProgramFiles or Programfiles(x86).");

                    using (LocateVLCForm locateForm = new LocateVLCForm())
                    {
                        if (locateForm.ShowDialog() == DialogResult.OK)
                        {
                            FoundPath(Path.GetDirectoryName(locateForm.vlcPath));
                        }
                        else
                        {
                            vlcControl.Parent.Controls.Remove(vlcControl);
                            vlcControl.Dispose();
                        }
                    }
                }

            }
            else
            {
                if (File.Exists(Settings.Default.VlcLocation + "\\libvlc.dll"))
                {
                    FoundPath(Settings.Default.VlcLocation);
                    Logs.Log(true, $"Loaded VLC from directory set by the user in a previous session. ({e.VlcLibDirectory.FullName})");
                }
                else
                {
                    // Remove pref and try to load VLC again, this will result in either:
                    //  VLC being loaded from a default install location.
                    //  Asking the user to locate the install locations.
                    Settings.Default.VlcLocation = null;
                    Logs.Log(true, "Could not load VLC from directory given by user in a previous session, directory in prefs has been removed.");
                    VlcLibDirectoryNeeded(sender, e);
                }
            }

            void FoundPath(string vlcPath)
            {
                var di = new DirectoryInfo(vlcPath);
                e.VlcLibDirectory = di;
                vlcControl.VlcLibDirectory = di;
                Settings.Default.VlcLocation = vlcPath;
                return;
            }
        }

        public static string[] GetTags(string filename)
        {
            filename = Path.GetFileNameWithoutExtension(filename);

            int indexOfOpeningBracket = filename.IndexOf('(');

            if (indexOfOpeningBracket != -1)
                filename = filename.Substring(0, indexOfOpeningBracket);

            return filename.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string GetNote(string filename)
        {
            try
            {
                string note = filename.Substring(filename.IndexOf('(') + 1, filename.IndexOf(')') - filename.IndexOf('(') - 1);
                int index;
                if (int.TryParse(note, out index))
                    return "";
                else
                    return note;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static bool ContainsTag(string filename, string tag, StringComparison comparison = StringComparison.Ordinal)
        {
            var tags = GetTags(filename);

            for (int i = 0; i < tags.Length; i++)
                if (tags[i].Equals(tag, comparison))
                    return true;

            return false;
        }

        public static float FloatClamp(float value, float min, float max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }

        public static string Remove(string haystack, char[] removeThese)
        {
            string ret = haystack;
            for (int i = 0; i < removeThese.Length; i++)
                ret = ret.Replace(removeThese[i].ToString(), "");
            return ret;
        }

        public static string MD5(string input)
        {
            // Step 1, calculate MD5 hash from input
            //if (md5 == null)
            MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }

            return sb.ToString();
        }

        public static int IndexOfNth(string str, string value, int nth = 1)
        {
            if (nth <= 0)
                throw new ArgumentException("Can not find the zeroth index of substring in string. Must start with 1");

            int offset = str.IndexOf(value);
            for (int i = 1; i < nth; i++)
            {
                if (offset == -1)
                    return -1;
                offset = str.IndexOf(value, offset + 1);
            }
            return offset;
        }

        public static Bitmap Resize(Bitmap image, int width, int height)
        {
            var ret = new Bitmap(image, width, height);
            image.Dispose();
            return ret;
        }

        public static Bitmap MakeGrayscale(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][]
               {
                    new float[] {.3f, .3f, .3f, 0, 0},
                    new float[] {.59f, .59f, .59f, 0, 0},
                    new float[] {.11f, .11f, .11f, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
               });

            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();
            original.Dispose();
            return newBitmap;
        }

        public static List<string> RecursivelyGetFileNames(string dir)
        {
            List<string> ret = new List<string>();

            var files = Directory.GetFiles(dir);

            Console.WriteLine("Recursively searching for files in " + dir + ". Found " + files.Length + " files.");

            ret.AddRange(files);

            foreach (string folder in Directory.GetDirectories(dir))
            {
                ret.AddRange(RecursivelyGetFileNames(folder));
            }

            return ret;
        }

        /// <summary>
        /// Just like File.Move(string, string) except this will check if they file already exists and add a (i) 
        /// to the end of the filename to accomodate. Always use this to move files.
        /// Returns the final file path used to move the file.
        /// </summary>
        public static string MoveFile(string sourcePath, string destinationPath)
        {
            // We have to find a free name, we dont want to overwrite any files (or we can't because of exceptions...)
            // So if file exists with the name we add (1), if that exists then add (2), and so on, until we find a free filename.
            // If i > 0 then "(i), else "".
            int i = 0;
            string numberText = (i > 0) ? $" ({i})" : "";
            string directory = Path.GetDirectoryName(destinationPath);
            string filenameNoExtension = Path.GetFileNameWithoutExtension(destinationPath);
            string extension = Path.GetExtension(destinationPath).ToLower();
            string calculatedDestination = $"{directory}\\{filenameNoExtension}{numberText}{extension}";

            while (File.Exists(calculatedDestination))
            {
                i++;
                numberText = (i > 0) ? $" ({i})" : "";
                calculatedDestination = $"{directory}\\{filenameNoExtension}{numberText}{extension}";
            }

            File.Move(sourcePath, calculatedDestination);
            return calculatedDestination;
        }

        public static string MessageBoxGetString(string prepopulatedText = "")
        {
            GetStringMessageBox dialog = new GetStringMessageBox(prepopulatedText);
            dialog.TopMost = true;

            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Read the contents of testDialog's TextBox.
                return dialog.UserEntry.Replace("\n", "").Replace("\r", "");
            }
            else
            {
                return null;
            }
        }

        public static string RemoveCharactersFromString(string haystack, params char[] removeThese)
        {
            string ret = haystack;
            for (int i = 0; i < removeThese.Length; i++)
                ret = ret.Replace(removeThese[i].ToString(), "");
            return ret;
        }
    }

    static class Extensions
    {
        public static List<T> Clone<T>(this List<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }

        public static string[] GetFolderNames(this DirectoryInfo dirInfo)
        {
            return dirInfo.GetDirectories().Select(t => t.Name).ToArray();
        }

        public static string[] GetFileNamesArray(this DirectoryInfo dirInfo)
        {
            return dirInfo.GetFiles().Select(t => t.Name).ToArray();
        }
        public static List<string> GetFileNamesList(this DirectoryInfo dirInfo)
        {
            return dirInfo.GetFiles().Select(t => t.Name).ToList();
        }

        public static void Invoke(this Control control, Action action)
        {
            control.Invoke((Delegate)action);
        }
    }
}
