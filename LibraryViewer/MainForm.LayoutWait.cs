using Library.Controls;
using System.Windows.Forms;

namespace Library.Viewer
{
    public partial class MainForm
    {
        #region Fields + Properties

        private LayoutWait layoutWait;

        #endregion Fields + Properties

        #region Methods

        public void DisplayWait(int total = 0)
        {
            Controls.Remove(layoutMain);
            layoutMain = null;

            layoutWait = new LayoutWait(total);
            layoutWait.Dock = DockStyle.Fill;
            layoutWait.ResumeLayout(true);

            Controls.Add(layoutWait);
            ResumeLayout(true);
        }

        #endregion Methods
    }
}
