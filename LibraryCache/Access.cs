using System;
using System.Diagnostics;
using System.Drawing;

namespace Library.Cache
{
    public static class Access
    {
        #region Fields + Properties

        internal static Index_FileGuid Index_FileGuid { get { return _Index_FileGuid; } }
        internal static Index_GuidFile Index_GuidFile { get { return _Index_GuidFile; } }
        internal static Thumbnails Thumbnails { get { return _Thumbnails; } }
        private static Index_FileGuid _Index_FileGuid = new Index_FileGuid();
        private static Index_GuidFile _Index_GuidFile = new Index_GuidFile();
        private static Thumbnails _Thumbnails = new Thumbnails();

        #endregion Fields + Properties

        #region Methods

        public static void Initialization()
        {
            Thumbnails.ObjectAdded += (args) =>
            {
                if (args.IsNew)
                {
                    Guid guid = Guid.NewGuid();
                    Index_GuidFile.Add(guid, args.File);
                    Index_FileGuid.Add(args.File, guid);
                }
                Debug.WriteLine("Cache.ObjectAdded: Trigger was fired for file " + args.File);
            };

            Thumbnails.ObjectRemoved += (args) =>
            {
                Guid guid = Index_FileGuid.Get(args.File);
                Index_GuidFile.Remove(guid);
                Index_FileGuid.Remove(args.File);
                Debug.WriteLine("Cache.ObjectRemoved: Trigger was fired for file " + args.File);
            };
        }

        #endregion Methods

        #region Thumbnail: Get / Add

        public static void AddThumbnail(string file, Image image)
        {
            Thumbnails.Add(file, image);
        }

        public static Image GetThumbnail(string file)
        {
            return Thumbnails.GetThumbnail(file);
        }

        #endregion Thumbnail: Get / Add

        #region Remove

        public static void Remove(string file)
        {
            Thumbnails.Remove(file);
        }

        #endregion Remove

        #region Flush / Clear

        public static void Clear()
        {
            Index_GuidFile.Clear();

            Thumbnails.Clear();
        }

        public static void Flush()
        {
            Index_GuidFile.Flush();

            Thumbnails.Flush();
        }

        #endregion Flush / Clear
    }
}
