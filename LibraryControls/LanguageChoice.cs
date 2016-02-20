using Library.Resources;
using Library.Resources.TextResources;
using System;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

namespace Library.Controls
{
    public partial class LanguageChoice : Form
    {
        #region Delegates + Events

        public static event EventHandler LanguageChanged = delegate { };

        #endregion Delegates + Events

        #region Constructors

        public LanguageChoice()
        {
            InitializeComponent();
            SetTexts();

            LanguageChanged += (s, e) => SetTexts();

            foreach (PropertyInfo pi in typeof(AssetsCountry).GetProperties())
            {
                PictureBox pb = new PictureBox();
                pb.Image = pi.GetValue(pi) as Bitmap;

                // When the image is double-clicked
                pb.DoubleClick += (s, e) =>
                {
                    // Changes the culture appropriately
                    CultureInfo.DefaultThreadCurrentCulture = CultureInfo.GetCultureInfo(pi.Name);
                    CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.GetCultureInfo(pi.Name);
                    LanguageChanged(null, EventArgs.Empty);

                    // Closes the form
                    Close();
                };

                flow.Controls.Add(pb);
            }
        }

        //TOFIX Texts
        private void SetTexts()
        {
            Text = Texts.Language;
        }

        #endregion Constructors
    }
}
