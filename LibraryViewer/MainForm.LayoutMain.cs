using Library.Controls;
using System.Windows.Forms;

namespace Library.Viewer
{
    public partial class MainForm
    {
        #region Fields + Properties

        private LayoutMainForm layoutMain;

        #endregion Fields + Properties

        #region Methods

        public void DisplayMain()
        {
            Controls.Remove(layoutWait);
            layoutWait = null;

            layoutMain = new LayoutMainForm();
            layoutMain.Dock = DockStyle.Fill;
            layoutMain.ResumeLayout(true);

            Controls.Add(layoutMain);
            ResumeLayout(true);
        }

        #endregion Methods
    }
}
