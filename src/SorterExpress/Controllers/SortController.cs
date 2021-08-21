using System;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using SorterExpress.Properties;
using SorterExpress.Controls;
using SorterExpress.Forms;
using SorterExpress.Classes.Actions.SortActions;
using Shortcut = SorterExpress.Classes.Shortcut;

namespace SorterExpress.Controllers
{
    public class SortController
    {
        internal SortForm form;

        Dictionary<Shortcut, Func<bool>> shortcuts = null;

        public string directory;
        public List<string> files;
        public int fileIndex = 0;

        public const int MAX_FILE_WIDTH = 239;
        public const int MAX_FILE_HEIGHT = 275;

        public RBindingList<SubfolderInfo> Subfolders { get; set; } = new RBindingList<SubfolderInfo>();

        public RBindingList<string> Tags { get; set; } = new RBindingList<string>();

        public RBindingList<string> EnabledTags { get; set; } = new RBindingList<string>();

        string note;

        /// <summary>
        /// Actions done by the user, this stack is used for undo.
        /// </summary>
        Stack<SortAction> doneActions = new Stack<SortAction>();

        /// <summary>
        /// Actions undone by the user, this stack is used for redo.
        /// </summary>
        Stack<SortAction> undoneActions = new Stack<SortAction>();

        #region BINDING_PROPERTIES

        public string FilenameNoExtension => (files != null && files.Count > 0) ? Path.GetFileNameWithoutExtension(files[fileIndex]) : "";

        public string FileExtension => (files != null && files.Count > 0) ? Path.GetExtension(files[fileIndex]) : "";

        public string NewFilename => (files != null && files.Count > 0) ? Utilities.GenerateFilename(files[fileIndex], EnabledTags, form.notesTextBox.Text, false) : "";

        public string Note { get { return note; } set { note = value; } }

        public bool EnableUndo => doneActions != null && doneActions.Count() > 0;

        public bool EnableRedo => undoneActions != null && undoneActions.Count() > 0;

        public bool EnablePreviousButtons => (files == null) ? false : fileIndex > 0;

        public bool EnabledNextButtons => (files == null) ? false : fileIndex < files.Count - 1;

        /// <summary>
        /// A bool that specifies whether buttons that depend on having a currently viewed file available.
        /// These buttons are those such as: Save, Delete, Open File, Open File in Explorer
        /// </summary>
        public bool EnabledFileInteractionButtons => (files == null) ? false : files.Count > 0;

        public int FileIndex => fileIndex;

        public int FileCount => (files != null) ? files.Count : 0;

        #endregion
        
        public SortController(SortForm form, DirectoryInfo dirInfo)
        {
            this.form = form;

            LoadDirectory(dirInfo);
        }

        private void LoadDirectory(DirectoryInfo dirInfo)
        {
            ShowLoading();

            form.SuspendLayout();

            var loadedTags = (Settings.Default.Tags != null) ? Settings.Default.Tags : new List<string>();

            form.tagPanel.ReorderButtons = false;

            // Remove all tags that aren't included in the loaded tags.
            Tags.RemoveRange(Tags.Where(t => !loadedTags.Contains(t)));

            // Add all tags that are in loaded tags but not in current tags.
            //Tags.AddRange(loadedTags.Where(t => !Tags.Contains(t)).ToList());
            for (int i = 0; i < loadedTags.Count; i++)
            {
                if (!Tags.Contains(loadedTags[i]))
                {
                    Tags.Add(loadedTags[i]);
                }
            }

            form.tagPanel.ReorderButtons = true;
            form.tagPanel.ReorderTagButtons();

            // Empty all Subfolders and load custom ones from settings.
            //while (Subfolders.Count > 0)
            //Subfolders.RemoveAt(0);
            Subfolders.Clear();

            var sfnames = Settings.Default.SubfolderNames ?? new List<string>();
            var sfdirectories = Settings.Default.SubfolderDirectories ?? new List<string>();

            for (int i = 0; i < Math.Min(sfnames.Count, sfdirectories.Count); i++)
            {
                Subfolders.Add(new SubfolderInfo(sfnames[i], sfdirectories[i], true));
            }

            // Load info specific to chosen directory.

            if (dirInfo == null)
            {
                Logs.Log(true, "Directory open cancelled.");
                this.files = new List<string>();
            }
            else
            {
                this.directory = dirInfo.FullName;
                this.files = dirInfo.GetFileNamesList();

                string[] folders = dirInfo.GetFolderNames();
                for (int i = 0; i < folders.Length; i++)
                    Subfolders.Add(new SubfolderInfo(folders[i], Path.Combine(directory, folders[i]), false));

                fileIndex = 0;

                Logs.Log(true, $"Opened '{directory}' and found {files.Count} files and {folders.Length} subdirectories.");
            }

            form.ResumeLayout();

            HideLoading();
        }

