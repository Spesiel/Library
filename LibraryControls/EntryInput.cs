using System.Windows.Forms;

namespace Library.Controls
{
    public partial class EntryInput : Form
    {
        #region Constructors

        public EntryInput(string label)
        {
            InitializeComponent();

            Text = label;

            // Sets the control buttons text
            buttonOK.Text = Resources.Texts.OK;
            buttonCancel.Text = Resources.Texts.Cancel;
        }

        #endregion Constructors
    }
}
