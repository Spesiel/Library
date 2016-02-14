using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization;

namespace Library.Resources.Objects
{
    [Serializable]
    public struct Item : IArtifact
    {
        #region Fields + Properties

        public Exif Exif { get; set; }

        [IgnoreDataMember]
        public Image Thumbnail
        {
            get
            {
                if (string.IsNullOrEmpty(_Thumbnail))
                {
                    return null;
                }
                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(_Thumbnail)))
                {
                    return Image.FromStream(ms);
                }
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    value.Save(ms, ImageFormat.Png);
                    _Thumbnail = Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        private string _Thumbnail { get; set; }

        #endregion Fields + Properties

        #region Methods

        public static bool operator !=(Item item1, Item item2) => !item1.Equals(item2);

        public static bool operator ==(Item item1, Item item2) => item1.Equals(item2);

        public override bool Equals(object obj)
        {
            if (!(obj is Item))
                return false;

            return Equals((Item)obj);
        }

        public bool Equals(Item other)
        {
            if (_Thumbnail != other._Thumbnail || Exif != other.Exif)
                return false;

            return true;
        }

        public override int GetHashCode() => _Thumbnail.GetHashCode() ^ Exif.GetHashCode();

        #endregion Methods
    }
}
