using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SorterExpress.Properties;
using SorterExpress.Classes.SettingsData;

namespace SorterExpress.Controls
{
    public partial class TagPanel : UserControl
    {
        [Bindable(true)]
        public RBindingList<string> Tags { get; set; }

        [Bindable(true)]
        public RBindingList<string> EnabledTags { get; set; }

        private string filter = String.Empty;

        public event EventHandler<TagButtonClickedEventArgs> TagButtonClicked;

        public bool ReorderButtons = true;

        public TagPanel()
        {
            InitializeComponent();
        }

        private void TagPanel_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            { 
                if (Tags != null)
                { 
                    Tags.ListChanged += new ListChangedEventHandler(TagsChanged);
                    Tags.RaiseListChangedEvents = true;
                    Tags.BeforeRemove += TagsBeforeRemove;

                    for (int i = 0; i < Tags.Count; i++)
                        AddTagButton(Tags[i], false);
                }

                if (EnabledTags != null)
                { 
                    EnabledTags.ListChanged += EnabledTagsChanged;
                    EnabledTags.RaiseListChangedEvents = true;
                    EnabledTags.BeforeRemove += EnabledTagsBeforeRemove;
                }

                ReorderTagButtons();
            }
        }

        private void TagsBeforeRemove(IEnumerable<string> deletedItems)
        {
            foreach (string tag in deletedItems)
                RemoveTagButton(tag, false);
        }

        private void TagsChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                AddTagButton(Tags[e.NewIndex], false);
            }
            
            //Reorder even catches removed tags.
            ReorderTagButtons();
        }

        private void EnabledTagsBeforeRemove(IEnumerable<string> deletedItems)
        {
            foreach (CheckBox cb in scrollPanel.Controls.OfType<CheckBox>().Where(t => deletedItems.Contains((string)t.Tag)))
                cb.Checked = false;
        }

        private void EnabledTagsChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                foreach (CheckBox cb in scrollPanel.Controls.OfType<CheckBox>().Where(t => (string)t.Tag == EnabledTags[e.NewIndex]))
                {
                    cb.Checked = true;
                }
            }

            ReorderTagButtons();
        }

        /// <summary>
        /// Hide and Show controls based on a given text filter.
        /// </summary>
        public void UpdateFilter(string filter)
        {
            this.SuspendLayout();

            this.filter = filter;

            string search = filter.ToLower();

            int searchStartLength = Settings.Default.TagSearchStart;
            bool displayAllTags = Settings.Default.DisplayAllTags;

            if (search.Length == 0)
            {
                if (displayAllTags)
                    for (int i = 0; i < scrollPanel.Controls.Count; i++)
                        scrollPanel.Controls[i].Show();
                else
                {
                    for (int i = 0; i < scrollPanel.Controls.Count; i++)
                    {
                        if (EnabledTags.Contains(scrollPanel.Controls[i].Name))
                            scrollPanel.Controls[i].Show();
                        else
                            scrollPanel.Controls[i].Hide();
                    }
                }

                ReorderTagButtons();
            }
            else if (search.Length >= searchStartLength)
            {
                for (int i = 0; i < scrollPanel.Controls.Count; i++)
                {
                    if (scrollPanel.Controls[i].Name.ToLower().Contains(search))
                        scrollPanel.Controls[i].Show();
                    else
                        scrollPanel.Controls[i].Hide();
                }

                ReorderTagButtons();
            }

            this.ResumeLayout();
        }

        /// <summary>
        /// Reorders all visible tag toggle buttons in alphabetical order.
        /// </summary>
        public void ReorderTagButtons()
        {
            if (!ReorderButtons)
                return;

            int scrollY = scrollPanel.AutoScrollPosition.Y;

            CheckBox[] scope;

            if (filter.Length > 0)
            {
                scope = scrollPanel.Controls.OfType<CheckBox>()
                    .Where(t => t.Visible)
                    .OrderByDescending(t => t.Name.ToLower().StartsWith(filter.ToLower()))
                    .ThenBy(t => t.Name).ToArray();
            }
            else
            {
                scope = scrollPanel.Controls.OfType<CheckBox>()
                    .Where(t => t.Visible)
                    .OrderBy(t => t.Name).ToArray();
            }

            var location = new Point(0, -1 + (0 * 26) + scrollY);

            for (int i = 0; i < scope.Length; i++)
            {
                scope[i].Location = location;
                scope[i].TabIndex = i + 1;
                location.Y += 26;
            }

            scrollPanel.VerticalScroll.Visible = true;
        }

        private void AddTagButton(string tag, bool reorder)
        {
            scrollPanel.Controls.Add(CreateTagToggleButton(tag));

            if (reorder)
                ReorderTagButtons();
        }

        /// <summary>
        /// Enter a search filter and toggle the first tag that comes up.
        /// Returns true if a tag was toggled on or off, returns false if the filter returned empty.
        /// Tags are sorted by whether or not they StartWith the filter, and then by name.
        /// </summary>
        internal bool ToggleFirst(string filter)
        {
            CheckBox cb = scrollPanel.Controls.OfType<CheckBox>()
                            .Where(t => t.Visible)
                            .OrderByDescending(t => t.Name.ToLower().StartsWith(filter.ToLower()))
                            .ThenBy(t => t.Name)
                            .FirstOrDefault();

            if (cb != null)
            {
                cb.Checked = !cb.Checked;
                toggleTagButton_MouseUp(cb, new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0));

                if (Settings.Default.AutoResetTagSearchBox)
                {
                    ReorderTagButtons();
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        private void RemoveTagButton(string tag, bool reorder)
        {
            List<CheckBox> tagButtons = scrollPanel.Controls.OfType<CheckBox>().Where(t => t.Name == tag).ToList();

            foreach (Control c in tagButtons)
                scrollPanel.Controls.Remove(c);

            if (reorder)
                ReorderTagButtons();
        }

        private CheckBox CreateTagToggleButton(string tag)
        {
            CheckBox cb = new CheckBox();
            cb.Appearance = Appearance.Button;
            cb.Size = new Size(230, 22);
            cb.Text = tag;
            cb.Tag = tag;
            cb.Name = tag;
            cb.KeyPress += toggleTagButton_KeyPress;
            cb.MouseUp += toggleTagButton_MouseUp;
            //cb.BackColor = buttonBackColor;
            //tooltip.SetToolTip(cb, $"Toggle tag '{tag}' on or off. Right click to delete tag from tag list.");

            return cb;
        }

        private void toggleTagButton_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;

            if (e.KeyChar == '\r')  // /r (13) = enter key, emulate left click.
            {
                cb.Checked = !cb.Checked;
                toggleTagButton_MouseUp(sender, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                e.Handled = true;
            }
            else if (e.KeyChar == '\u001b') // \u001b = escape key, emulate right click.
            {
                toggleTagButton_MouseUp(sender, new MouseEventArgs(MouseButtons.Right, 1, 0, 0, 0));
                e.Handled = true;
            }
        }

        private void toggleTagButton_MouseUp(object sender, MouseEventArgs e)
        {
            CheckBox button = (CheckBox)sender;

            TagButtonClicked.Invoke(this, new TagButtonClickedEventArgs(e, (string)button.Tag));
        }
    }
    
    public class TagButtonClickedEventArgs : MouseEventArgs
    {
        public string Tag;

        public TagButtonClickedEventArgs(MouseEventArgs mea, string tag) : base(mea.Button, mea.Clicks, mea.X, mea.Y, mea.Delta)
        {
            this.Tag = tag;
        }
    }
}