using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Onova;
using Onova.Models;
using Onova.Services;

namespace SorterExpress.Controls
{
    public partial class UpdateView : UserControl
    {
        private IUpdateManager updateManager;

        Progress<double> progress = new Progress<double>();

        CheckForUpdatesResult checkForUpdatesResult;

        public delegate void UpdateStartedEvent(object sender, EventArgs e);

        public event UpdateStartedEvent UpdateStarted;

        string currentVersion;

        const string LABEL_CHECKING = "Checking for updates...";
        string LABEL_NO_UPDATES => $"No updates available. Current version: {currentVersion}";
        string LABEL_UPDATE_AVAILABLE => $"Update available! Current version: {currentVersion} Latest version: {checkForUpdatesResult.LastVersion}";
        const string LABEL_UPDATING = "Downloading update... Please wait...";

        const string BUTTON_CHECK_FOR_UPDATES = "Check for Updates";
        const string BUTTON_UPDATE_NOW = "Update Now";

        public UpdateView()
        {
            InitializeComponent();
        }

        private void UpdateView_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                progress.ProgressChanged += Progress_ProgressChanged;

                updateManager = new UpdateManager(
                    new GithubPackageResolver(Program.GITHUB_REPOSITORY_OWNER, Program.NAME, "SorterExpress-*.zip"),
                    new ZipPackageExtractor()
                );

                currentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString().Trim();

                // Cut off trailing ".0"'s.
                while (string.Join("", currentVersion.Skip(Math.Max(0, currentVersion.Length - 2))) == ".0")
                {
                    currentVersion = currentVersion.Substring(0, currentVersion.Length - 2);
                }

                CheckForUpdates();
            }
        }

        private async void CheckForUpdates()
        {
            label.Text = LABEL_CHECKING;
            button.Enabled = false;
            checkForUpdatesResult = await updateManager.CheckForUpdatesAsync();

            if (checkForUpdatesResult.CanUpdate)
            {
                label.Text = LABEL_UPDATE_AVAILABLE;
                button.Text = BUTTON_UPDATE_NOW;
                button.Enabled = true;
            }
            else
            {
                new Thread(() => {
                    Thread.Sleep(500);
                    Invoke((MethodInvoker)delegate () {
                        label.Text = LABEL_NO_UPDATES;
                        button.Text = BUTTON_CHECK_FOR_UPDATES;
                        button.Enabled = true;
                    });
                }).Start();
            }
        }

        private void Progress_ProgressChanged(object sender, double e)
        {
            Invoke((MethodInvoker)delegate () { progressBar.Value = (int)(e * 100); });
        }

        private async void button_Click(object sender, EventArgs e)
        {
            if (button.Text == BUTTON_CHECK_FOR_UPDATES)
            {
                CheckForUpdates();
            }
            if (button.Text == BUTTON_UPDATE_NOW)
            {
                DialogResult result = MessageBox.Show(
                    $"There is an update available. Your current version is {currentVersion}, the latest version is {checkForUpdatesResult.LastVersion}. Would you like to update to the latest version?",
                    "Update Available",
                    MessageBoxButtons.YesNo
                );

                if (result == DialogResult.Yes)
                {
                    UpdateStarted?.Invoke(this, EventArgs.Empty);

                    label.Text = LABEL_UPDATING;
                    button.Hide();
                    progressBar.Show();

                    // Prepare the latest update
                    await updateManager.PrepareUpdateAsync(checkForUpdatesResult.LastVersion, progress);

                    // Launch updater and exit
                    updateManager.LaunchUpdater(checkForUpdatesResult.LastVersion);

                    Application.Exit();
                }
            }
        }
    }
}
