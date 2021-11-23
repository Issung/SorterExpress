using Microsoft.WindowsAPICodePack.Dialogs;
using SorterExpress.Classes.SettingsData;
using SorterExpress.Forms;
using SorterExpress.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace SorterExpress
{
    public enum FileType { Image, Video, Other };

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

            ret += !String.IsNullOrWhiteSpace(Note) ? $" ({Note})" : "";

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

    class Utilities
    {
        public const string TAGS_FILE_EXTENSION = "tgs";

        private static MD5 md5 = null;
        public static readonly string[] videoFileExtensions = { ".webm", ".avi", ".mp4", ".flv" };
        public static readonly string[] imageFileExtensions = { ".jpg", ".jpeg", ".jpg_large", ".png", ".bmp", ".gif" };

        public static readonly char[] NoteForbiddenCharacters = { '/', '\\', '?', '%', '*', ':', '|', '"', '<', '>', '.' };
        public static readonly char[] TagForbiddenCharacters = { '/', '\\', '?', '%', '*', ':', '|', '"', '<', '>', '.', ' ', '(', ')' };

        public static FileDetails GetFileDetails(string filepath)
        {
            FileDetails details = new FileDetails();

            details.FileExtension = Path.GetExtension(filepath);
            details.FileType = Utilities.GetFileType(filepath);

            string strippedPath = Path.GetFileNameWithoutExtension(filepath);

            int indexOfFirstOpeningBracket = strippedPath.IndexOf('(');
            int indexOfLastClosingBracket = strippedPath.IndexOf(')');
            if (indexOfFirstOpeningBracket != -1 && indexOfLastClosingBracket != -1 && indexOfLastClosingBracket > indexOfFirstOpeningBracket)
            {
                details.Note = strippedPath.Substring(indexOfFirstOpeningBracket + 1, indexOfLastClosingBracket - indexOfFirstOpeningBracket - 1);
            }

            //If there was a note, strip it out of the file name for more processing (finding tags).
            if (!String.IsNullOrWhiteSpace(details.Note))
                strippedPath = strippedPath.Substring(0, indexOfFirstOpeningBracket);

            details.Tags = strippedPath.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            return details;
        }

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
        /// Open native directory selector to select a single file.
        /// </summary>
        /// <returns>The selected file, null if open was cancelled.</returns>
        // TODO: Nullable return.
        public static FileInfo OpenFile()
        {
            using (var dialog = new CommonOpenFileDialog())
            {
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok && !string.IsNullOrWhiteSpace(dialog.FileName))
                {
                    return new FileInfo(dialog.FileName);
                }
            }

            return null;
        }

        /// <summary>
        /// Open native directory selector to select one or more files.
        /// </summary>
        /// <returns>Array of selected files, null if open was cancelled.</returns>
        // TODO: Nullable return.
        public static FileInfo[] OpenFiles()
        {
            using (var dialog = new CommonOpenFileDialog())
            {
                dialog.Multiselect = true;

                if (dialog.ShowDialog() == CommonFileDialogResult.Ok && dialog.FileNames?.Count() is not null or 0)
                {
                    return dialog.FileNames.Select(t => new FileInfo(t)).ToArray();
                }
            }

            return null;
        }

        /// <summary>
        /// Open native directory selector to select a single directory.
        /// </summary>
        /// <returns>The selected directory, null if open was cancelled.</returns>
        // TODO: Nullable return.
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

        /// <summary>
        /// Open a file in the operating system's preferred program.
        /// </summary>
        /// <param name="path">Directory path to the file.</param>
        public static void ViewFile(string path)
        {
            if (!string.IsNullOrWhiteSpace(path))
            { 
                Process.Start(path);
            }
        }

        /// <summary>
        /// Open windows explorer and pre-select a given file.
        /// </summary>
        /// <param name="path">Directory path to the file.</param>
        public static void ViewFileInExplorer(string path)
        {
            if (!string.IsNullOrWhiteSpace(path))
            { 
                Process.Start("explorer.exe", $"/select,\"{path}\"");
            }
        }

        /// <summary>
        /// Open native directory selector to select one or more directories.
        /// </summary>
        /// <returns>Array of selected directories, null if open was cancelled.</returns>
        // TODO: Nullable return.
        public static DirectoryInfo[] OpenDirectories()
        {
            using (var dialog = new CommonOpenFileDialog())
            {
                dialog.IsFolderPicker = true;
                dialog.Multiselect = true;

                if (dialog.ShowDialog() == CommonFileDialogResult.Ok && dialog.FileNames?.Count() is not null or 0)
                {
                    return dialog.FileNames.Select(t => new DirectoryInfo(t)).ToArray();
                }
            }

            return null;
        }

        public static string GenerateFilename(string currentFilename, IEnumerable<string> tags, string note, bool addExtension)
        {
            if ((tags == null && note == null) || (tags.Count() == 0 && String.IsNullOrWhiteSpace(note)))
            {
                return addExtension ? currentFilename : Path.GetFileNameWithoutExtension(currentFilename);
            }
            else
            {
                string newName = "";

                if (tags.Count() > 0)
                {
                    newName += String.Join(" ", tags);
                }

                if (!String.IsNullOrWhiteSpace(note))
                    if (tags.Count() == 0)
                        newName += note;
                    else
                        newName += " (" + note + ")";

                return addExtension ? newName + Path.GetExtension(currentFilename) : newName;
            }
        }

        public static void PrintExtensionCounts(IEnumerable<string> files)
        {
            var fileTypeCounts = files.GroupBy(t => Path.GetExtension(t))
                .Select(group => new {
                    Extension = group.Key,
                    Count = group.Count()
                }).OrderBy(x => x.Extension);

            foreach (var t in fileTypeCounts)
                Console.WriteLine($"{t.Extension} {t.Count}");

            Console.WriteLine($"Total: {files.Count()}");
        }

        public static DirectoryInfo FindVlcLibDirectory()
        {
            if (String.IsNullOrWhiteSpace(Settings.Default.Video.VlcLocation))
            {
                string programFilesDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "VideoLAN", "VLC");
                string x86programFilesDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "VideoLAN", "VLC");

                Logs.Log($"programFilesDirectory: {programFilesDirectory}", $"x86programFilesDirectory: {x86programFilesDirectory}");

                if (Directory.Exists(programFilesDirectory))
                {
                    Logs.Log($"Directory {programFilesDirectory} exists, loading VLC from there.");
                    return Ret(programFilesDirectory);
                }
                else if (Directory.Exists(x86programFilesDirectory))
                {
                    Logs.Log($"Directory {x86programFilesDirectory} exists, loading VLC from there.");
                    return Ret(x86programFilesDirectory);
                }
                else
                {
                    Logs.Log($"Cannot find VLC install in ProgramFiles or ProgramFiles(x86).");

                    using (LocateVLCForm locateForm = new LocateVLCForm())
                    {
                        if (locateForm.ShowDialog() == DialogResult.OK)
                        {
                            return Ret(Path.GetDirectoryName(locateForm.vlcPath));
                        }
                        else //DialogResult.Ignore
                        {
                            return Ret(null);
                        }
                    }
                }

            }
            else
            {
                if (Directory.Exists(Settings.Default.Video.VlcLocation))
                {
                    Logs.Log($"Loaded VLC from directory set by the user in a previous session. ({Settings.Default.Video.VlcLocation})");
                    return Ret(Settings.Default.Video.VlcLocation);
                }
                else
                {
                    // Remove pref and try to load VLC again, this will result in either:
                    //  VLC being loaded from a default install location.
                    //  Asking the user to locate the install locations.
                    Settings.Default.Video.VlcLocation = null;
                    Logs.Log("Could not load VLC from directory given by user in a previous session, directory in prefs has been removed. Trying again.");
                    return FindVlcLibDirectory();
                }
            }

            DirectoryInfo Ret(string vlcPath)
            {
                DirectoryInfo di;

                if (vlcPath != null)
                    di = new DirectoryInfo(vlcPath);
                else
                    di = null;

                Settings.Default.Video.VlcLocation = vlcPath;
                Settings.Save();
                return di;
            }
        }

        /*public static void VlcLibDirectoryNeeded(object sender, VlcLibDirectoryNeededEventArgs e)
        {
            var vlcControl = (VlcControl)sender;

            //FoundPath("libvlc/" + (Environment.Is64BitOperatingSystem ? "win-x64" : "win-x86"));
            //FoundPath("libvlc/win-x86");

            if (String.IsNullOrWhiteSpace(Settings.Default.VlcLocation))
            {
                string programFilesDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\VideoLAN\\VLC";
                string x86programFilesDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\VideoLAN\\VLC";

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
                            //vlcControl.Parent.Controls.Remove(vlcControl);
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
        }*/

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

        static object md5Lock = new object();

        /// <summary>
        /// https://stackoverflow.com/questions/11454004/calculate-a-md5-hash-from-a-string
        /// </summary>
        public static string MD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        //Failed idea to MD5 off of file data rather than filename. Could be fixed eventually but might be slow.
        /*public static string MD5FileData(string filePath)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                const int BYTES = 10;
                byte[] inputBytes = new byte[BYTES];
                new FileStream(filePath, FileMode.Open).S.Read(inputBytes, 0, BYTES);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }*/

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
            return ret;
        }

        readonly static ColorMatrix grayScaleColorMatrix = new ColorMatrix(
               new float[][]
               {
                    new float[] {.3f, .3f, .3f, 0, 0},
                    new float[] {.59f, .59f, .59f, 0, 0},
                    new float[] {.11f, .11f, .11f, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
               });

        public static Bitmap MakeGrayscale(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(grayScaleColorMatrix);

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

        public static string[] RecursiveDirectorySearch(string dir, int maxDepth)
        {
            return RecursiveDirectorySearchHelper(dir, 0, maxDepth);
        }

        private static string[] RecursiveDirectorySearchHelper(string dir, int currentDepth, int maxDepth)
        {
            if (currentDepth <= maxDepth)
            {
                List<string> dirs = new();

                foreach (string subdir in Directory.GetDirectories(dir))
                {
                    dirs.Add(subdir);
                    dirs.AddRange(RecursiveDirectorySearchHelper(subdir, currentDepth + 1, maxDepth));
                }

                return dirs.ToArray();
            }

            return Array.Empty<string>();
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

        /// <summary>
        /// Get the amount of folders in a path 
        /// "C:\\test\\ayylmao//foldername//59172569127.jpg" returns 4.
        /// </summary>
        public static int GetFolderCountInPath(string path)
        {
            return path.Split(new char[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries).Count() - 1;
        }

        /// <summary>
        /// Credit: https://www.dotnetperls.com/directory-size
        /// Returns the size of a directory in bytes.
        /// Divide by 1000000 to get megabyte size.
        /// </summary>
        public static long GetDirectorySizeBytes(string path)
        {
            // 1.
            // Get array of all file names.
            string[] files = Directory.GetFiles(path, "*.*");

            // 2.
            // Calculate total bytes of all files in a loop.
            long b = 0;
            foreach (string name in files)
            {
                // 3.
                // Use FileInfo to get length of each file.
                FileInfo info = new FileInfo(name);
                b += info.Length;
            }
            // 4.
            // Return total size
            return b;
        }

        public static void DeleteAllInDirectory(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        /// <summary>
        /// Adds a string into a list of strings in its correct alphabetical placement.
        /// </summary>
        public static void AddItemToListAlphabetically(IList<string> list, string newItem)
        {
            if (list.Count == 0)
            {
                list.Add(newItem);
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (String.Compare(newItem, list[i]) < 0)
                    {
                        list.Insert(i, newItem);
                        break;
                    }
                    else if (i == (list.Count - 1))
                    {
                        list.Add(newItem);
                        break;
                    }
                }
            }
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