        /// <summary>
        /// Fired by the form on it's Load event.
        /// </summary>
        public void FormLoaded()
        {
            UpdateFileIndex(0);
        }

        public void HideLoading()
        {
            form.loadingPanel.Hide();
        }

        public void ShowLoading(string title = "Loading...", string description = "Please wait.")
        {
            form.loadingPanel.Show();
            form.SortForm_Resize(null, null);

            form.loadingTitleTextBox.Text = title;

            form.loadingDescriptionRichTextBox.Text = description;
            form.loadingDescriptionRichTextBox.SelectAll();
            form.loadingDescriptionRichTextBox.SelectionAlignment = HorizontalAlignment.Center;
            form.loadingDescriptionRichTextBox.DeselectAll();

            form.Refresh();
            form.loadingPanel.Refresh();
        }

        public void HandleShortcut(KeyEventArgs e)
        {
            // Create shortcuts dictionary if not initialised.
            if (shortcuts == null)
            {
                shortcuts = new Dictionary<Shortcut, Func<bool>>() {
                    /*{ new Shortcut(key: Keys.Left), () => { if (form.tagSearchTextBox.Focused && form.tagSearchTextBox.Text.Length == 0) DecrementFileIndex(); }},
                    { new Shortcut(key: Keys.Right), () => { if (form.tagSearchTextBox.Focused && form.tagSearchTextBox.Text.Length == 0) IncrementFileIndex(); } },*/
                    { new Shortcut(key: Keys.Left), () => { return LeftRightKeyShortcut(Keys.Left); }},
                    { new Shortcut(key: Keys.Right), () => { return LeftRightKeyShortcut(Keys.Right); } },
                    { new Shortcut(key: Keys.Enter), () => { return EnterPressed(); } },
                    //{ new Shortcut(key: Keys.Up), () => { form.SelectNextControl(form.ActiveControl, false, false, false, false); }},
                    //{ new Shortcut(key: Keys.Down), () => { form.SelectNextControl(form.ActiveControl, true, false, false, false); }},
                    { new Shortcut(key: Keys.Up), () => { SendKeys.Send("+{TAB}"); return true; }},
                    { new Shortcut(key: Keys.Down), () => { SendKeys.Send("{TAB}"); return true; }},
                    { new Shortcut(alt: true, key: Keys.Left), () => { form.mediaViewer.VideoPosition -= 0.1f; return true; } },
                    { new Shortcut(alt: true, key: Keys.Right), () => { form.mediaViewer.VideoPosition += 0.1f; return true; } },
                    { new Shortcut(ctrl: true, key: Keys.D), () => { Delete(); return true; } },
                    { new Shortcut(ctrl: true, key: Keys.Z), () => { return Undo(); } },
                    { new Shortcut(ctrl: true, key: Keys.Y), () => { return Redo(); } },
                    { new Shortcut(ctrl: true, key: Keys.P), () => { return LoadPreviousTags(); } },
                    { new Shortcut(ctrl: true, key: Keys.S), () => { Move(null); return true; } },   //Same as Enter but without checking focus or length of tagSearchTextbox.

                    // Shortcuts to move current file to a subfolder in list (up to 10).
                    { new Shortcut(alt: true, key: Keys.D1), () => { return MoveFolderShortcut(0); } },
                    { new Shortcut(alt: true, key: Keys.D2), () => { return MoveFolderShortcut(1); } },
                    { new Shortcut(alt: true, key: Keys.D3), () => { return MoveFolderShortcut(2); } },
                    { new Shortcut(alt: true, key: Keys.D4), () => { return MoveFolderShortcut(3); } },
                    { new Shortcut(alt: true, key: Keys.D5), () => { return MoveFolderShortcut(4); } },
                    { new Shortcut(alt: true, key: Keys.D6), () => { return MoveFolderShortcut(5); } },
                    { new Shortcut(alt: true, key: Keys.D7), () => { return MoveFolderShortcut(6); } },
                    { new Shortcut(alt: true, key: Keys.D8), () => { return MoveFolderShortcut(7); } },
                    { new Shortcut(alt: true, key: Keys.D9), () => { return MoveFolderShortcut(8); } },
                    { new Shortcut(alt: true, key: Keys.D0), () => { return MoveFolderShortcut(9); } },
                };
            }

            Shortcut input = new Shortcut(e.Control, e.Alt, e.KeyCode);

            if (shortcuts.ContainsKey(input))
            { 
                bool ok = shortcuts[input].Invoke();

                if (ok)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
                else
                {
                    System.Media.SystemSounds.Beep.Play();
                }
            }

            bool LeftRightKeyShortcut(Keys key)
            {
                if (key != Keys.Left && key != Keys.Right)
                    throw new ArgumentException("Key must be Left or Right.");

                TextBox focusedTextBox = new TextBox[] { form.notesTextBox, form.tagSearchTextBox, form.subfolderSearchTextBox }.Where(t => t.Focused).FirstOrDefault();

                if (focusedTextBox != null && focusedTextBox.Text.Length == 0)
                {
                    if (key == Keys.Left)
                    {
                        return DecrementFileIndex();
                    }
                    else
                    {
                        return IncrementFileIndex();
                    }
                }
                else
                {
                    return false;
                }
            }

            bool MoveFolderShortcut(int index)
            {
                /*SubfolderButton button = form.subfolderPanel.Controls[0].Controls.OfType<SubfolderButton>().OrderBy(t => t.Location.Y).ElementAt(index);

                if (button != null)
                {
                    form.subfolderPanel.subfolderButton_MouseUp(button, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                }*/

                return form.subfolderPanel.PerformClickOnButton(index);
            }

            /// Handle an enter key press (different depending on what control is focused).
            bool EnterPressed()
            {
                if (form.tagSearchTextBox.Focused)
                {
                    if (form.tagSearchTextBox.Text.Length == 0)
                    {
                        form.saveButton.PerformClick();
                    }
                    else if (form.tagSearchTextBox.Text.Length >= Settings.Default.TagSearchStart)
                    {
                        bool aTagWasToggled = form.tagPanel.ToggleFirst(form.tagSearchTextBox.Text);

                        if (aTagWasToggled && Settings.Default.AutoResetTagSearchBox)
                        {
                            form.tagSearchTextBox.Text = "";
                        }

                        return aTagWasToggled;
                    }
                }
                else if (form.tagCreationTextBox.Focused)
                {
                    form.addTagButton.PerformClick();
                    return true;
                }
                else if (form.notesTextBox.Focused)
                {
                    form.saveButton.PerformClick();
                    return true;
                }
                else if (form.subfolderSearchTextBox.Focused)
                {
                    bool success = form.subfolderPanel.PerformClickOnButton(0);

                    if (success)
                    { 
                        if (Settings.Default.AutoResetSubfolderSearchBox)
                        {
                            form.subfolderSearchTextBox.Text = String.Empty;
                            return true;
                        }
                        else
                        { 
                            return false;
                        }
                    }
                }

                return false;
            }
        }

