using NsfwSpyNS;
using SorterExpress.Classes;
using SorterExpress.Classes.SettingsData;
using SorterExpress.Forms;
using SorterExpress.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shortcut = SorterExpress.Classes.Shortcut;

#nullable enable

namespace SorterExpress.Controllers
{
    public class NsfwSortController
    {
        public NsfwSortForm form;
        public NsfwSortModel model;
        public int ResultsGridViewSelectedRowIndex { get { return form.resultsDataGridView?.CurrentCell?.RowIndex ?? -1; } }
        public NsfwSortFileResult? InspectingResult { get; private set; }
        public int FinishedFiles = 0;

        private readonly Dictionary<Shortcut, Func<bool>> shortcuts;

        private readonly BackgroundWorker classifyWorker;
        private CancellationTokenSource cancelTokenSource = new();
        private Stopwatch stopwatch = new();
        private int scopeCount;
        /// <summary>Needed to temporarily ignore check events while we alter their states.</summary>
        private bool ignoreOverrideCheckEvents = false;

        public NsfwSortController(NsfwSortForm form, DirectoryInfo dirInfo)
        {
            this.form = form;
            model = new NsfwSortModel();

            classifyWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            classifyWorker.DoWork += ClassifyWorker_DoWork;
            classifyWorker.ProgressChanged += ClassifyWorker_ProgressChanged;
            classifyWorker.RunWorkerCompleted += ClassifyWorker_Completed;

            shortcuts = new Dictionary<Shortcut, Func<bool>>() {
                { new Shortcut(key: Keys.N), () => { form.overrideNeutralButton.Checked = true; return true; }},
                { new Shortcut(key: Keys.S), () => { form.overrideSexyButton.Checked = true; return true; }},
                { new Shortcut(key: Keys.H), () => { form.overrideHentaiButton.Checked = true; return true; }},
                { new Shortcut(key: Keys.P), () => { form.overridePornographyButton.Checked = true; return true; }},
                { new Shortcut(key: Keys.Up), () => { return ChangeSelectedIndex(-1); }},
                { new Shortcut(key: Keys.Down), () => { return ChangeSelectedIndex(+1); }},
                //{ new Shortcut(ctrl: true, key: Keys.Z), Undo },
                //{ new Shortcut(ctrl: true, key: Keys.Y), Redo },
            };

            if (dirInfo != null)
            {
                LoadDirectory(dirInfo);
            }
        }

        public void HandleShortcut(KeyEventArgs e)
        {
            var input = new Shortcut(e.Control, e.Alt, e.KeyCode);

            if (shortcuts.TryGetValue(input, out var shortcutAction))
            {
                var shortcutWorked = shortcutAction.Invoke();

                if (shortcutWorked)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
                else
                {
                    SystemSounds.Beep.Play();
                }
            }
        }

        private bool ChangeSelectedIndex(int changeAmount)
        {
            int newIndex = form.resultsDataGridView.CurrentCell.RowIndex + changeAmount;

            if (newIndex >= 0 && newIndex < form.resultsDataGridView.RowCount)
            {
                form.resultsDataGridView.CurrentCell = form.resultsDataGridView.Rows[newIndex].Cells[0];
                SelectionChanged();
                return true;
            }
            else
            {
                return false;
            }
        }

        internal void OpenDirectoryDialog()
        {
            var dirInfo = Utilities.OpenDirectory();

            if (dirInfo != null)
            {
                LoadDirectory(dirInfo);
            }
        }

        private void LoadDirectory(DirectoryInfo dirInfo)
        {
            model.Directory = dirInfo.FullName;

            model.Files?.Clear();
            model.ResultsClear();

            UpdateSearchFilesScope();

            Logs.Log($"Opened '{model.Directory}' and found { model.Files.Count} files.");

            Utilities.PrintExtensionCounts(model.Files);

            //UpdateFileCountLabel();
            Console.WriteLine("Image file count: " + model.Files.Where(Utilities.FileIsImage).Count());
            Console.WriteLine("Video file count: " + model.Files.Where(Utilities.FileIsVideo).Count());
        }

        public void UpdateSearchFilesScope()
        {
            Console.WriteLine($"UpdateSearchFilesScope! SearchScopeSelectedValue: {model.SearchScope}");

            if (string.IsNullOrWhiteSpace(model.Directory))
            {
                return;
            }

            if (model.SearchScope == SearchScope.ImmediateOnly)
            {
                model.Files = new DirectoryInfo(model.Directory).GetFileNamesList();
            }
            else if (model.SearchScope == SearchScope.SubdirsOnly)
            {
                model.Files = Utilities.RecursivelyGetFileNames(model.Directory);
                var immediates = Directory.GetFiles(model.Directory);//new DirectoryInfo(model.Directory).GetFileNamesList();
                model.Files.RemoveAll(t => immediates.Contains(t));
            }
            else //`BetweenImmediateAndSubs` & `All`
            {
                model.Files = Utilities.RecursivelyGetFileNames(model.Directory);
            }

            model.Files.RemoveAll(t => !TypeOK(t));

            model.NotifyPropertyChanged(nameof(model.FileAndMatchesCountText));

            bool TypeOK(string t)
            {
                FileType type = Utilities.GetFileType(t);

                return (type == FileType.Image && model.SearchImages) || (type == FileType.Video && model.SearchVideos);
            }
        }

