using Library.Resources;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Library.Previewer
{
    public partial class Preview : Form
    {
        #region Constructors

        public Preview(string[] args)
        {
            InitializeComponent();

            // Set navigation images
            picturePrevious.Image = Assets.ArrowLeft;
            pictureNext.Image = Assets.ArrowRight;

            // One argument, checking if it's a file the application can load
            if (args.Length == 1 && (
                Constants.
                    AllowedExtensionsImages.Any(e => args[0].EndsWith(e, StringComparison.OrdinalIgnoreCase))
                || Constants.
                    AllowedExtensionsVideos.Any(e => args[0].EndsWith(e, StringComparison.OrdinalIgnoreCase))
                ) && System.IO.File.Exists(args[0]))
            {
                // Load the pic
                pictureBox.LoadAsync(args[0]);

                // Disable the information panel
                Informations.Enabled = false;
                Informations.Visible = false;
            }
        }

        internal Preview()
        {
            InitializeComponent();
        }

        #endregion Constructors
    }
}
