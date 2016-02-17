using Library.Cache;
using Library.Resources;
using Library.Resources.Objects;
using System;
using System.Collections.Generic;

namespace Library.Works
{
    public static class Navigation
    {
        #region Methods

        public static Item Get(string current) => CacheManager.Items[current];

        public static Item GetNext(string location, string current)
        {
            Tuple<int, int> res = CacheManager.IndexOf(location, current, Kind.Item);
            return CacheManager.Items[res.Item1 + 1 < res.Item2 ? res.Item1 + 1 : res.Item1];
        }

        public static Item GetPrevious(string location, string current)
        {
            Tuple<int, int> res = CacheManager.IndexOf(location, current, Kind.Item);
            return CacheManager.Items[res.Item1 > 0 ? res.Item1 - 1 : res.Item1];
        }

        #endregion Methods

        public static void Set(string file, Kind kind, object oldObj, object newObj)
        {
            switch (kind)
            {
                case Kind.Person:

                    //TODO Set Person
                    throw new NotImplementedException();
                    break;

                case Kind.Timing:

                    //TODO Set Timing
                    throw new NotImplementedException();
                    break;

                case Kind.Tag:
                    if (oldObj == null)
                    {
                        CacheManager.Tags.Add(file, newObj as string);
                    }
                    else
                    {
                        CacheManager.Tags.Set(file, oldObj as string, newObj as string);
                    }
                    break;

                default:
                    throw new NotSupportedException(nameof(kind) + " " + kind.ToString());
            }
        }

        #region GetAll

        public static IList<Person> GetAllPersons(string current) => GetAll(current, Kind.Person).ConvertAll(i => (Person)i);

        public static IList<string> GetAllTags(string current) => GetAll(current, Kind.Tag).ConvertAll(i => i.ToString());

        public static IList<Timing> GetAllTimings(string current) => GetAll(current, Kind.Timing).ConvertAll(i => (Timing)i);

        private static List<IArtifact> GetAll(string current, Kind kind) => new List<IArtifact>(CacheManager.Search(current, kind));

        #endregion GetAll

        #region Count

        public static int CountValues(string location) => new List<string>(CacheManager.SearchItems(location)).Count;

        public static int CountValuesWhereExifIsPresent() => CacheManager.CountValuesWhere(v => v.Exif.HasBeenSet);

        public static int CountValuesWhereThumbnailIsPresent() => CacheManager.CountValuesWhere(v => v.Thumbnail != null);

        #endregion Count
    }
}
