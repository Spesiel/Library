using Library.Resources.TextResources;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace Library.Controls
{
    public partial class About : Form
    {
        #region Constructors

        public About()
        {
            InitializeComponent();
            Text = TextsMenu.MenuHelpAbout.Substring(1);
            labelProductName.Text = TextsPermanent.Name;
            labelVersion.Text = Texts.Version + Assembly.GetCallingAssembly().GetName().Version;
            labelCopyright.Text = TextsPermanent.Copyright;
            labelCompanyName.Text = TextsPermanent.Company;
            textBoxDescription.Text = Texts.Description;
        }

        #endregion Constructors

        #region Methods

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion Methods
    }
}
