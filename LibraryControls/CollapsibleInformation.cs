using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Library.Controls
{
    public partial class CollapsibleInformation : Penelope.Controls.Collapsible
    {
        #region Constructors

        public CollapsibleInformation()
        {
            InitializeComponent();

            SetCollapsingParameters(Size, tabControl, true);
        }

        #endregion Constructors
    }
}
