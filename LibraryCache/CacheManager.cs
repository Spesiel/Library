using Library.Cache.Objects;
using Library.Resources;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Library.Cache
{
    public static class CacheManager
    {
        #region Fields + Properties

        public static ItemHoard Items { get { return _Items; } }
        public static PersonHoard Persons { get { return _Persons; } }
        public static TagHoard Tags { get { return _Tags; } }
        public static TimingHoard Timings { get { return _Timings; } }
        internal static Catalog Index { get { return _Index; } }
        private static Catalog _Index = new Catalog();
        private static ItemHoard _Items = new ItemHoard();
        private static PersonHoard _Persons = new PersonHoard();
        private static TagHoard _Tags = new TagHoard();
        private static TimingHoard _Timings = new TimingHoard();

        #endregion Fields + Properties

        #region Constructors

        // We need those events to be initialized, and there's no way to do this
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline")]
        static CacheManager()
        {
            ItemHoard.ItemRemoved += (args) =>
            {
                // Removes the item from all libraries
                Index.GetGuids(args.File).AsParallel().ForAll(i =>
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
                    Index.Remove(i.Key);
                });
                Debug.WriteLine("Cache.ItemRemoved: Trigger was fired for file " + args.File);
            };

            TimingHoard.TimingAdded += (args) =>
            {
                Index.Add(args.Guid, args.File, Kind.Timing);
                Debug.WriteLine("Cache.TimingAdded: Trigger was fired for file " + args.File);
            };

            TagHoard.TagAdded += (args) =>
            {
                Index.Add(args.Guid, args.File, Kind.Tag);
                Debug.WriteLine("Cache.TagAdded: Trigger was fired for file " + args.File);
            };

            PersonHoard.PersonAdded += (args) =>
            {
                Index.Add(args.Guid, args.File, Kind.Person);
                Debug.WriteLine("Cache.PersonAdded: Trigger was fired for file " + args.File);
            };
        }

        #endregion Constructors

        #region Methods

        public static Tuple<int, int> IndexOf(string location, object key, Kind kind)
        {
            int index = -1;
            int count = -1;

            if (Kind.Item.Equals(kind))
            {
                List<string> list = SearchItems(location).ToList();
                index = list.IndexOf(key as string);
                count = list.Count;
            }
            else
            {
                List<IArtifact> list = Search(location, kind).ToList();

                index = list.IndexOf(key as IArtifact);
                count = list.Count;
            }

            return Tuple.Create(index, count);
        }

        #endregion Methods

        #region Searches

        public static IEnumerable<IArtifact> Search(string location, Kind kind)
        {
            IEnumerable<IArtifact> ans = null;
            IEnumerable<Guid> guids = SearchIndex(location, kind);

            switch (kind)
            {
                case Kind.Person:
                    ans = Persons.Get(guids);
                    break;

                case Kind.Timing:
                    ans = Timings.Get(guids);
                    break;

                case Kind.Tag:
                    ans = Tags.Get(guids);
                    break;

                default:
                    break;
            }

            return ans;
        }

        public static IEnumerable<Guid> SearchIndex(string location, Kind kind)
        {
            return Index.Get(Items.Search(location), kind);
        }

        public static IEnumerable<string> SearchItems(string location)
        {
            return Items.Keys.Where(k => (k as string).StartsWith(location)).OrderBy(o => o);
        }

        #endregion Searches

        #region Counts

        public static int CountValues(string location)
        {
            int ans = 0;
            if (location == null)
            {
                ans = Items.Count;
            }
            else {
                ans = Items.Keys.Count(i => i.StartsWith(location, StringComparison.OrdinalIgnoreCase));
            }

            return ans;
        }

        public static int CountValuesWhere(Func<Item, bool> predicate)
        {
            return Items.Library.Values.Count(predicate);
        }

        #endregion Counts

        #region Flush / Clear

        public static void Clear()
        {
            Index.Clear();

            Items.Clear();
            Timings.Clear();
            Tags.Clear();
            Persons.Clear();
        }

        public static void Flush()
        {
            Index.Flush();

            Items.Flush();
            Timings.Flush();
            Tags.Flush();
            Persons.Flush();
        }

        #endregion Flush / Clear
    }
}