        public void BeginSearch()
        {
            stopwatch = Stopwatch.StartNew();

            model.ResultsClear();
            model.Searching = true;

            classifyWorker.RunWorkerAsync();
        }

        public void CancelSearch()
        {
            Console.WriteLine("Cancelling duplicate search worker!");
            cancelTokenSource.Cancel();
        }

        private List<string> GetSearchScope(List<string> files)
        {
            var scope = files
                .Where(f => !ShouldBeExcluded(f))
                .Where(f => (model.SearchImages && Utilities.FileIsImage(f)) || (model.SearchVideos && Utilities.FileIsVideo(f)))
                .ToList();

            return scope;

            bool ShouldBeExcluded(string str)
            {
                foreach (var dir in Settings.Default.DuplicateSearch.IgnoreDirectories ?? Enumerable.Empty<string>())
                {
                    if (str.StartsWith(dir))
                    {
                        return true;
                    }
                }

                foreach (var dir in Settings.Default.DuplicateSearch.IgnoreFiles ?? Enumerable.Empty<string>())
                {
                    if (str == dir)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        private void ClassifyWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            Console.WriteLine("Starting to classify files...");

            var scope = GetSearchScope(model.Files);
            scopeCount = scope.Count;

            form.Invoke(model.ResultsClear);

            ClassifyFiles(scope);

            Console.WriteLine("All files classified.");
        }

        private void ClassifyWorker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            //TODO: Change these to variables in Model and use data binding.
            form.loadingLabel.Text = $"Searching..\n{FinishedFiles}/{scopeCount}";
            form.progressBar.Value = e.ProgressPercentage;
        }

        private void ClassifyWorker_Completed(object? sender, RunWorkerCompletedEventArgs e)
        {
            Debug.WriteLine("ClassifyWorker_Completed!");

            model.Searching = false;

            stopwatch.Stop();
            Debug.WriteLine($"Processed {FinishedFiles} files in {stopwatch.Elapsed}.");
        }

        private void ClassifyFiles(List<string> files)
        {
            if (!Directory.Exists(Program.THUMBS_PATH))
            {
                Directory.CreateDirectory(Program.THUMBS_PATH);
            }

            FinishedFiles = 0;

            cancelTokenSource = new CancellationTokenSource();

            var options = new ParallelOptions
            {
                MaxDegreeOfParallelism = (int)model.ThreadCount,
                CancellationToken = cancelTokenSource.Token
            };

            var spy = new NsfwSpy();
            var videoOptions = new VideoOptions()
            {
                ClassifyEveryNthFrame = 1000,   // Kind of annoying, would be good to know framecount per video and adjust accordingly, but that takes time too.
                EarlyStopOnNsfw = true
            };

            try
            {
                Parallel.ForEach(
                    files,
                    options,
                    (filename, state) =>
                    {
                        if (options.CancellationToken.IsCancellationRequested)
                        {
                            state.Break();
                        }
                        else
                        {
                            var extension = Path.GetExtension(filename);
                            var path = Path.Combine(model.Directory, filename);

                            try
                            {
                                var classification =
                                    extension == ".gif" ? spy.ClassifyGif(path, videoOptions).Frames.First().Value :
                                    Utilities.videoFileExtensions.Contains(extension) ? spy.ClassifyVideo(path, videoOptions).Frames.First().Value :
                                    spy.ClassifyImage(path);

                                var thumbPath = Path.Combine(Program.THUMBS_PATH, Utilities.MD5(path) + ".jpg");

                                // Create thumb.
                                if (!File.Exists(thumbPath))
                                {
                                    if (Utilities.videoFileExtensions.Contains(extension))
                                    {
                                        FFWorker.GetThumbnailWait(path, thumbPath, FilePrint.THUMB_SIZE);
                                    }
                                    else
                                    {
                                        var fullImage = new Bitmap(path);
                                        var thumbImg = Utilities.Resize(fullImage, FilePrint.THUMB_SIZE, FilePrint.THUMB_SIZE);
                                        thumbImg.Save(thumbPath);
                                        fullImage.Dispose();
                                    }
                                }

                                var thumb = new Bitmap(thumbPath);

                                form.Invoke(() =>
                                {
                                    var result = new NsfwSortFileResult()
                                    {
                                        Path = path,
                                        Thumb = thumb,
                                        ClassificationWeights = classification,
                                    };
                                    model.ResultsAdd(result);
                                });

                                FinishedFiles++;
                                classifyWorker.ReportProgress(FinishedFiles * 100 / files.Count);
                            }
                            catch
                            {
                                // Unable to classify path.
                            }
                        }
                    });
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception in GeneratingPrints: {e.Message} - {e.StackTrace}");
            }
        }

        internal void SelectionChanged()
        {
            int index = ResultsGridViewSelectedRowIndex;

            if (index >= 0)
            {
                InspectingResult = model.FilteredResults[index];
                LoadResult(InspectingResult);
            }
            else
            {
                InspectingResult = null;
                LoadResult(null);
            }
        }

        /// <param name="result">File path to load, set to null to unload.</param>
        internal void LoadResult(NsfwSortFileResult? result)
        {
            var filenameBox = form.filenameRichTextBox;
            var mediaViewer = form.mediaViewer;

            if (result == null)
            {
                filenameBox.Text = null;
                mediaViewer.UnloadMedia();
                return;
            }

            ignoreOverrideCheckEvents = true;
            form.overrideNeutralButton.Checked = result.ClassificationOverride == Classification.Neutral;
            form.overrideSexyButton.Checked = result.ClassificationOverride == Classification.Sexy;
            form.overrideHentaiButton.Checked = result.ClassificationOverride == Classification.Hentai;
            form.overridePornographyButton.Checked = result.ClassificationOverride == Classification.Pornography;
            ignoreOverrideCheckEvents = false;

            filenameBox.Text = result.Path.Replace(model.Directory!, string.Empty);
            //filenameBox.Text += $"\n\nThumbnail: {InspectingResult!.ThumbPath}";

            form.chartImg.Image = CreateBarChart(result);

            mediaViewer.LoadMedia(result.Path);
        }

        private Image? CreateBarChart(NsfwSortFileResult? result)
        {
            if (result == null)
            {
                return null;
            }

            int chartWidth = 400;
            int chartHeight = 200;
            int barWidth = 50;
            int spacing = 40;

            var chartBitmap = new Bitmap(chartWidth, chartHeight);
            using (var g = Graphics.FromImage(chartBitmap))
            {
                g.Clear(Color.FromArgb(240, 240, 240));
                //g.Clear(Color.White);
                var dict = result.ClassificationWeights
                    .ToDictionary()
                    .OrderByDescending(kvp => kvp.Key == "Neutral")
                    .ThenByDescending(kvp => kvp.Key == "Sexy")
                    .ThenByDescending(kvp => kvp.Key == "Hentai")
                    .ToList();

                // Calculate total width needed for all bars and spacing
                int totalWidthNeeded = dict.Count * barWidth + (dict.Count - 1) * spacing;
                int startX = (chartWidth - totalWidthNeeded) / 2; // Center the bars horizontally

                // Draw bars
                foreach (var ((key, value), i) in dict.Zip(Enumerable.Range(0, dict.Count)))
                {
                    // (0x, 0y) is top left.
                    int x = startX + i * (barWidth + spacing);
                    int barLabelX = x;

                    var heightRange = chartHeight - 30; // Minus space to allow for bar labels.
                    var barHeight = heightRange * value;    // Value is a range from 0.0 - 1.0 so we can use it as a percentage.

                    var brush =
                        key == "Neutral" ? Brushes.Green :
                        key == "Sexy" ? Brushes.Yellow :
                        Brushes.Red;
                    g.FillRectangle(brush, x, chartHeight - barHeight, barWidth, chartHeight);
                    //g.DrawString(key, new Font("Arial", 10), Brushes.Black, barLabelX, 5);
                }
            }

            return chartBitmap;
        }

        public void OverrideChecked(Classification classification)
        {
            if (!ignoreOverrideCheckEvents && InspectingResult != null)
            {
                InspectingResult.ClassificationOverride = classification;
                model.ClassificationOfResultChanged(InspectingResult);
            }
        }

        internal void OpenSettings()
        {
            var settingsForm = new SettingsForm();
            settingsForm.Show();
        }

        internal void Closing()
        {
            SaveSettingsPreferences();
        }

        private void SaveSettingsPreferences()
        {
            Settings.Default.DuplicateSearch.SearchImages = model.SearchImages;
            Settings.Default.DuplicateSearch.SearchVideos = model.SearchVideos;
            Settings.Default.DuplicateSearch.SearchThreadCount = model.ThreadCount;
            Settings.Save();
        }

        internal void MoveAll(Classification classification)
        {
            var newDirectory = Utilities.OpenDirectory($"Select new location for all '{classification}' files.").FullName;

            var resultToBeMoved = model.Results.Where(r =>
            {
                if (r.ClassificationOverride == classification)
                {
                    return true;
                }

                return r.ClassificationWeights.ToDictionary().MaxBy(kvp => kvp.Value).Key == classification.ToString();
            }).ToList();

            foreach (var result in resultToBeMoved)
            {
                var filename = Path.GetFileName(result.Path);
                Utilities.MoveFile(result.Path, Path.Combine(newDirectory, filename));
                model.ResultsRemove(result);
            }
        }

        internal void UpdateResultsFilter()
        {
            var tet = model.ResultsFilter == Classification.All
                ? model.Results
                : model.Results.Where(r => r.Classification == model.ResultsFilter).ToList();

            model.SetFilteredResults(tet);
        }
    }
}
