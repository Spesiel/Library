using Library.Resources.Objects;
using Library.Resources.TextResources;
using System;
using System.Windows.Forms;

namespace Library.Controls
{
    public partial class LayoutWait : UserControl
    {
        #region Delegates + Events

        public event EventHandler Done = delegate { };

        #endregion Delegates + Events

        #region Fields + Properties

        private Progression progression = new Progression();

        #endregion Fields + Properties

        #region Constructors

        public LayoutWait(int total) : this()
        {
            progression.Total = total;
        }

        public LayoutWait()
        {
            InitializeComponent();

            progression.Completed += (s, e) => Done(this, null);

            SetTexts();
            LanguageChoice.LanguageChanged += (s, e) => SetTexts();
        }

        //TOFIX Texts
        private void SetTexts()
        {
            labelTitle.Text = Texts.PleaseWait;
        }

        #endregion Constructors

        #region Methods

        public void UpdateCount(int value)
        {
            progression.Current = value;
            UpdateProgressDisplay();
        }

        public void UpdateTotal(int value)
        {
            progression.Total = value;
            UpdateProgressDisplay();
        }

        private void UpdateProgressDisplay()
        {
            labelProgress.Text = progression.Progress;
            progress.Value = progression.Percentage;
        }

        #endregion Methods
    }
}
