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

        public static Item Get(string current)
        {
            return CacheManager.Items[current];
        }

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

        #region GetAll

        public static IList<Person> GetAllPersons(string current)
        {
            return GetAll(current, Kind.Person).ConvertAll(i => (Person)i);
        }

        public static IList<string> GetAllTags(string current)
        {
            return GetAll(current, Kind.Tag).ConvertAll(i => i.ToString());
        }

        public static IList<Timing> GetAllTimings(string current)
        {
            return GetAll(current, Kind.Timing).ConvertAll(i => (Timing)i);
        }

        private static List<IArtifact> GetAll(string current, Kind kind)
        {
            return new List<IArtifact>(CacheManager.Search(current, kind));
        }

        #endregion GetAll

        #region Count

        public static int CountValues(string location)
        {
            return new List<string>(CacheManager.SearchItems(location)).Count;
        }

        public static int CountValuesWhereExifIsPresent()
        {
            return CacheManager.CountValuesWhere(v => v.Exif.HasBeenSet);
        }

        public static int CountValuesWhereThumbnailIsPresent()
        {
            return CacheManager.CountValuesWhere(v => v.Thumbnail != null);
        }

        #endregion Count
    }
}
