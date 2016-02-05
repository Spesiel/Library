using Library.Resources;
using Microsoft.Isam.Esent.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace Library.Cache
{
    /// <summary>
    /// Library holding the thumbnails.<br/>
    /// As they are unique for each file, the key is always the file itself
    /// </summary>
    public static class Thumbnails
    {
        //FIXME Fix path
        private static PersistentDictionary<string, string> _Library = new PersistentDictionary<string, string>(Constants.CachePath + "Thumbnails");

        private static IList<string> Keys { get { return _Library.Keys.OrderBy(k => k).ToList(); } }

        internal static event LibraryEventHandler ObjectAdded;

        /// <summary>
        /// Adds a new entry in the library
        /// </summary>
        /// <param name="file">The file we save the thumbnail of</param>
        /// <param name="image">The thumbnail itself</param>
        public static void Add(string file, Image image)
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
                _Library[file] = thumb;
                ObjectAdded(new LibraryEventArgs(file, false));
            }
            else
            {
                _Library.Add(file, thumb);
                ObjectAdded(new LibraryEventArgs(file, true));
            }
        }

        /// <summary>
        /// Get the thumbnail for the given file
        /// </summary>
        /// <param name="file">The file for which we retrieve the thumbnail</param>
        /// <returns>The thumbnail</returns>
        public static Image Get(string file)
        {
            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(_Library[file])))
            {
                return Image.FromStream(ms);
            }
        }
    }
}