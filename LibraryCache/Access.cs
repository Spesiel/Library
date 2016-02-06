using System;
using System.Diagnostics;
using System.Linq;

namespace Library.Cache
{
    public static class Access
    {
        #region Fields + Properties

        internal static Index_GuidFile Index_GuidFile { get { return _Index_GuidFile; } }
        internal static Items Items { get { return _Items; } }
        internal static Persons Persons { get { return _Persons; } }
        internal static Tags Tags { get { return _Tags; } }
        internal static Timings Timings { get { return _Timings; } }
        private static Index_GuidFile _Index_GuidFile = new Index_GuidFile();
        private static Items _Items = new Items();
        private static Persons _Persons = new Persons();
        private static Tags _Tags = new Tags();
        private static Timings _Timings = new Timings();

        #endregion Fields + Properties

        #region Methods

        public static void Initialization()
        {
            Items.ItemAdded += (args) =>
            {
                Guid guid = Guid.NewGuid();
                Index_GuidFile.Add(guid, args.File);

                Debug.WriteLine("Cache.ObjectAdded: Trigger was fired for file " + args.File);
            };

            Items.ItemRemoved += (args) =>
            {
                // Removes the item from all libraries
                Index_GuidFile.GetGuids(args.File).AsParallel().ForAll(i =>
                {
                    Timings.Remove(i);
                    Tags.Remove(i);

                    Index_GuidFile.Remove(i);
                });
                Debug.WriteLine("Cache.ObjectRemoved: Trigger was fired for file " + args.File);
            };

            Timings.TimingAdded += (args) =>
            {
                Index_GuidFile.Add(args.Guid, args.File);
                Debug.WriteLine("Cache.TimingAdded: Trigger was fired for file " + args.File);
            };

            Tags.TagAdded += (args) =>
            {
                Index_GuidFile.Add(args.Guid, args.File);
                Debug.WriteLine("Cache.TagAdded: Trigger was fired for file " + args.File);
            };

            Persons.PersonAdded += (args) =>
            {
                Index_GuidFile.Add(args.Guid, args.File);
                Debug.WriteLine("Cache.PersonAdded: Trigger was fired for file " + args.File);
            };
        }

        #endregion Methods

        #region Flush / Clear

        public static void Clear()
        {
            Index_GuidFile.Clear();

            Items.Clear();
            Timings.Clear();
            Tags.Clear();
            Persons.Clear();
        }

        public static void Flush()
        {
            Index_GuidFile.Flush();

            Items.Flush();
            Timings.Flush();
            Tags.Flush();
            Persons.Flush();
        }

        #endregion Flush / Clear
    }
}
