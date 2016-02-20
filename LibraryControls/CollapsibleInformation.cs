using Library.Resources.Objects;
using Library.Resources.TextResources;
using Library.Works;
using System.Collections.Generic;
using System.Reflection;

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

            // If a file has been specified, try and load its informations from the database
            if (File != null)
            {
                flowTags.Insert(Navigation.GetAllTags(File));
                flowPersons.Insert(FillPersons());
                FillExif();
            }

            SetTexts();
            LanguageChoice.LanguageChanged += (s, e) => SetTexts();
        }

        //TOFIX Texts
        private void SetTexts()
        {
            Title = Texts.InformationPlural;
            tabPageExif.Text = Texts.Exif;
            tabPageTag.Text = Texts.Tags;
            tabPagePerson.Text = Texts.Persons;
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

        private List<string> FillPersons()
        {
            List<string> ans = new List<string>();

            foreach (Person p in Navigation.GetAllPersons(File))
            {
                if (string.IsNullOrEmpty(p.DisplayName))
                {
                    ans.Add(p.FirstName + TextsPermanent.Space + p.LastName);
                }
                else
                {
                    ans.Add(p.DisplayName);
                }
            }

            return ans;
        }

        #endregion FillSth Methods

        //TODO Take into account the timing
    }
}
