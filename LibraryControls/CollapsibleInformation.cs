using Library.Resources.Objects;
using Library.Works;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Library.Controls
{
    public partial class CollapsibleInformation : Penelope.Controls.Collapsible
    {
        #region Fields + Properties

        public string File { get; set; }

        #endregion Fields + Properties

        #region Constructors

        public CollapsibleInformation()
        {
            InitializeComponent();

            SetCollapsingParameters(Size, tabControl, true);
            if (File != null)
            {
                FillExif();
                FillPersons();
                FillTags();
            }
        }

        private void FillExif()
        {
            Exif exif = Navigation.Get(File).Exif;
            foreach (PropertyInfo item in exif.GetType().GetProperties())
            {
                if (!nameof(exif.HasBeenSet).Equals(item.Name))
                {
                    listExif.Items.Add(item.Name + "\t" + item.GetValue(exif, null));
                }
            }
        }

        private void FillPersons()
        {
            foreach (Person p in Navigation.GetAllPersons(File))
            {
                if (string.IsNullOrEmpty(p.DisplayName))
                {
                    listPerson.Items.Add(p.FirstName + " " + p.LastName);
                }
                else
                {
                    listPerson.Items.Add(p.DisplayName);
                }
            }
        }

        private void FillTags()
        {
            foreach (string s in Navigation.GetAllTags(File))
            {
                listTag.Items.Add(s);
            }
        }

        #endregion Constructors
    }
}