        private bool LoadPreviousTags()
        {
            const bool EMPTY_CURRENT_TAGS = false;

            for (int i = 0; i < doneActions.Count; i++)
            {
                SortAction action = doneActions.ElementAt(i);

                //Search through doneActions for the most recent "Move" action that will have the previously used tags in it.
                if (action.GetType() == typeof(Move))
                {
                    if (EMPTY_CURRENT_TAGS)
                        while (EnabledTags.Count > 0)
                            EnabledTags.Clear();

                    /*for (int t = 0; t < (action as Move).tags.Length; t++)
                    {
                        EnabledTags.Add((action as Move).tags[t]);
                    }*/

                    EnabledTags.AddRange((action as Move).tags);

                    // The most recent move action was found and the tags were loaded.
                    return true;
                }
            }

            // No recent move action was found and no tags were loaded.
            return false;
        }

        public bool DecrementFileIndex()
        {
            return UpdateFileIndex(fileIndex - 1);
        }

        public bool IncrementFileIndex()
        {
            return UpdateFileIndex(fileIndex + 1);
        }

        public void GotoFirstFileIndex()
        {
            UpdateFileIndex(0);
        }

        public void GotoLastFileIndex()
        {
            UpdateFileIndex(files.Count - 1);
        }

        public void AddTag(string newTag)
        {
            if (Tags.Any(t => t == newTag))
            {
                MessageBox.Show("That tag already exists.", "Add Tag Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (Tags.Count == 0)
                    Tags.Add(newTag);
                else
                {
                    for (int i = 0; i < Tags.Count; i++)
                    {
                        if (String.Compare(newTag, Tags[i]) < 0)
                        {
                            Tags.Insert(i, newTag);
                            break;
                        }
                        else if (i == (Tags.Count - 1))
                        {
                            Tags.Add(newTag);
                            break;
                        }
                    }
                }
            }
        }

        public void TagButtonClicked(TagButtonClickedEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ToggleTag(e.Tag);
            }
            else //Right Click
            {
                Tags.Remove(e.Tag);
                EnabledTags.Remove(e.Tag);
            }
        }

