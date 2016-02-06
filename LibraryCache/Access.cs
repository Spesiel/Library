using Library.Resources;
using System;
using System.Diagnostics;
using System.Linq;

namespace Library.Cache
{
    public static class Access
    {
        #region Fields + Properties

        public static Items Items { get { return _Items; } }
        public static Persons Persons { get { return _Persons; } }
        public static Tags Tags { get { return _Tags; } }
        public static Timings Timings { get { return _Timings; } }
        internal static Catalog Catalog { get { return _Catalog; } }
        private static Catalog _Catalog = new Catalog();
        private static Items _Items = new Items();
        private static Persons _Persons = new Persons();
        private static Tags _Tags = new Tags();
        private static Timings _Timings = new Timings();

        #endregion Fields + Properties

        #region Constructors

        // We need those events to be initialized, and there's no way to do this
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline")]
        static Access()
        {
            Items.ItemRemoved += (args) =>
            {
                // Removes the item from all libraries
                Catalog.GetGuids(args.File).AsParallel().ForAll(i =>
                {
                    switch (i.Value)
                    {
                        case Kind.Timing:
                            Timings.Remove(i.Key);
                            break;

                        case Kind.Tag:
                            Tags.Remove(i.Key);
                            break;

                        case Kind.Person:
                            Persons.Remove(i.Key);
                            break;

                        default:
                            break;
                    }
                });
                Debug.WriteLine("Cache.ItemRemoved: Trigger was fired for file " + args.File);
            };

            Timings.TimingAdded += (args) =>
            {
                Catalog.Add(args.Guid, args.File, Kind.Timing);
                Debug.WriteLine("Cache.TimingAdded: Trigger was fired for file " + args.File);
            };

            Tags.TagAdded += (args) =>
            {
                Catalog.Add(args.Guid, args.File, Kind.Tag);
                Debug.WriteLine("Cache.TagAdded: Trigger was fired for file " + args.File);
            };

            Persons.PersonAdded += (args) =>
            {
                Catalog.Add(args.Guid, args.File, Kind.Person);
                Debug.WriteLine("Cache.PersonAdded: Trigger was fired for file " + args.File);
            };
        }

        #endregion Constructors

        #region Flush / Clear

        public static void Clear()
        {
            Catalog.Clear();

            Items.Clear();
            Timings.Clear();
            Tags.Clear();
            Persons.Clear();
        }

        public static void Flush()
        {
            Catalog.Flush();

            Items.Flush();
            Timings.Flush();
            Tags.Flush();
            Persons.Flush();
        }

        #endregion Flush / Clear
    }
}
