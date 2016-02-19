using Library.Controls;
using Library.Resources;
using System.Windows.Forms;

namespace LibraryViewer
{
    public partial class MainForm : Form
    {
        #region Constructors

        public MainForm()
        {
            InitializeComponent();

            //TOFIX Menu strip images
            //// File
            menuStripFileOpen.Image = Assets.FolderOpen;
            menuStripFileLoad.Image = Assets.FolderLoad;

            //TOFIX Menu strip texts
            //// File
            fileToolStripMenuItem.Text = TextsMenu.MenuFile;
            menuStripFileOpen.Text = TextsMenu.MenuFileOpen;
            menuStripFileLoad.Text = TextsMenu.MenuFileLoad;
            //// ? (help)
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
    }
}
