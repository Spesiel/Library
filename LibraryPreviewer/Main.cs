using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library.Previewer
{
    public partial class Main : Form
    {
        #region Constructors

        public Main(string[] args)
        {
            InitializeComponent();

            // One argument, checking if it's a file the application can load
            if (args.Length == 1 && (
                Resources.Constants.
                    AllowedExtensionsImages.Any(e => args[0].EndsWith(e, StringComparison.OrdinalIgnoreCase))
                || Resources.Constants.
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

        internal Main()
        {
            InitializeComponent();
        }

        #endregion Constructors
    }
}
