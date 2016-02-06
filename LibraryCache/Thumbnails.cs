using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Library.Cache
{
    /// <summary>
    /// Library holding the thumbnails.<br/>
    /// As they are unique for each file, the key is always the file itself
    /// </summary>
    internal class Thumbnails : Cache<string, string>
    {
        #region Delegates + Events

        internal static event AsyncLibraryEventHandler ObjectAdded;

        internal static event AsyncLibraryEventHandler ObjectRemoved;

        #endregion Delegates + Events

        #region Constructors

        public Thumbnails() : base(nameof(Thumbnails))
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Adds a new entry in the library
        /// </summary>
        /// <param name="file">The file we save the thumbnail of</param>
        /// <param name="image">The thumbnail itself</param>
        public void Add(string file, Image image)
        {
            string thumb;
            using (MemoryStream ms = new MemoryStream())
            {
                if (image == null)
                {
                    throw new ArgumentNullException(nameof(image));
                }
                image.Save(ms, ImageFormat.Png);
                thumb = Convert.ToBase64String(ms.ToArray());
            }

            // Add/Put in the Library, fires an event signaling the change
            if (Keys.Contains(file))
            {
                Library[file] = thumb;
                ObjectAdded(new LibraryEventAsyncArgs(file, false));
            }
            else
            {
                Library.Add(file, thumb);
                ObjectAdded(new LibraryEventAsyncArgs(file, true));
            }
        }

        /// <summary>
        /// Get the thumbnail for the given file
        /// </summary>
        /// <param name="file">The file for which we retrieve the thumbnail</param>
        /// <returns>The thumbnail</returns>
        public Image GetThumbnail(string file)
        {
            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(Library[file])))
            {
                return Image.FromStream(ms);
            }
        }

        public override void Remove(string file)
        {
            Library.Remove(file);
            ObjectRemoved(new LibraryEventAsyncArgs(file));
        }

        #endregion Methods
    }
}
