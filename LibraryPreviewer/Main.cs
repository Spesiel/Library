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
            if (args.Length == 1 &&
                (Resources.Constants.AllowedExtensionsImages.Any(e => args[0].EndsWith(e, StringComparison.OrdinalIgnoreCase)) ||
                Resources.Constants.AllowedExtensionsVideos.Any(e => args[0].EndsWith(e, StringComparison.OrdinalIgnoreCase))) &&
                System.IO.File.Exists(args[0]))
            {
                //TODO Try and load the file
            }
        }

        internal Main()
        {
            InitializeComponent();
        }

        #endregion Constructors
    }
}
