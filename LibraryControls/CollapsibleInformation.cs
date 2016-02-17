using Library.Resources;
using Library.Resources.Objects;
using Library.Works;
using System;
using System.Collections.Generic;
using System.Reflection;
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

            // Set navigation images
            pictureTagAdd.Image = Assets.Add;
            pictureTagRemove.Image = Assets.Remove;

            SetCollapsingParameters(Size, tabControl, true);

            // If a file has been specified, try and load its informations from the database
            if (File != null)
            {
                FillExif();
                FillPersons();
                FillTags();
            }
        }

        #endregion Constructors

        #region FillSth Methods

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

        #endregion FillSth Methods

        #region Tags: Methods

        private string oldTag = null;

        private void listTagOnAfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            // Item edition was cancelled and it has no text
            if (e.CancelEdit &&
                (string.IsNullOrEmpty(listTag.Items[e.Item].Text)
                || string.IsNullOrWhiteSpace(listTag.Items[e.Item].Text)))
            {
                listTag.Items.RemoveAt(e.Item);
            }
            else if (oldTag != null)
            {
                Navigation.Set(File, Kind.Tag, oldTag, e.Label);
            }
        }

        private void listTagOnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (Keys.F2.Equals(e.KeyChar) && listTag.SelectedItems.Count > 0)
            {
                listTag.SelectedItems[0].BeginEdit();
            }
        }

        private void listTagOnMouseDown(object sender, MouseEventArgs e)
        {
            // DoubleClicked && is an item?
            if (e.Clicks == 2 && listTag.HitTest(e.Location).Item != null)
            {
                listTag.HitTest(e.Location).Item.BeginEdit();
            }
        }

        private void pictureTagAddOnClick(object sender, EventArgs e)
        {
            //TODO Tag Add
        }

        private void pictureTagRemoveOnClick(object sender, EventArgs e)
        {
            List<string> toRemove = new List<string>();
            foreach (var item in listTag.SelectedItems)
            {
                toRemove.Add((item as string));
            }

            if (toRemove.Count > 0)
            {
                Navigation.Remove(File, Kind.Tag, toRemove);
            }
        }

        #endregion Tags: Methods

        //TODO Persons: Methods
        //TODO Take into account the timing
    }
}
