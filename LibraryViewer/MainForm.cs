using Library.Controls;
using Library.Resources;
using Library.Resources.Objects;
using Library.Resources.TextResources;
using Library.Works;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Library.Viewer
{
    public partial class MainForm : Form
    {
        #region Fields + Properties

        private Progression progression = new Progression();

        #endregion Fields + Properties

        #region Constructors

        public MainForm()
        {
            InitializeComponent();

            progression.Changed += (s, e) =>
            {
                if (!statusStripProgressLabel.Visible)
                {
                    statusStripProgressLabel.Visible = true;
                    statusStripProgressBar.Visible = true;
                }
                statusStripProgressLabel.Text = progression.Progress;
                statusStripProgressBar.Value = progression.Percentage;
            };

            progression.Completed += (s, e) =>
            {
                using (Timer timer = new Timer())
                {
                    timer.Interval = 3000;
                    timer.Tick += (se, ev) =>
                    {
                        statusStripProgressLabel.Visible = false;
                        statusStripProgressBar.Visible = false;
                    };
                    timer.Start();
                }
            };

            // Menu strip images
            //// File
            menuStripFileOpen.Image = AssetsImage.FolderOpen;
            menuStripFileLoad.Image = AssetsImage.FolderLoad;

            SetTexts();
            LanguageChoice.LanguageChanged += (s, e) => SetTexts();
        }

        //TOFIX Texts
        private void SetTexts()
        {
            // File
            fileToolStripMenuItem.Text = TextsMenu.MenuFile;
            menuStripFileOpen.Text = TextsMenu.MenuFileOpen;
            menuStripFileLoad.Text = TextsMenu.MenuFileLoad;

            // ? (help)
            helpToolStripMenuItem.Text = TextsMenu.MenuHelp;
            aboutToolStripMenuItem.Text = TextsMenu.MenuHelpAbout;
        }

        #endregion Constructors

        #region Menu File

        private BackgroundWorker worker = new BackgroundWorker() { WorkerReportsProgress = true };

        /// <summary>
        /// Loads a directory as a new Library
        /// </summary>
        private void menuStripFileLoad_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (DialogResult.OK.Equals(fbd.ShowDialog()))
                {
                    // Progress is reported as percentage by the worker.
                    progression.Total = 100;
                    worker.ProgressChanged += (s, ev) =>
                    {
                        progression.Current = ev.ProgressPercentage;
                    };
                    worker.RunWorkerCompleted += (s, ev) =>
                    {
                        progression.Current = 100;
                        DisplayMain();
                    };
                    DisplayWait();

                    //Loads the directory
                    LibraryManager.LoadDirectory(worker, fbd.SelectedPath);
                }
            }

            LibraryManager.Save();
        }

        /// <summary>
        /// Open an existing Library. Loads a directory if there's no existing Library
        /// </summary>
        private void menuStripFileOpen_Click(object sender, EventArgs e)
        {
            // If there's no settings file, there's no existing Library. Create a new one
            if (!File.Exists(Constants.SettingsFile))
            {
                menuStripFileLoad_Click(sender, e);
            }

            // A settings file exists. Load the Library
            LibraryManager.Load();
            int[] update = LibraryManager.CheckForUpdates();

            // Display the update message for 3 minutes
            statusStripUpdateLabel.Text = string.Format(Texts.StatusUpdate, update);
            statusStripUpdateLabel.Visible = true;
            Timer updateTimer = new Timer();
            updateTimer.Interval = 3 * 60 * 1000; // 3 * 60s * 1000ms = 3min
            updateTimer.Tick += (s, ev) => statusStripUpdateLabel.Visible = false;
            updateTimer.Start();

            LibraryManager.Save();
        }

        #endregion Menu File

        #region Menu Help

        /// <summary>
        /// Displays the About box
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (About about = new About())
            {
                if (about.ShowDialog() == DialogResult.None) about.Hide();
            }
        }

        /// <summary>
        /// Displays the Choose your language box
        /// </summary>
        private void languageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (LanguageChoice language = new LanguageChoice())
            {
                if (language.ShowDialog() == DialogResult.OK) language.Hide();
            }
        }

        #endregion Menu Help
    }
}
