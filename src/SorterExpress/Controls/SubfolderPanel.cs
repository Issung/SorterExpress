using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using SorterExpress.Classes;

namespace SorterExpress.Controls
{
    public partial class SubfolderPanel : UserControl
    {
        [Bindable(true)]
        public RBindingList<SubfolderInfo> Subfolders { get; set; }

        public event EventHandler<SubfolderButtonClickedEventArgs> SubfolderButtonClicked;

        public SubfolderPanel()
        {
            InitializeComponent();
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
            foreach(SubfolderInfo sfi in deletedItems)
                RemoveSubfolderButton(sfi, false);
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
            ReorderSubfolderButtons();
        }

        Label divider = null;

        /// <summary>
        /// Reorders all visible tag toggle buttons in custom -> non-custom order and then alphabetical order.
        /// </summary>
        public void ReorderSubfolderButtons()
        {
            //Do this so that we dont remove the VScrollBar

            int position = -1 + scrollPanel.AutoScrollPosition.Y;
            const int positionAdd = 26;

            int tabIndex = 0;

            var customSubfolders = Subfolders.Where(t => t.custom).ToArray();
            var customSubfoldersButtons = scrollPanel.Controls.OfType<SubfolderButton>().Where(t => t.subfolderInfo.custom);
            var folders = Subfolders.Where(t => !t.custom).ToArray();
            var foldersButtons = scrollPanel.Controls.OfType<SubfolderButton>().Where(t => !t.subfolderInfo.custom);

            for (int i = 0; i < customSubfoldersButtons.Count(); i++)
            {
                var button = customSubfoldersButtons.ElementAt(i);
                button.Location = new Point(0, position);
                position += positionAdd;
                button.TabIndex = tabIndex;
                tabIndex++;
            }

            if (customSubfolders.Length > 0 && folders.Length > 0)
            {
                if (divider == null)
                { 
                    divider = new Label();
                    divider.Text = "";
                    divider.BorderStyle = BorderStyle.Fixed3D;
                    divider.AutoSize = false;
                    divider.Height = 2;
                    divider.Width = 189 - 2 - 20;
                    scrollPanel.Controls.Add(divider);
                }

                divider.Location = new Point(0 + 10, position);
                divider.BringToFront();
                divider.Show();
                position += 5;
            }
            else
            {
                if (divider != null)
                    divider.Hide();
            }

            for (int i = 0; i < foldersButtons.Count(); i++)
            {
                SubfolderButton button = foldersButtons.ElementAt(i);
                button.Location = new Point(0, position);
                position += positionAdd;
                button.TabIndex = tabIndex;
                tabIndex++;
            }
        }

        /// <summary>
        /// Add a button to this control and reorder the buttons into their proper order.
        /// Reordering buttons can be disabled if desired, for example if adding alot of buttons.
        /// Reordering can then be done with ReorderSubfolderButtons().
        /// </summary>
        private void AddSubfolderButton(SubfolderInfo subfolderInfo, bool reorderAllButtons)
        {
            scrollPanel.Controls.Add(CreateSubfolderButton(subfolderInfo));

            if (reorderAllButtons)
                ReorderSubfolderButtons();
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

            if (reorderButtons && changed)
                ReorderSubfolderButtons();
        }

        private SubfolderButton CreateSubfolderButton(SubfolderInfo subfolderInfo)
        {
            SubfolderButton button = new SubfolderButton();
            button.Size = new Size(189, 22);
            button.UseMnemonic = false;
            button.Enabled = Enabled;

            button.Text = subfolderInfo.name;
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
