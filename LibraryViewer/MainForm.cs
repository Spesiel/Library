using Library.Controls;
using Library.Resources;
using Library.Resources.Objects;
using Library.Resources.TextResources;
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

        #region Menu Help

        private void aboutToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            using (About about = new About())
            {
                if (about.ShowDialog() == DialogResult.None) about.Hide();
            }
        }

        private void languageToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            using (LanguageChoice language = new LanguageChoice())
            {
                if (language.ShowDialog() == DialogResult.None) language.Hide();
            }
        }

        #endregion Menu Help
    }
}
