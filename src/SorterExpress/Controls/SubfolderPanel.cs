using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace SorterExpress.Controls
{
    public partial class SubfolderPanel : UserControl
    {
        [Bindable(true)]
        public RBindingList<SubfolderInfo> Subfolders { get; set; }

        public event EventHandler<SubfolderButtonClickedEventArgs> SubfolderButtonClicked;
        public string Filter { get { return _filter == null ? String.Empty : _filter; } set { _filter = value; FilterChanged(); } }

        private string _filter;

        private bool layoutSuspended = false;

        /// <summary>
        /// A UI label that has specific settings applied to make it look like a horizontal divider.
        /// </summary>
        private Label divider = new Label
        {
            Text = "",
            BorderStyle = BorderStyle.Fixed3D,
            AutoSize = false,
            Height = 2,
            Width = 189 - 2 - 20,
        };

        public SubfolderPanel()
        {
            InitializeComponent();
            scrollPanel.Controls.Add(divider);
        }

        private void TagPanel_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                SuspendLayout();

                if (Subfolders != null)
                {
                    //Subfolders.ListChanged += new RListChangedEventHandler(SubfoldersChanged);
                    Subfolders.ListChanged += SubfoldersChanged;
                    Subfolders.RaiseListChangedEvents = true;

                    Subfolders.BeforeRemove += SubfoldersBeforeRemove;

                    for (int i = 0; i < Subfolders.Count; i++)
                        AddSubfolderButton(Subfolders[i], false);
                }

                ReorderSubfolderButtons();

                ResumeLayout();
            }
        }

        private void SubfoldersBeforeRemove(IEnumerable<SubfolderInfo> deletedItems)
        {
            foreach (SubfolderInfo sfi in deletedItems)
            { 
                RemoveSubfolderButton(sfi, false);
            }
        }

        private void SubfoldersChanged(object sender, ListChangedEventArgs e)
        {
            string val = (Subfolders != null) ? String.Join(", ", Subfolders) : "null";
            Console.WriteLine($"SubfoldersChanged! tags: {val}");

            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                AddSubfolderButton(Subfolders[e.NewIndex], false);
            }

            //Reorder incase of a deletion that wasnt caught in the above if statement and was instead done in "SubfoldersBeforeRemove".
            if (!layoutSuspended)
            { 
                ReorderSubfolderButtons();
            }
        }

        private void FilterChanged()
        {
            SuspendLayout();

            if (Filter.Length == 0)
            {
                foreach (SubfolderButton button in scrollPanel.Controls.OfType<SubfolderButton>())
                    button.Visible = true;
            }
            else
            {
                foreach (SubfolderButton button in scrollPanel.Controls.OfType<SubfolderButton>())
                    button.Visible = button.subfolderInfo.Name.ToLower().Contains(Filter.ToLower()) ? true : false;
            }

            ResumeLayout(reoderButtons: true);
        }

        /// <summary>
        /// PerformClick on a button in the subfolder list. Index starts from the top with 0 with only visible buttons (Filter compliance).
        /// Returns true if a visible button existed at the given index and was clicked, false if other wise (index out of visible buttons range).
        /// </summary>
        public bool PerformClickOnButton(int indexFromTop)
        {
            SubfolderButton button = scrollPanel.Controls.OfType<SubfolderButton>().Where(t => t.Visible).OrderBy(t => t.Location.Y).ElementAt(indexFromTop);

            if (button != null)
            {
                subfolderButton_MouseUp(button, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                return true;
            }
            else
            {
                return false;
            }
        }
        
        /// <summary>
        /// Reorders all visible tag toggle buttons in custom -> non-custom order and then alphabetical order.
        /// </summary>
        public void ReorderSubfolderButtons()
        {
            Debug.WriteLine("ReorderSubfolderButtons!");

            if (Subfolders == null)
                return;
            
            SuspendLayout();

            //Do this so that we dont remove the VScrollBar

            int position = -1 + scrollPanel.AutoScrollPosition.Y;
            const int positionAdd = 26;

            int tabIndex = 0;

            // If there is a filter stop seperating buttons by custom/noncustom and just order them all by StartsWith and then alphabetically by name.
            if (Filter.Length > 0)
            {
                divider.Hide();

                var subfolderButtons = scrollPanel.Controls.OfType<SubfolderButton>()
                    .Where(t => t.Visible)
                    .OrderByDescending(t => t.subfolderInfo.Name.ToLower().StartsWith(Filter.ToLower()))
                    .ThenBy(t => t.subfolderInfo.Name);

                foreach (var button in subfolderButtons)
                {
                    button.Location = new Point(0, position);
                    position += positionAdd;
                    button.TabIndex = tabIndex;
                    tabIndex++;
                }
            }
            else    // If there is no filter than seperate buttons by custom/noncustom and order alphabetically by name.
            {
                var customSubfolders = Subfolders.Where(t => t.Custom).ToArray();
                var customSubfoldersButtons = scrollPanel.Controls.OfType<SubfolderButton>().Where(t => t.Visible && t.subfolderInfo.Custom);
                var folders = Subfolders.Where(t => !t.Custom).ToArray();
                var foldersButtons = scrollPanel.Controls.OfType<SubfolderButton>().Where(t => t.Visible && !t.subfolderInfo.Custom);

                foreach (var button in customSubfoldersButtons)
                {
                    button.Location = new Point(0, position);
                    position += positionAdd;
                    button.TabIndex = tabIndex;
                    tabIndex++;
                }

                if (customSubfolders.Length > 0 && folders.Length > 0)
                {
                    divider.Location = new Point(0 + 10, position);
                    divider.BringToFront();
                    divider.Show();
                    position += 5;
                }
                else
                {
                    divider.Hide();
                }

                foreach (var button in foldersButtons)
                {
                    button.Location = new Point(0, position);
                    position += positionAdd;
                    button.TabIndex = tabIndex;
                    tabIndex++;
                }
            }

            ResumeLayout();
        }

        /// <summary>
        /// Add a button to this control and reorder the buttons into their proper order.
        /// Reordering buttons can be disabled if desired, for example if adding alot of buttons.
        /// Reordering can then be done with ReorderSubfolderButtons().
        /// </summary>
        private void AddSubfolderButton(SubfolderInfo subfolderInfo, bool reorderAllButtons)
        {
            scrollPanel.Controls.Add(CreateSubfolderButton(subfolderInfo));

            if (reorderAllButtons && !layoutSuspended)
            { 
                ReorderSubfolderButtons();
            }
        }

        public void RemoveSubfolderButton(SubfolderInfo subfolderInfo, bool reorderButtons)
        {
            bool changed = false;
            IEnumerable<SubfolderButton> buttons = scrollPanel.Controls.OfType<SubfolderButton>().Where(t => t.subfolderInfo == subfolderInfo);
            
            foreach (Control c in buttons)
            { 
                scrollPanel.Controls.Remove(c);
                changed = true;
            }

            if (reorderButtons && changed && !layoutSuspended)
                ReorderSubfolderButtons();
        }

        private SubfolderButton CreateSubfolderButton(SubfolderInfo subfolderInfo)
        {
            SubfolderButton button = new SubfolderButton();
            button.Size = new Size(189, 22);
            button.UseMnemonic = false;
            button.Enabled = Enabled;

            button.Text = subfolderInfo.Name;
            button.subfolderInfo = subfolderInfo;

            //tooltip.SetToolTip(button, directory + (custom ? "\nThis is a custom, user-added directory, right click to remove." : ""));

            button.TextAlign = ContentAlignment.BottomLeft;
            button.MouseUp += subfolderButton_MouseUp;

            return button;
        }

        public void subfolderButton_MouseUp(object sender, MouseEventArgs e)
        {
            SubfolderButton button = (SubfolderButton)sender;

            SubfolderButtonClickedEventArgs eventArgs = new SubfolderButtonClickedEventArgs(e, button.subfolderInfo);

            SubfolderButtonClicked(this, eventArgs);
        }

        private void SubfolderPanel_EnabledChanged(object sender, EventArgs e)
        {
            foreach (SubfolderButton sfb in scrollPanel.Controls.OfType<SubfolderButton>())
            {
                sfb.Enabled = Enabled;
            }

            Refresh();
        }

        public new void SuspendLayout()
        {
            layoutSuspended = true;
            scrollPanel.SuspendLayout();
            base.SuspendLayout();
        }

        public new void ResumeLayout(bool reorderButtons = false)
        {
            if (reorderButtons)
            {
                ReorderSubfolderButtons();
            }

            layoutSuspended = false;
            scrollPanel.ResumeLayout();
            base.ResumeLayout();
        }
    }

    public class SubfolderButtonClickedEventArgs : MouseEventArgs
    {
        public SubfolderInfo SubfolderInfo;

        public SubfolderButtonClickedEventArgs(MouseEventArgs mea, SubfolderInfo subfolderInfo) : base(mea.Button, mea.Clicks, mea.X, mea.Y, mea.Delta)
        {
            SubfolderInfo = subfolderInfo;
        }
    }
}
