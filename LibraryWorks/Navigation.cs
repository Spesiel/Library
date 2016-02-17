using Library.Cache;
using Library.Resources;
using Library.Resources.Objects;
using System;
using System.Collections.Generic;

namespace Library.Works
{
    public static class Navigation
    {
        #region Get and Get+-

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

        #endregion Get and Get+-

        #region Methods

        public static void Add(string file, Kind kind, IList<object> listNewObjects)
        {
            if (listNewObjects != null && listNewObjects.Count > 0)
            {
                foreach (object item in listNewObjects)
                {
                    Set(file, kind, null, item);
                }
            }
        }

        public static void Remove(Kind kind, IEnumerable<object> list)
        {
            switch (kind)
            {
                case Kind.Person:
                    CacheManager.Persons.Remove(CacheManager.Persons.Find(list as IEnumerable<Person>));
                    break;

                case Kind.Timing:
                    CacheManager.Timings.Remove(CacheManager.Timings.Find(list as IEnumerable<Timing>));
                    break;

                case Kind.Tag:
                    CacheManager.Tags.Remove(CacheManager.Tags.Find(list as IEnumerable<string>));
                    break;

                default:
                    break;
            }
        }

        public static void Set(string file, Kind kind, object oldValue, object newValue)
        {
            switch (kind)
            {
                case Kind.Person:
                    if (oldValue == null)
                    {
                        CacheManager.Persons.Add(file, (Person)newValue);
                    }
                    else
                    {
                        CacheManager.Persons.Set((Person)oldValue, (Person)newValue);
                    }
                    break;

                case Kind.Timing:
                    if (oldValue == null)
                    {
                        CacheManager.Timings.Add(file, (Timing)newValue);
                    }
                    else
                    {
                        CacheManager.Timings.Set((Timing)oldValue, (Timing)newValue);
                    }
                    break;

                case Kind.Tag:
                    string str = (newValue as string).Trim();
                    if (oldValue == null)
                    {
                        CacheManager.Tags.Add(file, str);
                    }
                    else
                    {
                        CacheManager.Tags.Set(oldValue as string, str);
                    }
                    break;

                default:
                    throw new NotSupportedException(nameof(kind) + " " + kind.ToString());
            }
        }

        #endregion Methods

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