        public void OpenNewDirectory()
        {
            DirectoryInfo dirInfo = Utilities.OpenDirectory();

            if (dirInfo != null)
            {
                SaveSettings();
                LoadDirectory(dirInfo);
                UpdateFileIndex(0);
            }
        }

        public void AddCustomSubfolder()
        {
            AddDirectoryForm adf = new AddDirectoryForm((name, directory) =>
            {
                Subfolders.Add(new SubfolderInfo(name, directory, true));
            });

            adf.ShowDialog();
        }

        /// <summary>
        /// Set the file index variable and perform all other behaviour such as loading file.
        /// </summary>
        /// <param name="newFileIndex"></param>
        public bool UpdateFileIndex(int newFileIndex)
        {
            bool wasInRange = true;

            // Clamp value
            int clampedNewFileIndex;

            if (files.Count == 0)
            {
                clampedNewFileIndex = 0;
            }
            else
            {
                clampedNewFileIndex = (newFileIndex >= files.Count) ? files.Count - 1 : newFileIndex;
                clampedNewFileIndex = (clampedNewFileIndex < 0) ? 0 : clampedNewFileIndex;
            }

            if (newFileIndex != clampedNewFileIndex)
            {
                wasInRange = false;
            }

            fileIndex = clampedNewFileIndex;

            // Update labels in view.
            form.ChangeFileIndexTextBoxTextSilently((fileIndex + (files.Count > 0 ? 1 : 0)).ToString());

            //Load new file.
            if (files.Count > 0)
                form.mediaViewer.LoadMedia(Path.Combine(directory, files[fileIndex]));

            //TODO: Textboxes aren't updating when file index is changed. This is temporary (and slow) fix. Find out why.
            form.ValidateChildren();

            return wasInRange;
        }

        #region Actions

        private void DoAction(SortAction action)
        {
            action.Do();
            doneActions.Push(action);
            undoneActions.Clear();

            form.ValidateChildren();
        }

