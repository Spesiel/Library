using Library.Controls;
using Library.Resources;
using Library.Resources.TextResources;
using System.Windows.Forms;

namespace LibraryViewer
{
    public partial class MainForm : Form
    {
        #region Constructors

        public MainForm()
        {
            InitializeComponent();

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

        #region Menu Help About

        private void aboutToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            using (About about = new About())
            {
                if (about.ShowDialog() == DialogResult.None) about.Hide();
            }
        }

        #endregion Menu Help About

        #region Methods

        private void languageToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            using (LanguageChoice language = new LanguageChoice())
            {
                if (language.ShowDialog() == DialogResult.None) language.Hide();
            }
        }

        #endregion Methods
    }
}
