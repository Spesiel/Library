using System;
using System.Diagnostics;
using System.Linq;

namespace Library.Cache
{
    public static class Access
    {
        #region Fields + Properties

        internal static Index_FileGuid Index_FileGuid { get { return _Index_FileGuid; } }
        internal static Index_GuidFile Index_GuidFile { get { return _Index_GuidFile; } }
        internal static Items Items { get { return _Items; } }
        internal static Timings Timings { get { return _Timings; } }
        private static Index_FileGuid _Index_FileGuid = new Index_FileGuid();
        private static Index_GuidFile _Index_GuidFile = new Index_GuidFile();
        private static Items _Items = new Items();
        private static Timings _Timings = new Timings();

        #endregion Fields + Properties

        #region Methods

        public static void Initialization()
        {
            Items.ItemAdded += (args) =>
            {
                Guid guid = Guid.NewGuid();
                Index_GuidFile.Add(guid, args.File);
                Index_FileGuid.Add(args.File, guid);

                Debug.WriteLine("Cache.ObjectAdded: Trigger was fired for file " + args.File);
            };

            Items.ItemRemoved += (args) =>
            {
                Guid guid = Index_FileGuid.Get(args.File);
                Index_GuidFile.Remove(guid);
                Index_FileGuid.Remove(args.File);

                // Removes the item from the other libraries
                Index_GuidFile.Get(args.File).AsParallel().ForAll(i => { Timings.Remove(i); });
                Debug.WriteLine("Cache.ObjectRemoved: Trigger was fired for file " + args.File);
            };

            Timings.TimingAdded += (args) =>
            {
                Index_GuidFile.Add(args.Guid, args.File);
                Debug.WriteLine("Cache.TimingAdded: Trigger was fired for file " + args.File);
            };
        }

        #endregion Methods

        #region Flush / Clear

        public static void Clear()
        {
            Index_GuidFile.Clear();
            Index_FileGuid.Clear();

            Items.Clear();
            Timings.Clear();
        }

        public static void Flush()
        {
            Index_GuidFile.Flush();
            Index_FileGuid.Flush();

            Items.Flush();
            Timings.Flush();
        }

        #endregion Flush / Clear
    }
}