        /// <summary>
        /// Pop an action from the doneActions stack and exeucutes it. Returns false if there was no action on the stack to undo.
        /// </summary>
        public bool Undo()
        {
            if (doneActions.Count > 0)
            { 
                SortAction action = doneActions.Pop();

                action.Undo();

                if (action.Successful)
                    undoneActions.Push(action);

                form.ValidateChildren();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Pop an action from the undoneActions stack and exeucutes it. Returns false if there was no action on the stack to redo.
        /// </summary>
        public bool Redo()
        {
            if (undoneActions.Count > 0)
            { 
                SortAction action = undoneActions.Pop();

                action.Do();

                if (action.Successful)
                    doneActions.Push(action);

                form.ValidateChildren();

                return true;
            }

            return false;
        }

        public void Delete()
        {
            Delete action = new Delete(this, Path.Combine(directory, files[fileIndex]), fileIndex);
            action.Do();
            doneActions.Push(action);
            undoneActions.Clear();

            form.ValidateChildren();
        }

        /// <summary>
        /// Move/Rename a file.
        /// Optionally move it to a new directory, enter null for no moving.
        /// </summary>
        public void Move(string toDirectory)
        {
            if (toDirectory == null)
                toDirectory = directory;

            if (Settings.Default.MoveSortedFiles && toDirectory == directory)
            {
                toDirectory = Path.Combine(toDirectory, "Sorted");

                if (!Directory.Exists(toDirectory))
                    Directory.CreateDirectory(toDirectory);
            }

            Classes.Actions.SortActions.Move moveAction = new Classes.Actions.SortActions.Move(
                this, 
                Path.Combine(directory, files[fileIndex]), 
                toDirectory, 
                EnabledTags.ToArray(), 
                form.notesTextBox.Text,
                fileIndex
            );

            DoAction(moveAction);
        }

        //TODO: Add more checks for the fileIndex being equal to or less than current fileIndex and changing behaviour.
        public void RemoveFile(int fileIndex)
        {
            if (fileIndex == this.fileIndex)
                form.mediaViewer.UnloadMedia(true);

            files.RemoveAt(fileIndex);

            //while (EnabledTags.Count > 0)
                //EnabledTags.RemoveAt(0);

            EnabledTags.Clear();

            note = String.Empty;

            UpdateFileIndex(fileIndex);

            form.ValidateChildren();
        }

        /// <summary>
        /// Reload a file, insert it into the file list at the specified index, view it, and reload the given tags and notes.
        /// </summary>
        public void ReloadFile(string filename, int fileIndex, string[] tags = null, string note = null)
        {
            fileIndex = (fileIndex < 0) ? 0 : fileIndex;
            fileIndex = (fileIndex > files.Count) ? files.Count : fileIndex;

            files.Insert(fileIndex, filename);

            UpdateFileIndex(fileIndex);

            if (tags != null)
            {
                while (EnabledTags.Count > 0)
                    EnabledTags.RemoveAt(0);

                foreach (string tag in tags)
                    EnabledTags.Add(tag);
            }

            if (note != null)
                this.note = note;

            form.ValidateChildren();
        }

        #endregion

        public void ToggleTag(string tag)
        {
            if (EnabledTags.Contains(tag))
                EnabledTags.Remove(tag);
            else
                EnabledTags.Add(tag);
        }

        public void SubFolderButtonClicked(SubfolderButtonClickedEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Directory.Exists(e.SubfolderInfo.directory))
                {
                    Move(e.SubfolderInfo.directory);

                    //TODO: What to do about moving focus between controls when moving files?
                    //form.tagSearchTextBox.Focus();
                }
                else
                {
                    DialogResult result = MessageBox.Show($"The selected directory \"{e.SubfolderInfo.directory}\" does not exist, would you like to remove it from the list?", 
                        "Directory does not exist", 
                        MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Error);

                    if (result == DialogResult.Yes)
                        Subfolders.Remove(e.SubfolderInfo);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (e.SubfolderInfo.custom)
                {
                    Subfolders.Remove(e.SubfolderInfo);
                }
            }
        }

        #region Meta Application Interactions - (ApplicationResized, ApplicationExit, etc..)

        public void OpenSettings()
        {
            SaveSettings();
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.TagsSaved += (newTagLibrary) =>
            {
                //Stop reordering of buttons for each one added/removed for optimisation.
                form.tagPanel.ReorderButtons = false;

                // Remove all current tags that aren't in the new library.
                Tags.RemoveRange(Tags.Where(t => !newTagLibrary.Contains(t)));

                // Add tags that are not in current tags.
                foreach (string tag in newTagLibrary)
                {
                    if (!Tags.Contains(tag))
                        Tags.Add(tag);
                }

                // Resume reordering and force a reorder.
                form.tagPanel.ReorderButtons = true;
                form.tagPanel.ReorderTagButtons();
            };
            settingsForm.ShowDialog();
        }

        public void SaveSettings()
        {
            // On exit, set all these prefs but dont save after each one, save after setting them all.
            Settings.Default.Tags = Tags.ToList();

            Settings.Default.SubfolderNames = Subfolders.Where(t => t.custom).Select(t => t.name).ToList();
            Settings.Default.SubfolderDirectories = Subfolders.Where(t => t.custom).Select(t => t.directory).ToList();

            //Settings.Default.VideoMute = mediaViewer.Mute;
            //Settings.Default.VideoVolume = mediaViewer.VolumeLevel;

            Settings.Default.Save();
        }

        #endregion
    }
}
